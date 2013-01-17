using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeVHR
    {
        private string[] Data;
        private OleDbConnection cn;
        public MakeVHR(string[] D, OleDbConnection cn)
        {
            this.Data = D;
            this.cn = cn;
        }
        public void CreatePerson()
        {
            MakeQuery(MakeVHRSQLString()).ExecuteNonQuery();
        }
        private OleDbCommand MakeQuery(string SQLString)
        {
            OleDbCommand insertPerson = cn.CreateCommand();
            insertPerson.CommandText = SQLString;

            if (Data[0].CompareTo("") != 0)
                insertPerson.Parameters.AddWithValue("@VIN", Data[0]);
            if (Data[1].CompareTo("") != 0)
                insertPerson.Parameters.AddWithValue("@NumberOwners", Data[1]);
            if (Data[2].CompareTo("") != 0)
                insertPerson.Parameters.AddWithValue("@Rating", Data[2]);
            if (Data[3].CompareTo("") != 0)
                insertPerson.Parameters.AddWithValue("@Mileage", Data[3]);

            return insertPerson;
        }
        private string MakeVHRSQLString()
        {
            string SQLString;
            string InsertVHR = "INSERT INTO VehicleHistoryReport(VIN";
            string InsertValues = " Values (@VIN";

            if (Data[1].CompareTo("") != 0)
            {
                InsertVHR += ", NumberOwners";
                InsertValues += ", @NumberOwners";
            }
            if (Data[2].CompareTo("") != 0)
            {
                InsertVHR += ", Rating";
                InsertValues += ", @Rating";
            }
            if (Data[3].CompareTo("") != 0)
            {
                InsertVHR += ", Mileage";
                InsertValues += ", @Mileage";
            }

            SQLString = InsertVHR;
            SQLString += ")";
            SQLString += InsertValues;
            SQLString += ")";

            return SQLString;
        }
    }
}
