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

        public DataTable SearchPersonID( string ID )
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

        public DataTable SearchPersonName( string Name )
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

        public DataTable SearchVehicle( string VIN )
        {
            OleDbCommand viewCar = cn.CreateCommand();
            OleDbCommand viewTruck = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();

            viewCar.CommandText = "SELECT Vehicle.Vin, Model, YearProd, Maker, NumberSeats, Price, Sold, Type FROM Vehicle INNER JOIN Car ON Vehicle.VIN = Car.VIN WHERE Vehicle.VIN = @VIN";
            viewTruck.CommandText = "SELECT Vehicle.VIN, Model, YearProd, Maker, NumberSeats, Price, Sold, TowingCapacity FROM Vehicle INNER JOIN Truck ON Vehicle.VIN = Truck.VIN WHERE Vehicle.VIN = @VIN";

            viewCar.Parameters.AddWithValue("@VIN", VIN);
            viewTruck.Parameters.AddWithValue("@VIN", VIN);

            da.SelectCommand = viewCar;
            da.Fill(dt);
            da.SelectCommand = viewTruck;
            da.Fill(dt);
            return dt;
        }

        public DataTable SearchVHR( string VIN )
        {
            OleDbCommand viewVHR = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();

            viewVHR.CommandText = "SELECT VIN, NumberOwners, Rating, Mileage FROM VehicleHistoryReport WHERE VIN = @VIN";
            viewVHR.Parameters.AddWithValue("@VIN", VIN);

            da.SelectCommand = viewVHR;
            da.Fill(dt);
            return dt;
        }

        public DataTable SearchPart( string SN )
        {
            OleDbCommand viewPart = cn.CreateCommand();
            OleDbCommand viewEngine = cn.CreateCommand();
            OleDbCommand viewTire = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();

            viewPart.CommandText = "SELECT * FROM Part WHERE Part.SerialNumber = @SerialNumber";
            viewEngine.CommandText = "SELECT Part.SerialNumber, VIN, PartName, Manufacturer, HorsePower, Cylinders FROM Part INNER JOIN Engine ON Part.SerialNumber = Engine.SerialNumber WHERE Part.SerialNumber = @SerialNumber";
            viewTire.CommandText = "SELECT Part.SerialNumber, VIN, PartName, Manufacturer, Type, TireSize FROM Part INNER JOIN Tire ON Part.SerialNumber = Tire.SerialNumber WHERE Part.SerialNumber = @SerialNumber";
            viewPart.Parameters.AddWithValue("@SerialNumber", SN);
            viewEngine.Parameters.AddWithValue("@SerialNumber", SN);
            viewTire.Parameters.AddWithValue("@SerialNumber", SN);

            da.SelectCommand = viewEngine;
            da.Fill(dt);
            da.SelectCommand = viewTire;
            da.Fill(dt);
            if (dt.Rows.Count == 0 )
            {
                dt.Columns.Clear();
                da.SelectCommand = viewPart;
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable SearchSale(string EID, string CID, string VIN)
        {
            OleDbCommand viewSale = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();

            viewSale.CommandText = "SELECT * FROM Sale WHERE EID = @EID AND CID = @CID AND VIN = @VIN";
            viewSale.Parameters.AddWithValue("@EID", EID);
            viewSale.Parameters.AddWithValue("@CID", CID);
            viewSale.Parameters.AddWithValue("@VIN", VIN);

            da.SelectCommand = viewSale;
            da.Fill(dt);
            dt.Columns[4].ColumnName = "Sale Price ($)";
            return dt;
        }
    }
}
