using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarDealership;
using System.Data.OleDb;
using System.Data;

namespace CarDealershipTests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void AddEmployeeControl_constructor()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            AddEmployeeControl_Accessor aec = new AddEmployeeControl_Accessor(db.GetDB());

            Assert.IsNotNull(aec);
        }
        [TestMethod]
        public void AddCustomerControl_constructor()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            AddCustomerControl_Accessor acc = new AddCustomerControl_Accessor(db.GetDB());

            Assert.IsNotNull(acc);
        }
        [TestMethod]
        public void AddEmployeeControl_create()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            SearchFunction_Accessor sf = new SearchFunction_Accessor(db.GetDB());
            AddEmployeeControl_Accessor aec = new AddEmployeeControl_Accessor(db.GetDB());

            String[] D = new String[] {"10011", "Sean", "5555555555", "calgary", "M", "10011", "30000", "12/12/12", "" };

            try
            {
                d.DeletePerson(10011);
            }
            catch (Exception)
            {

            }
            aec.createEmployee(D);
            DataTable dt = sf.SearchPersonID("10011");
            Assert.IsTrue(dt.Rows.Count == 1);
        }
        [TestMethod]
        public void AddEmployeeControl_negativeIDValue()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            SearchFunction_Accessor sf = new SearchFunction_Accessor(db.GetDB());
            AddEmployeeControl_Accessor aec = new AddEmployeeControl_Accessor(db.GetDB());

            try
            {
                d.DeletePerson(-500);
            }
            catch (Exception)
            {

            }
            String[] D = new String[] { "-500", "", "", "", "", "-500", "", "", "" };

            ErrorWindow ew = aec.createEmployee(D);
            DataTable dt = null;
            try
            {
                dt = sf.SearchPersonID("abc");
            }
            catch (Exception e) { };
            Assert.IsTrue(dt.Rows.Count == 0);
            Assert.IsNotNull(ew);

        }
        [TestMethod]
        public void AddEmployeeControl_badPhoneNumber()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            SearchFunction_Accessor sf = new SearchFunction_Accessor(db.GetDB());
            AddEmployeeControl_Accessor aec = new AddEmployeeControl_Accessor(db.GetDB());

            String[] D = new String[] { "10011", "Sean", "55555", "calgary", "M", "10011", "30000", "12/12/12", "" };

            try
            {
                d.DeletePerson(10011);
            }
            catch (Exception)
            {

            }
            ErrorWindow ew = aec.createEmployee(D);
            DataTable dt = sf.SearchPersonID("10011");
            Assert.IsTrue(dt.Rows.Count == 0);
            Assert.IsNotNull(ew);
        }
        [TestMethod]
        public void AddEmployeeControl_createDuplicate()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            SearchFunction_Accessor sf = new SearchFunction_Accessor(db.GetDB());
            AddEmployeeControl_Accessor aec = new AddEmployeeControl_Accessor(db.GetDB());

            String[] D = new String[] { "10011", "Sean", "5555555555", "calgary", "M", "10011", "30000", "12/12/12", "" };

            try
            {
                d.DeletePerson(10011);
            }
            catch (Exception)
            {

            }
            aec.createEmployee(D);
            ErrorWindow ew = aec.createEmployee(D);
            DataTable dt = sf.SearchPersonID("10011");
            Assert.IsTrue(dt.Rows.Count == 1);
            Assert.IsNotNull(ew);
        }
        [TestMethod]
        public void AddEmployeeControl_badManagerID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            SearchFunction_Accessor sf = new SearchFunction_Accessor(db.GetDB());
            AddEmployeeControl_Accessor aec = new AddEmployeeControl_Accessor(db.GetDB());

            String[] D = new String[] { "10011", "", "", "", "", "10011", "", "", "101019" };

            try
            {
                d.DeletePerson(10011);
            }
            catch (Exception)
            {

            }
            ErrorWindow ew = aec.createEmployee(D);
            DataTable dt = sf.SearchPersonID("10011");
            Assert.IsTrue(dt.Rows.Count == 0);
            Assert.IsNotNull(ew);

        }
        [TestMethod]
        public void AddEmployeeControl_badIDValue()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            SearchFunction_Accessor sf = new SearchFunction_Accessor(db.GetDB());
            AddEmployeeControl_Accessor aec = new AddEmployeeControl_Accessor(db.GetDB());

            String[] D = new String[] { "abc", "", "", "", "", "abc", "", "", "" };

            ErrorWindow ew = aec.createEmployee(D);
            DataTable dt = null;
            try
            {
                dt = sf.SearchPersonID("abc");
            }
            catch (Exception e) { };
            Assert.IsTrue(dt.Rows.Count == 0);
            Assert.IsNotNull(ew);

        }
        [TestMethod]
        public void AddCustomerControl_create()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            SearchFunction_Accessor sf = new SearchFunction_Accessor(db.GetDB());
            AddCustomerControl_Accessor aec = new AddCustomerControl_Accessor(db.GetDB());

            String[] D = new String[] { "10011", "Sean", "5555555555", "calgary", "M", "10011", "Customer" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(10011);
            }
            catch (Exception)
            {

            }
            aec.createCustomer(D);
            DataTable dt = sf.SearchPersonID("10011");
            Assert.IsTrue(dt.Rows.Count == 1);
        }
        [TestMethod]
        public void AddCustomerControl_negativeIDValue()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            SearchFunction_Accessor sf = new SearchFunction_Accessor(db.GetDB());
            AddCustomerControl_Accessor aec = new AddCustomerControl_Accessor(db.GetDB());

            String[] D = new String[] { "-500", "Sean", "5555555555", "calgary", "M", "10011", "Customer" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(-500);
            }
            catch (Exception)
            {

            }

            ErrorWindow ew = aec.createCustomer(D);
            DataTable dt = null;
            try
            {
                dt = sf.SearchPersonID("-500");
            }
            catch (Exception e) { };
            Assert.IsTrue(dt.Rows.Count == 0);
            Assert.IsNotNull(ew);
        }
        [TestMethod]
        public void AddCustomerControl_badPhoneNumber()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            SearchFunction_Accessor sf = new SearchFunction_Accessor(db.GetDB());
            AddCustomerControl_Accessor aec = new AddCustomerControl_Accessor(db.GetDB());

            String[] D = new String[] { "10011", "Sean", "5555555555", "calgary", "M", "10011", "Customer" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(10011);
            }
            catch (Exception)
            {

            }

            ErrorWindow ew = aec.createCustomer(D);
            DataTable dt = null;
            try
            {
                dt = sf.SearchPersonID("10011");
            }
            catch (Exception e) { };
            Assert.IsTrue(dt.Rows.Count == 0);
            Assert.IsNotNull(ew);
        }
        [TestMethod]
        public void AddCustomerControl_createDuplicate()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            SearchFunction_Accessor sf = new SearchFunction_Accessor(db.GetDB());
            AddCustomerControl_Accessor aec = new AddCustomerControl_Accessor(db.GetDB());

            String[] D = new String[] { "10011", "Sean", "5555555555", "calgary", "M", "10011", "Customer" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(10011);
            }
            catch (Exception)
            {

            }
            aec.createCustomer(D);
            ErrorWindow ew = aec.createCustomer(D);
            DataTable dt = sf.SearchPersonID("10011");
            Assert.IsTrue(dt.Rows.Count == 1);
            Assert.IsNotNull(ew);
        }
        [TestMethod]
        public void AddCustomerControl_badIDValue()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            SearchFunction_Accessor sf = new SearchFunction_Accessor(db.GetDB());
            AddCustomerControl_Accessor aec = new AddCustomerControl_Accessor(db.GetDB());

            String[] D = new String[] { "abc", "", "", "", "", "abc", "Customer" };

            ErrorWindow ew = aec.createCustomer(D);
            DataTable dt = null;
            try
            {
                  dt = sf.SearchPersonID("abc");
            }
            catch (Exception e) { };
            Assert.IsTrue(dt.Rows.Count == 0);
            Assert.IsNotNull(ew);

        }
    }
}
