using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeCustomer
    {
        private string ID;
        private string Type;
        private OleDbConnection cn;
        public MakeCustomer(string ID, string T, OleDbConnection cn)
        {
            this.ID = ID;
            this.Type = T;
            this.cn = cn;
        }
        public void CreateCustomer()
        {
            MakeQuery(MakeCustomerSQLString()).ExecuteNonQuery();
        }
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
