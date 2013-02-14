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
    public class AddPartTests
    {
        [TestMethod]
        public void AddPart_NormalPath()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();

            String[] D = new String[] { "1", "1", "123", "123", "123", "123" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeleteVehicle(1);
            }
            catch (Exception)
            {

            }
            mp.CreateVehicle();
            mc.CreatePart();

        }

        [TestMethod]
        public void AddPart_OnlyID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "1", "1", "", "", "", "" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeleteVehicle(1);
            }
            catch (Exception)
            {

            }
            mp.CreateVehicle();
            mc.CreatePart();

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddPart_NullID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "", "", "", "", "", "" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());

            mp.CreateVehicle();
            mc.CreatePart();

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddPart_DuplicateID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "1", "1", "123", "123", "123", "123" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeleteVehicle(1);
            }
            catch (Exception)
            {

            }
            mp.CreateVehicle();
            mc.CreatePart();
            mp.CreateVehicle();
            mc.CreatePart();

        }


        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddPart_NegativeID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "-5", "1", "", "", "", "" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeleteVehicle(-5);
            }
            catch (Exception)
            {

            }
            mp.CreateVehicle();
            mc.CreatePart();

        }
    }
}

