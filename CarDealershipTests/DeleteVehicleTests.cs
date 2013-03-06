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
            String[] D = new String[] { "1", "1", "1", "1", "1", "1" };
            
            MakeVehicle_Accessor veh = new MakeVehicle_Accessor(D, connection.GetDB());
            veh.CreateVehicle();
            MakeCar_Accessor car = new MakeCar_Accessor("1", "smart car", connection.GetDB());
            car.CreateCar();

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
                d.DeleteVehicle(23452345);
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
                d.DeleteVehicle(new int());
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteVehicle_ExistsInPart()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(connection.GetDB());

            try
            {
                d.DeletePart(1);
            }
            catch (Exception)
            {
            }
            try
            {
                d.DeleteVehicle(111);
            }
            catch (Exception e)
            {
            }
            String[] D = new String[] { "111", "1", "1", "1", "1", "1" };

            MakeVehicle_Accessor veh = new MakeVehicle_Accessor(D, connection.GetDB());
            veh.CreateVehicle();
            MakeCar_Accessor car = new MakeCar_Accessor("111", "smart car", connection.GetDB());
            car.CreateCar();

            String[] D2 = new String[] { "1", "111", "", "", "", "" };
            MakePart_Accessor mc = new MakePart_Accessor(D2, connection.GetDB());
            mc.CreatePart();

            try
            {
                d.DeleteVehicle(111);
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteVehicle_ExistsInSale()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            Delete_Accessor d = new Delete_Accessor(connection.GetDB());

            TestingFunctions tf = new TestingFunctions(connection.GetDB());
            try
            {
                tf.DeleteSale("112", "121", "9");
            }
            catch (Exception e)
            {
            }
            try
            {
                d.DeleteVehicle(112);
            }
            catch (Exception e)
            {
            }
            String[] D = new String[] { "112", "1", "1", "1", "1", "1" };

            MakeVehicle_Accessor veh = new MakeVehicle_Accessor(D, connection.GetDB());
            veh.CreateVehicle();
            MakeCar_Accessor car = new MakeCar_Accessor("112", "smart car", connection.GetDB());
            car.CreateCar();

            String[] sale = new String[] { "112", "121", "9", "4/10/2008", "34000" };
            MakeSale sa = new MakeSale(sale, connection.GetDB());
            sa.CreateSale();

            try
            {
                d.DeleteVehicle(112);
            }
            catch (Exception ex)
            {
                try
                {
                    tf.DeleteSale("112", "121", "9");
                }
                catch (Exception e)
                {
                }

                throw ex;
            }
        }
    }
}
