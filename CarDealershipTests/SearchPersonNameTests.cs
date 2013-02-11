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
    public class SearchPersonNameTests
    {
        [TestMethod]
        public void SearchName_NormalPath()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();

            try
            {
                dt = SF.SearchPersonName("hi there");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
           
            Assert.IsTrue(dt.Rows.Count == 1);
        }

        [TestMethod]
        public void SearchName_NonExistent()
        {
            //person array = id, name, phone no, address, sex
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();
            //String[] p = new String[] { "1", "1", "1", "1", "1" };



            //MakePerson_Accessor person = new MakePerson_Accessor(p, connection.GetDB());
            //person.DeletePerson();
            //person.CreatePerson();

            try
            {
                dt = SF.SearchPersonName("dyrone tonkson");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }




            Assert.IsTrue(dt.Rows.Count == 0);

            //person.DeletePerson();
        }

        [TestMethod]
        
        public void SearchName_EmptyName()
        {
            //person array = id, name, phone no, address, sex
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();
            //String[] p = new String[] { "1", "1", "1", "1", "1" };



            //MakePerson_Accessor person = new MakePerson_Accessor(p, connection.GetDB());
            //person.DeletePerson();
            //person.CreatePerson();

            try
            {
                dt = SF.SearchPersonName("");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            Assert.IsTrue(dt.Rows.Count == 0);

            

            //person.DeletePerson();
        }
    }
}
