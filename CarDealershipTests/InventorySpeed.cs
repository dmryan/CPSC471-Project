using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using CarDealership;
using System.Data.OleDb;
using System.IO;

namespace CarDealershipTests
{
    [TestClass]
    public class InventorySpeed
    {
     /*   [TestMethod]
        public void THETEST()
        {


            String time;
            time = DateTime.Now.ToString();

            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            MakeCar_Accessor mc;
            String[] D;

            for (int i = 20000; i < 21000; i++)
            {
                mc = new MakeCar_Accessor(i.ToString(), "sedan", db.GetDB());
                D = new String[] { i.ToString(), "123", "123", "123", "123", "123" };

                MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
                try
                {
                    d.DeleteVehicle(i);
                }
                catch (Exception)
                {

                }
                mp.CreateVehicle();
                mc.CreateCar();
            }


            DataTable bs = st.CarsInventory();


            

            for (int i = 20000; i < 21000; i++)
            {
                d.DeleteVehicle(i);
            }

            String time2;
            time2 = DateTime.Now.ToString();

            StreamWriter sw = new StreamWriter("C:/users/Nolan/Desktop/timelogs.txt");
            sw.WriteLine(time);
            sw.WriteLine(time2);
            sw.Close();


        }*/
    }
}
