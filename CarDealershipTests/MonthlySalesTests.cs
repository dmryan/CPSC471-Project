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
    public class MonthlySalesTests
    {
        [TestMethod]
        public void MonthlySales_NoSalesValidMonth()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            string s = st.MonthlySales("1", "2001");
            Assert.IsTrue(int.Parse(s) == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlySales_InvalidMonth()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            try
            {
                String s = st.MonthlySales("233", "2008");
            }
            catch (ArgumentException ae)
            {
                throw ae;  
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthlySales_InvalidYear()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            try
            {
                String s = st.MonthlySales("3", "-39");
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
        }

        [TestMethod]
        public void MonthlySales_OneSale()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());
            try
            {
                tf.DeleteSale("3", "121", "9");
            }
            catch (Exception e)
            {
            }
            

            String[] sale = new String[] { "3", "121", "9", "4/10/2008", "34000" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();

            String s = st.MonthlySales("4", "2008");
            Assert.IsTrue(int.Parse(s) == 34000);

            tf.DeleteSale("3", "121", "9");
        }

        [TestMethod]
        public void MonthlySales_OneSaleWrongDate()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());
            try
            {
                tf.DeleteSale("3", "121", "9");
            }
            catch (Exception e)
            {
            }

            String[] sale = new String[] { "3", "121", "9", "4/10/2008", "34000" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();

            String s = st.MonthlySales("11", "2003");
            Assert.IsTrue(int.Parse(s) == 0);

            tf.DeleteSale("3", "121", "9");
        }

        [TestMethod]
        public void MonthlySales_TwoSales()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());
            try
            {
                tf.DeleteSale("3", "121", "9");
                tf.DeleteSale("5", "121", "9");
            }
            catch (Exception e)
            {
            }


            String[] sale = new String[] { "3", "121", "9", "4/10/2008", "34000" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();

            String[] sale2 = new String[] { "5", "121", "9", "4/10/2008", "34000" };
            MakeSale sa2 = new MakeSale(sale2, db.GetDB());
            sa2.CreateSale();

            String s = st.MonthlySales("4", "2008");
            Assert.IsTrue(int.Parse(s) == 68000);

            tf.DeleteSale("3", "121", "9");
            tf.DeleteSale("5", "121", "9");

        }

        [TestMethod]
        public void MonthlySales_TwoSalesWrongDate()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());
            try
            {
                tf.DeleteSale("3", "121", "9");
                tf.DeleteSale("5", "121", "9");
            }
            catch (Exception e)
            {
            }

            String[] sale = new String[] { "3", "121", "9", "4/10/2008", "34567" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();

            String[] sale2 = new String[] { "5", "121", "9", "4/10/2009", "34000" };
            MakeSale sa2 = new MakeSale(sale2, db.GetDB());
            sa2.CreateSale();

            String s = st.MonthlySales("4", "2008");
            Assert.IsTrue(int.Parse(s) == 34567);

            tf.DeleteSale("3", "121", "9");
            tf.DeleteSale("5", "121", "9");
        }
    }
}
