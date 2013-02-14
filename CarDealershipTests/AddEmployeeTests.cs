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
            String[] D = new String[] { "1", "Sean", "5555555555", "calgary", "male" };

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
            String[] D = new String[] { "1", "Sean", "5555555555", "calgary", "male" };

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
        [ExpectedException(typeof(OleDbException))]
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
    }
}
