using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeVHR
    {
        /**
         * @param Data          Array of data for the VHR
         *                      VIN, # Owners, Rating, Mileage
         * @param cn            Connection to the database
         */
        private string[] Data;
        private OleDbConnection cn;
        /**
         * Constructor that gets the connection to the database and VHR information
         * 
         * @param Data          Array of data for the VHR
         * @param cn            Connection to the database
         */
        public MakeVHR(string[] D, OleDbConnection cn)
        {
            this.Data = D;
            this.cn = cn;
        }
        /**
         * Creates an instance of a VHR in the database
         */
        public void CreateVHR()
        {
            MakeQuery(MakeVHRSQLString()).ExecuteNonQuery();
        }
        /**
         * Creates a command that when executed will add a Truck to the database 
         * 
         * @param SQLString     SQL statement for adding a Truck to the database
         * @return insertVHR    Executable command for adding a Truck to the database
         */
        private OleDbCommand MakeQuery(string SQLString)
        {
            OleDbCommand insertVHR = cn.CreateCommand();
            insertVHR.CommandText = SQLString;

            if (Data[0].CompareTo("") != 0)
                insertVHR.Parameters.AddWithValue("@VIN", Data[0]);
            if (Data[1].CompareTo("") != 0)
                insertVHR.Parameters.AddWithValue("@NumberOwners", Data[1]);
            if (Data[2].CompareTo("") != 0)
                insertVHR.Parameters.AddWithValue("@Rating", Data[2]);
            if (Data[3].CompareTo("") != 0)
                insertVHR.Parameters.AddWithValue("@Mileage", Data[3]);

            return insertVHR;
        }
        /**
         * Creates a SQL statement for adding a History Report to the database 
         * 
         * @return SQLString    SQL statement for adding a VHR to the database
         */
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
