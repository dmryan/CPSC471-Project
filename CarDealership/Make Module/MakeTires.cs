using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeTires
    {
        /**
         * @param SerialNumber          Tire's serial number
         * @param Type                  Tire's type
         * @param TireSize              Tire's radius
         * @param cn                    Database connection
       */
        private string SerialNumber;
        private string Type;
        private string TireSize;
        private OleDbConnection cn;

        /**
         * Constructor that gets the connection to the database and Car information
         * 
         * @param V             VIN of the Car
         * @param T             Type of the Car
         * @param cn            Connection to the database
         */
        public MakeTires(string S, string T, string TS, OleDbConnection cn)
        {
            this.SerialNumber = S;
            this.Type = T;
            this.TireSize = TS;
            this.cn = cn;
        }

        /**
         * Creates an instance of a Car in the database
         */
        public void CreateTires()
        {
            MakeQuery(MakeTiresSQLString()).ExecuteNonQuery();
        }

        /**
         * Deletes an instance of a Car from the database
         */
        public void DeleteCar()
        {
            OleDbCommand deleteCar = cn.CreateCommand();
            deleteCar.CommandText = ("DELETE FROM Tire WHERE SerialNumber =" + SerialNumber);
            deleteCar.ExecuteNonQuery();
        }

        /**
         * Creates a command that when executed will add a Car to the database 
         * 
         * @param SQLString     SQL statement for adding a Car to the database
         * @return insertCar    Executable command for adding a Car to the database
         */
        private OleDbCommand MakeQuery(string SQLString)
        {
            OleDbCommand InsertTires = cn.CreateCommand();
            InsertTires.CommandText = SQLString;

            if (SerialNumber.CompareTo("") != 0)
            {
                InsertTires.Parameters.AddWithValue("@SerialNumber", SerialNumber);
            }
            if (Type.CompareTo("") != 0)
            {
                InsertTires.Parameters.AddWithValue("@Type", Type);
            }
            if (TireSize.CompareTo("") != 0)
            {
                InsertTires.Parameters.AddWithValue("@TireSize", TireSize);
            }

            return InsertTires;
        }

        /**
         * Creates a SQL statement for adding a Car to the database 
         * 
         * @return SQLString    SQL statement for adding a Car to the database
         */
        private string MakeTiresSQLString()
        {
            string SQLString;
            string InsertTires = "INSERT INTO Tire(SerialNumber";
            string InsertValues = " VALUES (@SerialNumber";

            if (Type.CompareTo("") != 0)
            {
                InsertTires += ", Type";
                InsertValues += ", @Type";
            }
            if (TireSize.CompareTo("") != 0)
            {
                InsertTires += ", TireSize";
                InsertValues += ", @TireSize";
            }

            SQLString = InsertTires;
            SQLString += ")";
            SQLString += InsertValues;
            SQLString += ")";

            return SQLString;
        }
    }
}
