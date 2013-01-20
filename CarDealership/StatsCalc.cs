﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CarDealership
{
    class StatsCalc
    {
        private OleDbConnection cn;

        public StatsCalc(OleDbConnection cn)
        {
            this.cn = cn;
        }

        public DataTable CalculateProgress()
        {
            OleDbCommand viewEmployeeProgress = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();

            viewEmployeeProgress.CommandText = "SELECT EID, PersonName, SUM(SalePrice) FROM Sale INNER JOIN Person ON Person.ID = Sale.EID GROUP BY EID, PersonName";
            viewEmployeeProgress.Parameters.AddWithValue("@False", false);

            da.SelectCommand = viewEmployeeProgress;
            da.Fill(dt);
            dt.Columns[2].ColumnName = "Sale Money Earned ($)";
            return dt;
        }

        public string MonthlySales( string Month, string Year)
        {
            string Money;
            OleDbCommand calculateMonthlySales = cn.CreateCommand();

            calculateMonthlySales.CommandText = "SELECT SUM(SalePrice) FROM Sale WHERE SellDate LIKE @MonthYear";
            calculateMonthlySales.Parameters.AddWithValue("@MonthYear", Month + "/" + "%" + "/" + Year);

            Object Total = new Object();
            Total = calculateMonthlySales.ExecuteScalar();
            if (Total is DBNull || Total == "" || Month == "" || Year == "")
                Total = "0";

            Money = "$ " + Total.ToString();
            return Money;
        }

        public DataTable VehicleParts( string VIN )
        {
            OleDbCommand viewPart = cn.CreateCommand();
            OleDbCommand viewEngine = cn.CreateCommand();
            OleDbCommand viewTire = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();

            viewPart.CommandText = "SELECT * FROM Part WHERE Part.VIN = @VIN";
            viewPart.Parameters.AddWithValue("@VIN", VIN);

            da.SelectCommand = viewPart;
            da.Fill(dt);
            return dt;
        }

        public string Revenue()
        {
            string Revenue;
            OleDbCommand calculateRevenue = cn.CreateCommand();

            calculateRevenue.CommandText = "SELECT SUM(SalePrice) FROM Sale";

            Object Total = new Object();
            Total = calculateRevenue.ExecuteScalar();
            if (Total is DBNull || Total == "")
                Total = "0";

            Revenue = "$ " + Total.ToString();
            return Revenue;
        }
    }
}
