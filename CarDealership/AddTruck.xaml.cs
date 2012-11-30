using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace CarDealership
{
    /// <summary>
    /// Interaction logic for AddTruck.xaml
    /// </summary>
    public partial class AddTruck : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        private bool used;
        private bool noError;

        public AddTruck(MainWindow p, OleDbConnection c, bool u)
        {
            cn = c;
            Parent = p;
            used = u;
            InitializeComponent();
        }

        private void AddTruckSubmit_Click(object sender, RoutedEventArgs e)
        {
            noError = true;

            string VIN = VINText.GetLineText(0);
            string Model = ModelText.GetLineText(0);
            string YearProd = YearText.GetLineText(0);
            string Maker = ManufacturerText.GetLineText(0);
            string NumberSeats = SeatsText.GetLineText(0);
            string Price = PriceText.GetLineText(0);
            string TowingCapacity = TowingCapText.GetLineText(0);
            bool Sold = false;

             //SQL Statement
            OleDbCommand insertVehicle = cn.CreateCommand();
            OleDbCommand insertTruck = cn.CreateCommand();

           // insertVehicle.CommandText = "INSERT INTO Vehicle(VIN, Model, YearProd, Maker, NumberSeats, Price, Sold) VALUES (@VIN, @Model, @YearProd, @Maker, @NumberSeats, @Price, @Sold)";
            //insertTruck.CommandText = "INSERT INTO Truck(VIN, TowingCapacity) VALUES (@VIN, @TowingCapacity)";

            string vehicle1 = "INSERT INTO Vehicle(VIN";
            string vehicle2 = " Values (@VIN";
            string truck1 = "INSERT INTO Truck(VIN";
            string truck2 = " VALUES (@VIN";
            //insertEmployee.CommandText = "INSERT INTO Employee(EID, Salary, StartDate, ManagerID) VALUES (@EID, @Salary, @StartDate, @ManagerID)";

            if (Model.CompareTo("") != 0)
            {
                vehicle1 += ", Model";
                vehicle2 += ", @Model";
            }
            if (YearProd.CompareTo("") != 0)
            {
                vehicle1 += ", YearProd";
                vehicle2 += ", @YearProd";
            }
            if (Maker.CompareTo("") != 0)
            {
                vehicle1 += ", Maker";
                vehicle2 += ", @Maker";
            }
            if (NumberSeats.CompareTo("") != 0)
            {
                vehicle1 += ", NumberSeats";
                vehicle2 += ", @NumberSeats";
            }
            if (Price.CompareTo("") != 0)
            {
                vehicle1 += ", Price";
                vehicle2 += ", @Price";
            }
            insertVehicle.CommandText = vehicle1;
            insertVehicle.CommandText += ", Sold";
            insertVehicle.CommandText += ")";
            insertVehicle.CommandText += vehicle2;
            insertVehicle.CommandText += ", @Sold";
            insertVehicle.CommandText += ")";
            if (VIN.CompareTo("") != 0)
            {
                insertVehicle.Parameters.AddWithValue("@VIN", VIN);
            }
            if (Model.CompareTo("") != 0)
            {
                insertVehicle.Parameters.AddWithValue("@Model", Model);
            }
            if (YearProd.CompareTo("") != 0)
            {
                insertVehicle.Parameters.AddWithValue("@YearProd", YearProd);
            }
            if (Maker.CompareTo("") != 0)
            {
                insertVehicle.Parameters.AddWithValue("@Maker", Maker);
            }
            if (NumberSeats.CompareTo("") != 0)
            {
                insertVehicle.Parameters.AddWithValue("@NumberSeats", NumberSeats);
            }
            if (Price.CompareTo("") != 0)
            {
                insertVehicle.Parameters.AddWithValue("@Price", Price);
            }
            insertVehicle.Parameters.AddWithValue("@Sold", Sold);
            try
            {
                insertVehicle.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }
            ///////////////////////////////////////////////////////////////////////
            if (TowingCapacity.CompareTo("") != 0)
            {
                truck1 += ", TowingCapacity";
                truck2 += ", @TowingCapacity";
            }
            insertTruck.CommandText = truck1;
            insertTruck.CommandText += ")";
            insertTruck.CommandText += truck2;
            insertTruck.CommandText += ")";
            if (VIN.CompareTo("") != 0)
            {
                insertTruck.Parameters.AddWithValue("@VIN", VIN);
            }
            if (TowingCapacity.CompareTo("") != 0)
            {
                insertTruck.Parameters.AddWithValue("@TowingCapacity", TowingCapacity);
            }
            try
            {
                insertTruck.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                OleDbCommand deleteVehicle = cn.CreateCommand();
                deleteVehicle.CommandText = ("DELETE FROM VEHICLE WHERE ID =" + VIN);
                deleteVehicle.ExecuteNonQuery();
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }
            if (noError)
                this.Close();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
