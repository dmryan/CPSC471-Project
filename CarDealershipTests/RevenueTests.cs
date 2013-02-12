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
    public class RevenueTests
    {
        [TestMethod]
        public void RevenueTest_OneSale()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            String s = st.Revenue();

            Assert.IsTrue(int.Parse(s) > 0);
        }

        [TestMethod]
        public void RevenueTest_NoSale()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            String s = st.Revenue();

            Assert.IsTrue(int.Parse(s) == 0);
        }

        [TestMethod]
        public void RevenueTest_MultipleSales()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            String s = st.Revenue();

            Assert.IsTrue(int.Parse(s) > 0);
        }

        [TestMethod]
        public void RevenueTest_DecimalSales()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            String s = st.Revenue();

            Assert.IsTrue(double.Parse(s) > 0);
        }
    }
}
