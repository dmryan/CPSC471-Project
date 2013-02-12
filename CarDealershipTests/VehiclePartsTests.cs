using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.OleDb;
using CarDealership;

namespace CarDealershipTests
{
    [TestClass]
    public class VehiclePartsTests
    {
        [TestMethod]
        public void VehicleParts_NoParts()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            DataTable dt = st.VehicleParts("3");

            Assert.IsTrue(dt.Rows.Count == 0);
        }

        [TestMethod]
        public void VehicleParts_OnePart()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            DataTable dt = st.VehicleParts("8");

            Assert.IsTrue(dt.Rows.Count == 1);
        }

        [TestMethod]
        public void VehicleParts_TwoParts()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            DataTable dt = st.VehicleParts("9");

            Assert.IsTrue(dt.Rows.Count == 2);
        }

        [TestMethod]
        public void VehicleParts_NoVehicle()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            DataTable dt = st.VehicleParts("2");
            Assert.IsTrue(dt.Rows.Count == 0);
        }

        [TestMethod]
        public void VehicleParts_Empty()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            DataTable dt = st.VehicleParts("");
            Assert.IsTrue(dt.Rows.Count == 0);
        }



    }
}
