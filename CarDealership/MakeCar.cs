using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeCar
    {
        public MakeCar()
        {

        }
        public OleDbCommand MakeQuery(string SQLString, string VIN, string Type, OleDbConnection cn)
        {
            OleDbCommand insertCar = cn.CreateCommand();
            insertCar.CommandText = SQLString;

            if (VIN.CompareTo("") != 0)
            {
                insertCar.Parameters.AddWithValue("@VIN", VIN);
            }
            if (Type.CompareTo("") != 0)
            {
                insertCar.Parameters.AddWithValue("@Type", Type);
            }

            return insertCar;
        }
        public string MakeCarSQLString(string Type)
        {
            string SQLString;
            string InsertCar = "INSERT INTO Car(VIN";
            string InsertValues = " VALUES (@VIN";

            if (Type.CompareTo("") != 0)
            {
                InsertCar += ", Model";
                InsertValues += ", @Model";
            }

            SQLString = InsertCar;
            SQLString += ")";
            SQLString += InsertValues;
            SQLString += ")";

            return SQLString;
        }
    }
}
