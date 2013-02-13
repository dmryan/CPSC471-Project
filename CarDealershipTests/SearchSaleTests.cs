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
    public class SearchSaleTests
    {
        [TestMethod]
        public void SearchSale_NormalPath()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();
            TestingFunctions tf = new TestingFunctions(connection.GetDB());

            try
            {
                tf.DeleteSale("3", "121", "9");
            }
            catch (Exception e)
            {
            }


            String[] sale = new String[] { "3", "121", "9", "4/10/2008", "34000" };
            MakeSale sa = new MakeSale(sale, connection.GetDB());
            sa.CreateSale();

            try
            {
                dt = SF.SearchSale("9", "121", "3");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }


            Assert.IsTrue(dt.Rows.Count == 1);
            tf.DeleteSale("3", "121", "9");
        }

        [TestMethod]
        public void SearchSale_NonExistentEID()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();

            try
            {
                dt = SF.SearchSale("24", "121", "3");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }




            Assert.IsTrue(dt.Rows.Count == 0);

        }

        [TestMethod]
        public void SearchSale_NonExistentCID()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();

            try
            {
                dt = SF.SearchSale("9", "500", "3");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }




            Assert.IsTrue(dt.Rows.Count == 0);

        }
        [TestMethod]
        public void SearchSale_NonExistentVIN()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();

            try
            {
                dt = SF.SearchSale("9", "121", "2");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }




            Assert.IsTrue(dt.Rows.Count == 0);

        }

        [TestMethod]
        
        public void SearchSale_EmptyEID()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();


            try
            {
                dt = SF.SearchSale("", "121", "3");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            Assert.IsTrue(dt.Rows.Count == 0);

        }

        [TestMethod]
        
        public void SearchSale_EmptyCID()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();


            try
            {
                dt = SF.SearchSale("9", "", "3");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            Assert.IsTrue(dt.Rows.Count == 0);
        }

        [TestMethod]
        public void SearchSale_EmptyVIN()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();


            try
            {
                dt = SF.SearchSale("9", "121", "");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            Assert.IsTrue(dt.Rows.Count == 0);
        }
    }
}
