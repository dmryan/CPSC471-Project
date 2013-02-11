using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakePerson
    {
        /**
         * @param Data          Array of data for the Person
         * @param cn            Connection to the database
         */
        private string[] Data;
        private OleDbConnection cn;

        /**
         * Constructor that gets the connection to the database and Person information
         * 
         * @param D             Array of data for the Person
         * @param cn            Connection to the database
         */
        public MakePerson(string[] D, OleDbConnection cn)
        {
            this.Data = D;
            this.cn = cn;
        }

        /**
         * Creates an instance of a Person in the database
         */
        public void CreatePerson()
        {
            MakeQuery(MakePersonSQLString()).ExecuteNonQuery();
        }

        /**
         * Deletes an instance of the Person from the database
         */
        public void DeletePerson()
        {
            OleDbCommand deletePerson = cn.CreateCommand();
            deletePerson.CommandText = ("DELETE FROM PERSON WHERE ID =" + Data[0]);
            deletePerson.ExecuteNonQuery();
        }

        /**
         * Creates a command that when executed will add a Person to the database 
         * 
         * @param SQLString     SQL statement for adding a Person to the database
         * @return insertPerson     Executable command for adding a Person to the database
         */
        private OleDbCommand MakeQuery(string SQLString)
        {
            OleDbCommand insertPerson = cn.CreateCommand();
            insertPerson.CommandText = SQLString;

            if (Data[0].CompareTo("") != 0)
            {
                insertPerson.Parameters.AddWithValue("@ID", Data[0]);
            }
            if (Data[1].CompareTo("") != 0)
            {
                insertPerson.Parameters.AddWithValue("@PersonName", Data[1]);
            }
            if (Data[2].CompareTo("") != 0)
            {
                insertPerson.Parameters.AddWithValue("@PhoneNumber", Data[2]);
            }
            if (Data[3].CompareTo("") != 0)
            {
                insertPerson.Parameters.AddWithValue("@Address", Data[3]);
            }
            if (Data[4].CompareTo("") != 0)
            {
                insertPerson.Parameters.AddWithValue("@Sex", Data[4]);
            }

            return insertPerson;
        }

        /**
         * Creates a SQL statement for adding a Person to the database 
         * 
         * @return SQLString    SQL statement for adding a Person to the database
         */
        private string MakePersonSQLString()
        {
            string SQLString;
            string InsertPerson = "INSERT INTO Person(ID";
            string InsertValues = " Values (@ID";

            if (Data[1].CompareTo("") != 0)
            {
                InsertPerson += ", PersonName";
                InsertValues += ", @PersonName";
            }
            if (Data[2].CompareTo("") != 0)
            {
                InsertPerson += ", PhoneNumber";
                InsertValues += ", @PhoneNumber";
            }
            if (Data[3].CompareTo("") != 0)
            {
                InsertPerson += ", Address";
                InsertValues += ", @Address";
            }
            if (Data[4].CompareTo("") != 0)
            {
                InsertPerson += ", Sex";
                InsertValues += ", @Sex";
            }
            SQLString = InsertPerson;
            SQLString += ")";
            SQLString += InsertValues;
            SQLString += ")";

            return SQLString;
        }
    }
}
