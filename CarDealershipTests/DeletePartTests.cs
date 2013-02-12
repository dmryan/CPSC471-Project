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
    public class DeletePartTests
    {
        [TestMethod]
        public void DeleteVehicle_NormalPath()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();
            Delete_Accessor d = new Delete_Accessor(connection.GetDB());
            try
            {
                d.DeletePart(10);
            }
            catch (Exception e)
            {
            }
            
            String[] D = new String[] {"10"};
            MakePart_Accessor part = new MakePart_Accessor(D, connection.GetDB());
            part.CreatePart();


            d.DeletePart(10);

            try
            {
                dt = SF.SearchPart("10");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            Assert.IsTrue(dt.Rows.Count == 0);


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeletePart_NonExistent()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();


            Delete_Accessor d = new Delete_Accessor(connection.GetDB());

            try
            {
                d.DeletePart(10);
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeletePart_Empty()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();


            Delete_Accessor d = new Delete_Accessor(connection.GetDB());

            try
            {
                d.DeletePart(int.Parse(""));
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }
    }
}
