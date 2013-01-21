using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakePart
    {
        /**
       * @param Data          Array with Part's data
       * @param cn            Connection to the database
       */
        private string[] Data;
        private OleDbConnection cn;

        /**
       * Constructor that gets the connection to the database and Part information
       * 
       * @param D             Data array for the Part
       * @param cn            Connection to the database
       */
        public MakePart(string[] D, OleDbConnection cn)
        {
            this.Data = D;
            this.cn = cn;
        }
        /**
       * Constructor that makes a part instance in the database
       */
        public void CreatePart()
        {
            MakeQuery(MakePartSQLString()).ExecuteNonQuery();
        }

        /**
         * Creates a command that when executed will add a Part to the database 
         * 
         * @param SQLString      SQL statement for adding a Part to the database
         * @return insertPart    Executable command for adding a Part to the database
         */
        private OleDbCommand MakeQuery(string SQLString)
        {
            OleDbCommand insertPart = cn.CreateCommand();
            insertPart.CommandText = SQLString;

            if (Data[0].CompareTo("") != 0)
                insertPart.Parameters.AddWithValue("@SerialNumber", Data[0]);
            if (Data[1].CompareTo("") != 0)
                insertPart.Parameters.AddWithValue("@VIN", Data[1]);
            if (Data[2].CompareTo("") != 0)
                insertPart.Parameters.AddWithValue("@Name", Data[2]);
            if (Data[3].CompareTo("") != 0)
                insertPart.Parameters.AddWithValue("@Manufacturer", Data[3]);

            return insertPart;
        }

        /**
         * Creates a SQL statement for adding a Part to the database 
         * 
         * @return SQLString    SQL statement for adding a Part to the database
         */
        private string MakePartSQLString()
        {
            string SQLString;
            string PartInsert = "INSERT INTO Part(SerialNumber";
            string InsertValues = " VALUES (@SerialNumber";

            if (Data[1].CompareTo("") != 0)
            {
                PartInsert += ", VIN";
                InsertValues += ", @VIN";
            }
            if (Data[2].CompareTo("") != 0)
            {
                PartInsert += ", PartName";
                InsertValues += ", @PartName";
            }
            if (Data[3].CompareTo("") != 0)
            {
                PartInsert += ", Manufacturer";
                InsertValues += ", @Manufacturer";
            }

            SQLString = PartInsert;
            SQLString += ")";
            SQLString += InsertValues;
            SQLString += ")";

            return SQLString;
        }
    }
}
