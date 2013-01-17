using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeTruck
    {
        private string VIN;
        private string TowingCapacity;
        private OleDbConnection cn;
        public MakeTruck(string V, string T, OleDbConnection cn)
        {
            this.VIN = V;
            this.TowingCapacity = T;
            this.cn = cn;
        }
        public void CreateTruck()
        {
            MakeQuery(MakeTruckSQLString()).ExecuteNonQuery();
        }
        private OleDbCommand MakeQuery(string SQLString)
        {
            OleDbCommand insertTruck = cn.CreateCommand();
            insertTruck.CommandText = SQLString;

            if (VIN.CompareTo("") != 0)
            {
                insertTruck.Parameters.AddWithValue("@VIN", VIN);
            }
            if (TowingCapacity.CompareTo("") != 0)
            {
                insertTruck.Parameters.AddWithValue("@TowingCapacity", TowingCapacity);
            }

            return insertTruck;
        }
        private string MakeTruckSQLString()
        {
            string SQLString;
            string InsertTruck = "INSERT INTO Truck(VIN";
            string InsertValues = " VALUES (@VIN";

            if (TowingCapacity.CompareTo("") != 0)
            {
                InsertTruck += ", TowingCapacity";
                InsertValues += ", @TowingCapacity";
            }

            SQLString = InsertTruck;
            SQLString += ")";
            SQLString += InsertValues;
            SQLString += ")";

            return SQLString;
        }
    }
}
