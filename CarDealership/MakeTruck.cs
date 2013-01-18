using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeTruck
    {
        /**
         * @param VIN           VIN of the Truck
         * @param TowingCapacity    Towing capacity of the Truck
         * @param cn            Connection to the database
         */
        private string VIN;
        private string TowingCapacity;
        private OleDbConnection cn;

        /**
         * Constructor that gets the connection to the database and Truck information
         * 
         * @param V             VIN of the Truck
         * @param T             Towing capacity of the Truck
         * @param cn            Connection to the database
         */
        public MakeTruck(string V, string T, OleDbConnection cn)
        {
            this.VIN = V;
            this.TowingCapacity = T;
            this.cn = cn;
        }

        /**
         * Creates a Truck
         */
        public void CreateTruck()
        {
            MakeQuery(MakeTruckSQLString()).ExecuteNonQuery();
        }

        /**
         * Creates a command that when executed will add a Truck to the database 
         * 
         * @param SQLString     SQL statement for adding a Truck to the database
         * @return insertTruck  Executable command for adding a Truck to the database
         */
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

        /**
         * Creates a SQL statement for adding a Truck to the database 
         * 
         * @return SQLString    SQL statement for adding a Truck to the database
         */
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
