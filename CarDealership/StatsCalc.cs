using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CarDealership
{
    class StatsCalc
    {
        /**
         * @param cn            Connection to the database
         */
        private OleDbConnection cn;

        /**
         * Constructor that gets the connection to the database
         * 
         * @param cn            Connection to the database
         */
        public StatsCalc(OleDbConnection cn)
        {
            this.cn = cn;
        }

        /**
         * Function that accesses the database and creates a DataTable of employees' total sales
         * 
         * @return dt           Table of employees' sales
         */
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

        /**
         * Function that accesses the database and creates a DataTable of employees' sales for the given month
         * 
         * @param Month         Month to search in
         * @param Year          Year to search in
         * @return dt           Table of employees' sales
         */
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

            Money = Total.ToString();
            return Money;
        }

        /**
         * Function that accesses the database and creates a DataTable of a certain vehicle's parts
         * 
         * @param VIN           VIN to search for
         * @return dt           Table of Parts with matching VIN
         */
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

        /**
         * Function that accesses the database and returns the gross revenue of the dealership
         * 
         * @return Revenue           Gross dealership revenue
         */
        public string Revenue()
        {
            string Revenue;
            OleDbCommand calculateRevenue = cn.CreateCommand();

            calculateRevenue.CommandText = "SELECT SUM(SalePrice) FROM Sale";

            Object Total = new Object();
            Total = calculateRevenue.ExecuteScalar();
            if (Total is DBNull || Total == "")
                Total = "0";

            Revenue = Total.ToString();
            return Revenue;
        }

        /**
         * Function that accesses the database and creates a DataTable of cars in inventory
         * 
         * @return dt           Table of cars in inventory
         */
        public DataTable CarsInventory()
        {
            OleDbCommand viewInventory = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();

            viewInventory.CommandText = "SELECT Vehicle.VIN, Model, YearProd, Maker, NumberSeats, Price, Type FROM Vehicle INNER JOIN Car ON Vehicle.VIN = Car.VIN WHERE Sold = @False";
            viewInventory.Parameters.AddWithValue("@False", false);

            da.SelectCommand = viewInventory;
            da.Fill(dt);
            return dt;
        }

        /**
         * Function that accesses the database and creates a DataTable of trucks in inventory
         * 
         * @return dt           Table of trucks in inventory
         */
        public DataTable TrucksInventory()
        {
            OleDbCommand viewInventory = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();

            viewInventory.CommandText = "SELECT Vehicle.VIN, Model, YearProd, Maker, NumberSeats, Price, TowingCapacity FROM Vehicle INNER JOIN Truck ON Vehicle.VIN = Truck.VIN WHERE Sold = @False";
            viewInventory.Parameters.AddWithValue("@False", false);

            da.SelectCommand = viewInventory;
            da.Fill(dt);
            return dt;
        }
    }
}
