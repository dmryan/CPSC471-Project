using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace CarDealership
{
    class SearchFunction
    {
        private OleDbConnection cn;

        public SearchFunction(OleDbConnection cn)
        {
            this.cn = cn;
        }

        public DataTable SearchPersonID( string ID)
        {
            OleDbCommand viewCustomer = cn.CreateCommand();
            OleDbCommand viewEmployee = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();

            viewCustomer.CommandText = "SELECT * FROM Person INNER JOIN Customer ON Person.ID = Customer.CID WHERE ID = @ID";
            viewEmployee.CommandText = "SELECT * FROM Person INNER JOIN Employee ON Person.ID = Employee.EID WHERE ID = @ID";
            viewCustomer.Parameters.AddWithValue("@ID", ID);
            viewEmployee.Parameters.AddWithValue("@ID", ID);

            da.SelectCommand = viewCustomer;
            da.Fill(dt);
            da.SelectCommand = viewEmployee;
            da.Fill(dt);
            return dt;
        }

        public DataTable SearchPersonName(string Name)
        {
            OleDbCommand viewCustomer = cn.CreateCommand();
            OleDbCommand viewEmployee = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();

            viewCustomer.CommandText = "SELECT * FROM Person INNER JOIN Customer ON Person.ID = Customer.CID WHERE PersonName = @Name";
            viewEmployee.CommandText = "SELECT * FROM Person INNER JOIN Employee ON Person.ID = Employee.EID WHERE PersonName = @Name";
            viewCustomer.Parameters.AddWithValue("@Name", Name);
            viewEmployee.Parameters.AddWithValue("@Name", Name);

            da.SelectCommand = viewCustomer;
            da.Fill(dt);
            da.SelectCommand = viewEmployee;
            da.Fill(dt);
            return dt;
        }
    }
}
