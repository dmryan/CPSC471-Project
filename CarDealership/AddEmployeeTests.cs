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
    public class AddEmployeeTests
    {
        [TestMethod]
        public void AddEmployee_NormalPath()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("1", "123", "1/1/1", "", db.GetDB());
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
            mc.CreateEmployee();

        }
        [TestMethod]
        public void AddEmployee_OnlyID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("1", "", "", "", db.GetDB());
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
            mc.CreateEmployee();

        }
        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddEmployee_NullID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("", "", "", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "", "", "", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());

            mp.CreatePerson();
            mc.CreateEmployee();

        }
        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddEmployee_DuplicateID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("1", "123", "1/1/1", "1", db.GetDB());
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
            mc.CreateEmployee();
            mp.CreatePerson();
            mc.CreateEmployee();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEmployee_NegativeID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("-5", "", "", "", db.GetDB());
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
            mc.CreateEmployee();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEmployee_BadPhoneLength()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("1", "", "", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "", "555555555", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(1);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateEmployee();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEmployee_BadPhoneChars()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("1", "", "", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "", "123456789b", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(1);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateEmployee();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEmployee_BadSex()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("1", "", "", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "", "", "", "male" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(1);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateEmployee();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEmployee_BadPersonIDFormat()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("abc", "", "", "", db.GetDB());
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
            mc.CreateEmployee();

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEmployee_BadIDFormat()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("abc", "", "", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "11", "", "", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(11);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateEmployee();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEmployee_BadIDValue()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("-5", "", "", "", db.GetDB());
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
            mc.CreateEmployee();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEmployee_BadSalaryValue()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("1", "-5", "", "", db.GetDB());
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
            mc.CreateEmployee();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEmployee_BadSalaryFormat()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("2", "abc", "", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "2", "", "", "", "" };

            MakePerson_Accessor mp = new MakePerson_Accessor(D, db.GetDB());
            try
            {
                d.DeletePerson(2);
            }
            catch (Exception)
            {

            }
            mp.CreatePerson();
            mc.CreateEmployee();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEmployee_BadManIDValue()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("1", "", "", "-5", db.GetDB());
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
            mc.CreateEmployee();

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEmployee_BadManIDFormat()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("1", "", "", "abc", db.GetDB());
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
            mc.CreateEmployee();

        }
        
        [TestMethod]
        public void AddEmployee_DeleteInstance()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEmployee_Accessor mc = new MakeEmployee_Accessor("3", "", "", "", db.GetDB());
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
            mc.CreateEmployee();

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

            mc.DeleteEmployee();
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
