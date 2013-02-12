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
    public class DeletePersonTests
    {
        [TestMethod]
        public void DeletePerson_NormalPath()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            SearchFunction_Accessor SF = new SearchFunction_Accessor(connection.GetDB());
            DataTable dt = new DataTable();

            String[] p = new String[] {"1", "1", "1", "1", "1"};
            MakePerson_Accessor pers = new MakePerson_Accessor(p, connection.GetDB());
            pers.CreatePerson();
            MakeEmployee_Accessor person = new MakeEmployee_Accessor("1", "1234", "3/3/3", "", connection.GetDB());

            person.CreateEmployee();

            Delete_Accessor d = new Delete_Accessor(connection.GetDB());

            d.DeletePerson(1);

            try
            {
                dt = SF.SearchPersonID("1");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            Assert.IsTrue(dt.Rows.Count == 0);
            
        }

        [TestMethod]
        public void DeletePerson_NonExistent()
        {/*
            DBConnection_Accessor connection = new DBConnection_Accessor();

            Delete_Accessor d = new Delete_Accessor(connection.GetDB());

            try
            {
                d.DeletePerson(2);
            }
            catch (OleDbException ex)
            {
                throw ex;
            }*/
        }

    }
}
