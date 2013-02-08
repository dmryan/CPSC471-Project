using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeCustomer
    {
        /**
         * @param ID            ID of the Customer
         * @param Tyoe          Type of Customer
         * @param cn            Connection to the database
         */
        private string ID;
        private string Type;
        private OleDbConnection cn;

        /**
         * Constructor that gets the connection to the database and Customer information
         * 
         * @param ID            ID of the Customer
         * @param T             Type of Customer
         * @param cn            Connection to the database
         */
        public MakeCustomer(string ID, string T, OleDbConnection cn)
        {
            this.ID = ID;
            this.Type = T;
            this.cn = cn;
        }

        /**
         * Creates an instance of a Customer in the database
         */
        public void CreateCustomer()
        {
            MakeQuery(MakeCustomerSQLString()).ExecuteNonQuery();
        }

        /**
         * Deletes an instance of a Customer from the database
         */
        public void DeleteCustomer()
        {
            OleDbCommand deleteCustomer = cn.CreateCommand();
            deleteCustomer.CommandText = ("DELETE FROM CUSTOMER WHERE CID =" + ID);
            deleteCustomer.ExecuteNonQuery();
        }

        /**
         * Creates a command that when executed will add a Customer to the database 
         * 
         * @param SQLString     SQL statement for adding aCustomer to the database
         * @return insertCustomer   Executable command for adding a Customer to the database
         */
        private OleDbCommand MakeQuery(string SQLString)
        {
            OleDbCommand insertCustomer = cn.CreateCommand();
            insertCustomer.CommandText = SQLString;

            if (ID.CompareTo("") != 0)
            {
                insertCustomer.Parameters.AddWithValue("@CID", ID);
            }
            if (Type.CompareTo("") != 0)
            {
                insertCustomer.Parameters.AddWithValue("@Type", Type);
            }

            return insertCustomer;
        }

        /**
         * Creates a SQL statement for adding a Customere to the database 
         * 
         * @return SQLString    SQL statement for adding a Customer to the database
         */
        private string MakeCustomerSQLString()
        {
            string SQLString;
            string InsertCustomer = "INSERT INTO Customer(CID";
            string InsertValues = " VALUES (@CID";

            if (Type.CompareTo("") != 0)
            {
                InsertCustomer += ", Type";
                InsertValues += ", @Type";
            }

            SQLString = InsertCustomer;
            SQLString += ")";
            SQLString += InsertValues;
            SQLString += ")";

            return SQLString;
        }
    }
}
