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
        public void Search_NormalPath()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();



            try
            {
                dt = SF.SearchSale("9", "121", "3");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }




            Assert.IsTrue(dt.Rows.Count == 1);

        }

        [TestMethod]
        public void Search_NonExistentEID()
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
        public void Search_NonExistentCID()
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
        public void Search_NonExistentVIN()
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
        
        public void Search_EmptyEID()
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
        
        public void Search_EmptyCID()
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
        public void Search_EmptyVIN()
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
