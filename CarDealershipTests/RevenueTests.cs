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

        //vin cid eid date price
        [TestMethod]
        public void RevenueTest_OneSale()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());
            tf.DeleteSale("3", "121", "9");

            String[] sale = new String[] { "3", "121", "9", "3/3/3", "1200" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();
            
            String s = st.Revenue();

            Assert.IsTrue(int.Parse(s) == 1200);

            

            tf.DeleteSale("3", "121", "9");

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
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());
            tf.DeleteSale("3", "121", "9");
            tf.DeleteSale("7", "121", "9");

            String[] sale = new String[] { "3", "121", "9", "3/3/3", "1200" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();

            String[] sale2 = new String[] { "7", "121", "9", "3/3/3", "1200" };
            MakeSale sa2 = new MakeSale(sale2, db.GetDB());
            sa2.CreateSale();

            String s = st.Revenue();

            Assert.IsTrue(int.Parse(s) == 2400);


            tf.DeleteSale("3", "121", "9");
            tf.DeleteSale("7", "121", "9");
        }

        [TestMethod]
        public void RevenueTest_DecimalSales()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());
            tf.DeleteSale("3", "121", "9");
            tf.DeleteSale("7", "121", "9");


            String[] sale = new String[] { "3", "121", "9", "3/3/3", "1200.3" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();

            String[] sale2 = new String[] { "7", "121", "9", "3/3/3", "1200.75" };
            MakeSale sa2 = new MakeSale(sale2, db.GetDB());
            sa2.CreateSale();

            String s = st.Revenue();

            Assert.IsTrue(double.Parse(s) == 2401.05);
            
            tf.DeleteSale("3", "121", "9");
            tf.DeleteSale("7", "121", "9");
        }
    }
}
