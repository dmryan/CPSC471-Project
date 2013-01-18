using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeEngine
    {
        private string SerialNumber;
        private string HorsePower;
        private string Cylinders;
        private OleDbConnection cn;

        /**
         * Constructor that gets the connection to the database and Car information
         * 
         * @param V             VIN of the Car
         * @param T             Type of the Car
         * @param cn            Connection to the database
         */
        public MakeEngine(string S, string HP, string C, OleDbConnection cn)
        {
            this.SerialNumber = S;
            this.HorsePower = HP;
            this.Cylinders = C;
            this.cn = cn;
        }

        /**
         * Creates an instance of a Car in the database
         */
        public void CreateEngine()
        {
            MakeQuery(MakeEngineSQLString()).ExecuteNonQuery();
        }

        /**
         * Deletes an instance of a Car from the database
         */
        public void DeleteEngine()
        {
            OleDbCommand deleteCar = cn.CreateCommand();
            deleteCar.CommandText = ("DELETE FROM Engine WHERE SerialNumber =" + SerialNumber);
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
            OleDbCommand InsertEngine = cn.CreateCommand();
            InsertEngine.CommandText = SQLString;

            if (SerialNumber.CompareTo("") != 0)
            {
                InsertEngine.Parameters.AddWithValue("@SerialNumber", SerialNumber);
            }
            if (HorsePower.CompareTo("") != 0)
            {
                InsertEngine.Parameters.AddWithValue("@HorsePower", HorsePower);
            }
            if (Cylinders.CompareTo("") != 0)
            {
                InsertEngine.Parameters.AddWithValue("@Cylinders", Cylinders);
            }

            return InsertEngine;
        }

        /**
         * Creates a SQL statement for adding a Car to the database 
         * 
         * @return SQLString    SQL statement for adding a Car to the database
         */
        private string MakeEngineSQLString()
        {
            string SQLString;
            string InsertEngine = "INSERT INTO Engine(SerialNumber";
            string InsertValues = " VALUES (@SerialNumber";

            if (HorsePower.CompareTo("") != 0)
            {
                InsertEngine += ", HorsePower";
                InsertValues += ", @HorsePower";
            }
            if (Cylinders.CompareTo("") != 0)
            {
                InsertEngine += ", Cylinders";
                InsertValues += ", @Cylinders";
            }

            SQLString = InsertEngine;
            SQLString += ")";
            SQLString += InsertValues;
            SQLString += ")";

            return SQLString;
        }
    }
}
