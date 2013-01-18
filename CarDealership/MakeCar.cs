using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeCar
    {
        /**
         * @param VIN           VIN of the Car
         * @param Type          Type of the Car
         * @param cn            Connection to the database
         */
        private string VIN;
        private string Type;
        private OleDbConnection cn;

        /**
         * Constructor that gets the connection to the database and Car information
         * 
         * @param V             VIN of the Car
         * @param T             Type of the Car
         * @param cn            Connection to the database
         */
        public MakeCar(string V, string T, OleDbConnection cn)
        {
            this.VIN = V;
            this.Type = T;
            this.cn = cn;
        }

        /**
         * Creates a Car
         */
        public void CreateCar()
        {
            MakeQuery(MakeCarSQLString()).ExecuteNonQuery();
        }

        /**
         * Creates a command that when executed will add a Car to the database 
         * 
         * @param SQLString     SQL statement for adding a Car to the database
         * @return insertCar    Executable command for adding a Car to the database
         */
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

        /**
         * Creates a SQL statement for adding a Car to the database 
         * 
         * @return SQLString    SQL statement for adding a Car to the database
         */
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
