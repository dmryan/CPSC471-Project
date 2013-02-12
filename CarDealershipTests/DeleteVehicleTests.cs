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
    public class DeleteVehicleTests
    {
        [TestMethod]
        public void DeleteVehicle_NormalPath()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();
            Delete_Accessor d = new Delete_Accessor(connection.GetDB());
            try
            {
                d.DeleteVehicle(1);
            }
            catch (Exception e)
            {
            }
            String[] D = new String[] { "1" };
            MakeCar_Accessor car = new MakeCar_Accessor("1", "smart car", connection.GetDB());
            car.CreateCar();
            MakeVehicle_Accessor veh = new MakeVehicle_Accessor(D, connection.GetDB());
            veh.CreateVehicle();


            d.DeleteVehicle(1);

            try
            {
                dt = SF.SearchVehicle("1");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            Assert.IsTrue(dt.Rows.Count == 0);


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteVehicle_NonExistent()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();


            Delete_Accessor d = new Delete_Accessor(connection.GetDB());

            try
            {
                d.DeleteVehicle(1);
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteVehicle_Empty()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();


            Delete_Accessor d = new Delete_Accessor(connection.GetDB());

            try
            {
                d.DeleteVehicle(int.Parse(""));
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
    }
}
