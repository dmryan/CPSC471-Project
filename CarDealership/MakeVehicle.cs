using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeVehicle
    {
        public void MakeVehicle()
        {

        }
        public OleDbCommand MakeQuery(string SQLString, string[] Data, OleDbConnection cn)
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
        public string MakeVehicleSQLString(string[] Data)
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
