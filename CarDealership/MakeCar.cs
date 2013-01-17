using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeCar
    {
        private string VIN;
        private string Type;
        private OleDbConnection cn;
        public MakeCar(string V, string T, OleDbConnection cn)
        {
            this.VIN = V;
            this.Type = T;
            this.cn = cn;
        }
        public void CreateCar()
        {
            MakeQuery(MakeCarSQLString()).ExecuteNonQuery();
        }
        private OleDbCommand MakeQuery(string SQLString)
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
        private string MakeCarSQLString()
        {
            string SQLString;
            string InsertCar = "INSERT INTO Car(VIN";
            string InsertValues = " VALUES (@VIN";

            if (Type.CompareTo("") != 0)
            {
                InsertCar += ", Type";
                InsertValues += ", @Type";
            }

            SQLString = InsertCar;
            SQLString += ")";
            SQLString += InsertValues;
            SQLString += ")";

            return SQLString;
        }
    }
}
