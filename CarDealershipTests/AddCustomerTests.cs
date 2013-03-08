using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarDealership;
using System.Data;
using System.Data.OleDb;

namespace CarDealershipTests
{
    [TestClass]
    public class AddCustomerTests
    {
        [TestMethod]
        public void AddCustomer_NormalPath()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("1", "test", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] {"1", "Sean", "5555555555", "calgary", "F"};

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(1);
            }
            catch (Exception)
            {
                
            }
            mp.CreatePerson();
            mc.CreateCustomer();

        }

        [TestMethod]
        public void AddCustomer_OnlyID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("1", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "", "", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(1);
            }
            catch (Exception)
            {
                
            }
            mp.CreatePerson();
            mc.CreateCustomer();

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddCustomer_NullID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "", "", "", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
           
            mp.CreatePerson();
            mc.CreateCustomer();

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddCustomer_DuplicateID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("1", "test", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "Sean", "5555555555", "calgary", "M" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(1);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateCustomer();
            mp.CreatePerson();
            mc.CreateCustomer();

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCustomer_NegativeID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("-5", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "-5", "", "", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(-5);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateCustomer();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCustomer_BadPhoneLength()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("1", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "", "12345678901", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(1);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateCustomer();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCustomer_BadPhoneChars()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("1", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "", ".23456780", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(1);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateCustomer();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCustomer_BadSex()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("1", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "", "", "", "female" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(1);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateCustomer();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCustomer_BadIDFormat()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("abc", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "abc", "", "", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(1);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateCustomer();

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCustomer_BadCIDFormat()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("abc", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "10", "", "", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(10);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateCustomer();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCustomer_BadCIDValue()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("-5", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "10", "", "", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(10);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateCustomer();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCustomer_NullCIDValue()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "10", "", "", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(10);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateCustomer();

        }

        [TestMethod]
        public void AddCustomer_DeleteInstance()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCustomer_Accessor mc = new MakeCustomer_Accessor("3", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "3", "", "", "", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(3);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateCustomer();

            SearchFunction_Accessor SF = new SearchFunction_Accessor(db.GetDB());
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            try
            {
                dt2 = SF.SearchPersonID("3");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            mc.DeleteCustomer();
            mp.DeletePerson();

            try
            {
                dt1 = SF.SearchPersonID("3");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            Assert.IsTrue(dt1.Rows.Count == 0 && dt2.Rows.Count == 1);

        }
    }
}
