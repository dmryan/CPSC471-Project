using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.OleDb;
using CarDealership;

namespace CarDealershipTests.Test_References
{
    [TestClass]
    public class SearchVHRTests
    {
        [TestMethod]
        public void SearchVHR_NormalPath()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();

            try
            {
                dt = SF.SearchVHR("121");
            }
            catch (OleDbException ex)
            {
            }

            Assert.IsTrue(dt.Rows.Count == 1);
        }

        [TestMethod]
        public void SearchVHR_NonExistent()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();

            try
            {
                dt = SF.SearchVHR("123456");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            Assert.IsTrue(dt.Rows.Count == 0);

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void SearchVHR_EmptyID()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();

            try
            {
                dt = SF.SearchVHR("");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
    }
}
