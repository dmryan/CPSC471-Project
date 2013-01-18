using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeVehicle
    {
        /**
         * @param Data          Array of data for the Vehicle
         * @param cn            Connection to the database
         */
        private string[] Data;
        private OleDbConnection cn;

        /**
         * Constructor that gets the connection to the database and Vehicle information
         * 
         * @param D             Array of data for the Vehicle
         * @param cn            Connection to the database
         */
        public MakeVehicle(string[] D, OleDbConnection cn)
        {
            this.Data = D;
            this.cn = cn;
        }

        /**
         * Creates a Vehicle
         */
        public void CreateVehicle()
        {
            MakeQuery(MakeVehicleSQLString()).ExecuteNonQuery();
        }

        /**
         * Creates a command that when executed will add a Vehicle to the database 
         * 
         * @param SQLString     SQL statement for adding a Vehicle to the database
         * @return insertVehicle    Executable command for adding a Vehicle to the database
         */
        private OleDbCommand MakeQuery(string SQLString)
        {
            OleDbCommand insertVehicle = cn.CreateCommand();
            insertVehicle.CommandText = SQLString;

            if (Data[0].CompareTo("") != 0)
            {
                insertVehicle.Parameters.AddWithValue("@VIN", Data[0]);
            }
            if (Data[1].CompareTo("") != 0)
            {
                insertVehicle.Parameters.AddWithValue("@Model", Data[1]);
            }
            if (Data[2].CompareTo("") != 0)
            {
                insertVehicle.Parameters.AddWithValue("@YearProd", Data[2]);
            }
            if (Data[3].CompareTo("") != 0)
            {
                insertVehicle.Parameters.AddWithValue("@Maker", Data[3]);
            }
            if (Data[4].CompareTo("") != 0)
            {
                insertVehicle.Parameters.AddWithValue("@NumberSeats", Data[4]);
            }
            if (Data[5].CompareTo("") != 0)
            {
                insertVehicle.Parameters.AddWithValue("@Price", Data[5]);
            }
            insertVehicle.Parameters.AddWithValue("@Sold", false);

            return insertVehicle;
        }

        /**
         * Creates a SQL statement for adding a Vehicle to the database 
         * 
         * @return SQLString    SQL statement for adding a Vehicle to the database
         */
        private string MakeVehicleSQLString()
        {
            string SQLString;
            string VehicleInsert = "INSERT INTO Vehicle(VIN";
            string InsertValues = " Values (@VIN";

            if (Data[1].CompareTo("") != 0)
            {
                VehicleInsert += ", Model";
                InsertValues += ", @Model";
            }
            if (Data[2].CompareTo("") != 0)
            {
                VehicleInsert += ", YearProd";
                InsertValues += ", @YearProd";
            }
            if (Data[3].CompareTo("") != 0)
            {
                VehicleInsert += ", Maker";
                InsertValues += ", @Maker";
            }
            if (Data[4].CompareTo("") != 0)
            {
                VehicleInsert += ", NumberSeats";
                InsertValues += ", @NumberSeats";
            }
            if (Data[5].CompareTo("") != 0)
            {
                VehicleInsert += ", Price";
                InsertValues += ", @Price";
            }

            SQLString = VehicleInsert;
            SQLString += ", Sold";
            SQLString += ")";
            SQLString += InsertValues;
            SQLString += ", @Sold";
            SQLString += ")";

            return SQLString;
        }
    }
}
