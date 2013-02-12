﻿using System;
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
    public class TruckInventoryTests
    {
        [TestMethod]
        public void TruckInventory_NormalPath()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            DataTable dt = new DataTable();
            dt = st.TrucksInventory();
            DataColumn[] dc = new DataColumn[] { dt.Columns[0] };
            dt.PrimaryKey = dc;

            Assert.IsTrue(dt.Rows.Contains("5"));

        }

        [TestMethod]
        public void TruckInventory_Sold()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            DataTable dt = new DataTable();
            dt = st.TrucksInventory();
            DataColumn[] dc = new DataColumn[] { dt.Columns[0] };
            dt.PrimaryKey = dc;

            Assert.IsFalse(dt.Rows.Contains("1"));

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TruckInventory_Empty()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            DataTable dt = new DataTable();
            dt = st.TrucksInventory();
            DataColumn[] dc = new DataColumn[] { dt.Columns[0] };
            dt.PrimaryKey = dc;


            Assert.IsTrue(dt.Rows.Contains(" "));


        }
    }
}
