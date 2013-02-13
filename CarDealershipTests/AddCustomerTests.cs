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
            String[] D = new String[] {"1", "Sean", "5555555555", "calgary", "male"};

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
            mc.CreateCustomer();
            mp.CreatePerson();
            mc.CreateCustomer();

        }


        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
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
    }
}
