using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarDealership;
using System.Data.OleDb;
using System.Data;


namespace CarDealershipTests
{
    [TestClass]
    public class SearchPersonIDTests
    {
        [TestMethod]
        public void SearchID_NormalPath()
        {
            //Person array = id, name, phone no, address, sex
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();
            //String[] p = new String[] {"1", "1", "1", "1", "1"};


            /*
            MakePerson_Accessor Person = new MakePerson_Accessor(p, connection.GetDB());
            Person.DeletePerson();
            Person.CreatePerson();
            */
            try
            {
                dt = SF.SearchPersonID("3");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
           
            Assert.IsTrue(dt.Rows.Count == 1);

            //Person.DeletePerson();
        }

        [TestMethod]
        public void SearchID_NonExistent()
        {
            //Person array = id, name, phone no, address, sex
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();
            //String[] p = new String[] { "1", "1", "1", "1", "1" };



            //MakePerson_Accessor Person = new MakePerson_Accessor(p, connection.GetDB());
            //Person.DeletePerson();
            //Person.CreatePerson();

            try
            {
                dt = SF.SearchPersonID("2");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }




            Assert.IsTrue(dt.Rows.Count == 0);

            //Person.DeletePerson();
        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void SearchID_EmptyID()
        {
            //Person array = id, name, phone no, address, sex
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();
            //String[] p = new String[] { "1", "1", "1", "1", "1" };



            //MakePerson_Accessor Person = new MakePerson_Accessor(p, connection.GetDB());
            //Person.DeletePerson();
            //Person.CreatePerson();

            try
            {
                dt = SF.SearchPersonID("");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }


            

            //Person.DeletePerson();
        }
    }
}
