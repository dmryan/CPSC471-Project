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
    public class SearchPartTests
    {
        [TestMethod]
        public void SearchPart_NormalPath()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();



            try
            {
                dt = SF.SearchPart("6");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }


            
           
            Assert.IsTrue(dt.Rows.Count == 1);

        }

        [TestMethod]
        public void SearchPart_NonExistent()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();

            try
            {
                dt = SF.SearchPart("56456452");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            Assert.IsTrue(dt.Rows.Count == 0);

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void SearchPart_EmptySN()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();


            try
            {
                dt = SF.SearchPart("");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

        }
    }
    
}
