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
    public class SearchVehicleTests
    {
        [TestMethod]
        public void SearchVehicle_NormalPath()
        {
            
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();
            

            try
            {
                dt = SF.SearchVehicle("3");
            }
            catch (OleDbException ex)
            {
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }


            
           
            Assert.IsTrue(dt.Rows.Count == 1);

        }

        [TestMethod]
        public void SearchVehicle_NonExistent()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();


            try
            {
                dt = SF.SearchVehicle("2");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }




            Assert.IsTrue(dt.Rows.Count == 0);

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void SearchVehicle_EmptyID()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();


            try
            {
                dt = SF.SearchVehicle("");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }


        }
    
    }
}
