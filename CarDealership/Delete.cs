﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class Delete
    {
        /**
         * @param cn        Database connection
         */
        private OleDbConnection cn;

        /*
         * Constructor that use the database connection
         * 
         * @param cn        Database connection
         */
        public Delete(OleDbConnection cn)
        {
            this.cn = cn;
        }

        /*
         * Deletes the person with the given ID
         * 
         * @param KeyNum
         */
        public void DeletePerson(int KeyNum)
        {
                OleDbCommand deletePerson = cn.CreateCommand();
                OleDbCommand deleteEmployee = cn.CreateCommand();
                OleDbCommand deleteCustomer = cn.CreateCommand();
                OleDbCommand selectPerson = cn.CreateCommand();

                deletePerson.CommandText = ("DELETE FROM Person WHERE ID =" + KeyNum);
                deleteEmployee.CommandText = ("DELETE FROM Employee WHERE EID =" + KeyNum);
                deleteCustomer.CommandText = ("DELETE FROM Customer WHERE CID =" + KeyNum);
                selectPerson.CommandText = ("SELECT ID FROM Person WHERE ID = @ID");

                selectPerson.Parameters.AddWithValue("@ID", KeyNum);

                if (selectPerson.ExecuteScalar() == null)
                {
                    throw new System.ArgumentException("Person does not exist", "ID");
                    return;
                }

                deleteEmployee.ExecuteNonQuery();
                deleteCustomer.ExecuteNonQuery();
                deletePerson.ExecuteNonQuery();
        }

        /*
         * Deletes vehicles with the given VIN
         * 
         * @param KeyNum
         */
        public void DeleteVehicle(int KeyNum)
        {
            OleDbCommand deleteVehicle = cn.CreateCommand();
            OleDbCommand deleteVHR = cn.CreateCommand();
            OleDbCommand deleteCar = cn.CreateCommand();
            OleDbCommand deleteTruck = cn.CreateCommand();
            OleDbCommand selectSale = cn.CreateCommand();
            OleDbCommand selectPart = cn.CreateCommand();
            OleDbCommand selectVehicle = cn.CreateCommand();

            deleteVHR.CommandText = ("DELETE FROM VehicleHistoryReport WHERE VIN =" + KeyNum);
            deleteVehicle.CommandText = ("DELETE FROM Vehicle WHERE VIN =" + KeyNum);
            deleteCar.CommandText = ("DELETE FROM Car WHERE VIN =" + KeyNum);
            deleteTruck.CommandText = ("DELETE FROM Truck WHERE VIN =" + KeyNum);
            selectVehicle.CommandText = ("SELECT VIN FROM Vehicle WHERE VIN = @VIN");
            selectSale.CommandText = "SELECT VIN FROM Sale WHERE VIN = @VIN";
            selectPart.CommandText = "SELECT VIN FROM Part WHERE VIN = @VIN";

            selectVehicle.Parameters.AddWithValue("@VIN", KeyNum);
            selectSale.Parameters.AddWithValue("@VIN", KeyNum);
            selectPart.Parameters.AddWithValue("@VIN", KeyNum);


            if (selectVehicle.ExecuteScalar() == null)
            {
                throw new System.ArgumentException("Vehicle does not exist", "VIN");
                return;
            }

            if (selectSale.ExecuteScalar() != null || selectPart.ExecuteScalar() != null)
            {
                throw new System.ArgumentException("Vehicle exists in another entity", "VIN");
                return;
            }

            deleteCar.ExecuteNonQuery();
            deleteTruck.ExecuteNonQuery();
            deleteVHR.ExecuteNonQuery();
            deleteVehicle.ExecuteNonQuery();
        }

        /*
         * Deletes parts with the given SN
         * 
         * @param KeyNum
         */
        public void DeletePart(int KeyNum)
        {
                OleDbCommand deletePart = cn.CreateCommand();
                OleDbCommand deleteEngine = cn.CreateCommand();
                OleDbCommand deleteTire = cn.CreateCommand();
                OleDbCommand selectPart = cn.CreateCommand();

                deletePart.CommandText = ("DELETE FROM Part WHERE SerialNumber =" + KeyNum);
                deleteEngine.CommandText = ("DELETE FROM Engine WHERE SerialNumber =" + KeyNum);
                deleteTire.CommandText = ("DELETE FROM Tire WHERE SerialNumber =" + KeyNum);
                selectPart.CommandText = ("SELECT SerialNumber FROM Part WHERE SerialNumber = @SerialNumber");

                selectPart.Parameters.AddWithValue("@SerialNumber", KeyNum);

                if (selectPart.ExecuteScalar() == null)
                {
                    throw new System.ArgumentException("Part does not exist", "Serial Number");
                }

                deleteEngine.ExecuteNonQuery();
                deleteTire.ExecuteNonQuery();
                deletePart.ExecuteNonQuery();
            }
    }
}
