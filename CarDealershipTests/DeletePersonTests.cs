﻿using System;
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
    public class DeletePersonTests
    {
        [TestMethod]
        public void DeletePerson_NormalPath()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();
            Delete_Accessor d = new Delete_Accessor(connection.GetDB());
            try
            {
                d.DeletePerson(1005);
            }
            catch (Exception e)
            {
            }
            String[] p = new String[] {"1005", "1", "1123123123", "1", "M"};
            MakePerson_Accessor pers = new MakePerson_Accessor(p, connection.GetDB());
            pers.CreatePerson();
            MakeEmployee_Accessor person = new MakeEmployee_Accessor("1005", "1234", "3/3/3", "", connection.GetDB());

            person.CreateEmployee();


            d.DeletePerson(1005);

            try
            {
                dt = SF.SearchPersonID("1005");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            Assert.IsTrue(dt.Rows.Count == 0);
            

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeletePerson_NonExistent()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            

            Delete_Accessor d = new Delete_Accessor(connection.GetDB());

            try
            {
                d.DeletePerson(2);
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeletePerson_Empty()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();


            Delete_Accessor d = new Delete_Accessor(connection.GetDB());

            try
            {
                d.DeletePerson(new int());
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
        }

    }
}
