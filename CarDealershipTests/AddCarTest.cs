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
    public class AddCarTests
    {
        [TestMethod]
        public void AddCar_NormalPath()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCar_Accessor mc = new MakeCar_Accessor("1", "sedan", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "Sean", "5555555555", "calgary", "male" };

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeleteVehicle(1);
            }
            catch (Exception)
            {

            }
            mp.CreateVehicle();
            mc.CreateCar();

        }

        [TestMethod]
        public void AddCar_OnlyID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCar_Accessor mc = new MakeCar_Accessor("1", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "", "", "", "" };

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeleteVehicle(1);
            }
            catch (Exception)
            {

            }
            mp.CreateVehicle();
            mc.CreateCar();

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddCar_NullID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCar_Accessor mc = new MakeCar_Accessor("", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "", "", "", "", "" };

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());

            mp.CreateVehicle();
            mc.CreateCar();

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddCar_DuplicateID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCar_Accessor mc = new MakeCar_Accessor("1", "sedan", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "Sean", "5555555555", "calgary", "male" };

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeleteVehicle(1);
            }
            catch (Exception)
            {

            }
            mp.CreateVehicle();
            mc.CreateCar();
            mp.CreateVehicle();
            mc.CreateCar();

        }


        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddCar_NegativeID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeCar_Accessor mc = new MakeCar_Accessor("-5", "sedan", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "-5", "", "", "", "" };

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeleteVehicle(-5);
            }
            catch (Exception)
            {

            }
            mp.CreateVehicle();
            mc.CreateCar();

        }
    }
}
