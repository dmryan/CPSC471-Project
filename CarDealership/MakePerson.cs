using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakePerson
    {
        private string[] Data;
        private OleDbConnection cn;
        public MakePerson(string[] D, OleDbConnection cn)
        {
            this.Data = D;
            this.cn = cn;
        }
        public void CreatePerson()
        {
            MakeQuery(MakePersonSQLString()).ExecuteNonQuery();
        }
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
