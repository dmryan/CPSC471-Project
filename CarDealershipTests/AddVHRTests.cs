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
    public class AddVHRTests
    {
        [TestMethod]
        public void AddVHR_NormalPath()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();

            String[] D = new String[] { "1", "22", "123", "123", "123", "123" };
            MakeVHR_Accessor mc = new MakeVHR_Accessor(D, db.GetDB());
            TestingFunctions t = new TestingFunctions(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                t.DeleteVHR(1);
            }
            catch (Exception)
            {

            }
            mc.CreateVHR();

        }

        [TestMethod]
        public void AddVHR_OnlyID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "1", "22", "", "", "", "" };
            MakeVHR_Accessor mc = new MakeVHR_Accessor(D, db.GetDB());
            TestingFunctions t = new TestingFunctions(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                t.DeleteVHR(1);
            }
            catch (Exception)
            {

            }
            mc.CreateVHR();

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddVHR_NullID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "", "", "", "", "", "" };
            MakeVHR_Accessor mc = new MakeVHR_Accessor(D, db.GetDB());
            TestingFunctions t = new TestingFunctions(db.GetDB());
            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());

            mc.CreateVHR();

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddVHR_DuplicateID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "1", "22", "123", "123", "123", "123" };
            MakeVHR_Accessor mc = new MakeVHR_Accessor(D, db.GetDB());
            TestingFunctions t = new TestingFunctions(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                t.DeleteVHR(1);
            }
            catch (Exception)
            {

            }
            mc.CreateVHR();
            mc.CreateVHR();

        }


        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddVHR_NegativeID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "-5", "22", "", "", "", "" };
            MakeVHR_Accessor mc = new MakeVHR_Accessor(D, db.GetDB());
            TestingFunctions t = new TestingFunctions(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                t.DeleteVHR(-5);
            }
            catch (Exception)
            {

            }
            mc.CreateVHR();

        }
    }
}

