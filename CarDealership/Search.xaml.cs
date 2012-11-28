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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        private bool used;
        private bool noError;
        private string type;

        public Search(MainWindow p, OleDbConnection c, string t)
        {
            cn = c;
            Parent = p;
            type = t;
            InitializeComponent();
            if (type.CompareTo("Person") == 0)
            {
                StatementBlock.Text = "Enter ID# to Find a Specific Person";
                Parameter1.Visibility = Visibility.Collapsed; Parameter2.Visibility = Visibility.Collapsed;
            }
            else if (type.CompareTo("Vehicle") == 0)
            {
                StatementBlock.Text = "Enter VIN to Find a Specific Vehicle\nVehicle History Reports are Included with Used Vehicles";
                Parameter1.Visibility = Visibility.Collapsed; Parameter2.Visibility = Visibility.Collapsed;
            }
            else if (type.CompareTo("Part") == 0)
            {
                StatementBlock.Text = "Enter Serial# to Find a Specific Part";
                Parameter1.Visibility = Visibility.Collapsed; Parameter2.Visibility = Visibility.Collapsed;
            }
            else
            {
                StatementBlock.Text = "Enter Employee and Customer ID#s and VIN to Find a Specific Sale";
                Parameter1.Text = "(EID)100456"; Parameter2.Text = "(CustID)105043"; Parameter3.Text = "(VIN)598786";
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string Para1 = Parameter1.GetLineText(0);
            string Para2 = Parameter2.GetLineText(0);
            string Para3 = Parameter3.GetLineText(0);

            if (type.CompareTo("Person") == 0)
            {
                //sql statement ID is in Para3 //  use ResponseBlcok.ApppendText(string); to add info
                OleDbCommand viewCustomer = cn.CreateCommand();
                OleDbCommand viewEmployee = cn.CreateCommand();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();

                viewCustomer.CommandText = "SELECT * FROM Person INNER JOIN Customer ON Person.ID = Customer.CID WHERE ID = @ID";
                viewEmployee.CommandText = "SELECT * FROM Person INNER JOIN Employee ON Person.ID = Employee.EID WHERE ID = @ID";

                viewCustomer.Parameters.AddWithValue("@ID", Para3);
                viewEmployee.Parameters.AddWithValue("@ID", Para3);

                try
                {
                    da.SelectCommand = viewCustomer;
                    da.Fill(dt);
                    da.SelectCommand = viewEmployee;
                    da.Fill(dt);
                    ResponseBlock.ItemsSource = dt.DefaultView;
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }
            }
            else if (type.CompareTo("Vehicle") == 0)
            {
                //sql statement VIN is in Para3
                OleDbCommand viewCar = cn.CreateCommand();
                OleDbCommand viewTruck = cn.CreateCommand();
                OleDbCommand viewVHR = cn.CreateCommand();
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();

                viewCar.CommandText = "SELECT Vehicle.Vin, Model, YearProd, Maker, NumberSeats, Price, Sold, Type FROM Vehicle INNER JOIN Car ON Vehicle.VIN = Car.VIN WHERE Vehicle.VIN = @VIN";
                viewTruck.CommandText = "SELECT Vehicle.VIN, Model, YearProd, Maker, NumberSeats, Price, Sold, TowingCapacity FROM Vehicle INNER JOIN Truck ON Vehicle.VIN = Truck.VIN WHERE Vehicle.VIN = @VIN";
                viewVHR.CommandText = "SELECT VIN, NumberOwners, Rating, Mileage FROM VehicleHistoryReport WHERE VIN = @VIN";

                viewCar.Parameters.AddWithValue("@VIN", Para3);
                viewTruck.Parameters.AddWithValue("@VIN", Para3);
                viewVHR.Parameters.AddWithValue("@VIN", Para3);

                try
                {
                    da.SelectCommand = viewCar;
                    da.Fill(dt);
                    da.SelectCommand = viewTruck;
                    da.Fill(dt);
                    ResponseBlock.ItemsSource = dt.DefaultView;
                    da.SelectCommand = viewVHR;
                    da.Fill(dt2);
                    ResponseBlock2.ItemsSource = dt2.DefaultView;
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }
            }
            else if (type.CompareTo("Part") == 0)
            {

                //sql statement VIN is in Para3
                OleDbCommand viewPart = cn.CreateCommand();
                OleDbCommand viewEngine = cn.CreateCommand();
                OleDbCommand viewTire = cn.CreateCommand();
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();

                viewPart.CommandText = "SELECT * FROM Part WHERE Part.SerialNumber = @SerialNumber";
                viewEngine.CommandText = "SELECT Part.SerialNumber, VIN, PartName, Manufacturer, HorsePower, Cylinders FROM Part INNER JOIN Engine ON Part.SerialNumber = Engine.SerialNumber WHERE Part.SerialNumber = @SerialNumber";
                viewTire.CommandText = "SELECT Part.SerialNumber, VIN, PartName, Manufacturer, Type, TireSize FROM Part INNER JOIN Tire ON Part.SerialNumber = Tire.SerialNumber WHERE Part.SerialNumber = @SerialNumber";

                viewPart.Parameters.AddWithValue("@SerialNumber", Para3);
                viewEngine.Parameters.AddWithValue("@SerialNumber", Para3);
                viewTire.Parameters.AddWithValue("@SerialNumber", Para3);

                try
                {
                    da.SelectCommand = viewEngine;
                    da.Fill(dt);
                    da.SelectCommand = viewTire;
                    da.Fill(dt);
                    ResponseBlock.ItemsSource = dt.DefaultView;
                    if (ResponseBlock.Items.Count == 0)
                    {
                        da.SelectCommand = viewPart;
                        da.Fill(dt2);
                        ResponseBlock.ItemsSource = dt2.DefaultView;
                    }
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }
            }
            else
            {
                //sql statement EID is Para1, CustID is Para2, VIN is Para3
            }

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResponseBlock.ItemsSource = null;
            ResponseBlock2.ItemsSource = null;
        }
    }
}
