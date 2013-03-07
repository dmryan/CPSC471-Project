using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarDealership;
using System.Data.OleDb;

namespace CarDealershipTests
{
    [TestClass]
    public class AddSaleTests
    {
        [TestMethod]
        public void AddSale_NormalPath()
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

            try
            {
                tf.DeleteSale("3", "121", "9");
            }
            catch (Exception e)
            {
            }
        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddSale_EIDNonExistent()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());
            try
            {
                tf.DeleteSale("3", "121", "99999");
            }
            catch (Exception e)
            {
            }

            String[] sale = new String[] { "3", "121", "99999", "4/10/2008", "34000" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();

            try
            {
                tf.DeleteSale("3", "121", "99999");
            }
            catch (Exception e)
            {
            }
        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddSale_CIDNonExistent()
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

            String[] sale = new String[] { "3", "99999", "9", "4/10/2008", "34000" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();

            try
            {
                tf.DeleteSale("3", "99999", "0");
            }
            catch (Exception e)
            {
            }
        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddSale_VINNonExistent()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());
            try
            {
                tf.DeleteSale("99999", "121", "9");
            }
            catch (Exception e)
            {
            }

            String[] sale = new String[] { "99999", "121", "9", "4/10/2008", "34000" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();

            try
            {
                tf.DeleteSale("99999", "121", "9");
            }
            catch (Exception e)
            {
            }
        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddSale_NullEID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());

            String[] sale = new String[] { "3", "121", "", "4/10/2008", "34000" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();
        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddSale_NullCID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());

            String[] sale = new String[] { "3", "", "9", "4/10/2008", "34000" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();
        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddSale_NullVIN()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());

            String[] sale = new String[] { "", "121", "9", "4/10/2008", "34000" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();
        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddSale_Duplicate()
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
            sa.CreateSale();

            try
            {
                tf.DeleteSale("3", "121", "9");
            }
            catch (Exception e)
            {
            }
        }
    }
}
