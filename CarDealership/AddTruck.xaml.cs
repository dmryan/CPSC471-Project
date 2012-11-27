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
            OleDbCommand insertVehical = cn.CreateCommand();
            OleDbCommand insertTruck = cn.CreateCommand();

            insertVehical.CommandText = "INSERT INTO Vehicle(VIN, Model, YearProd, Maker, NumberSeats, Price, Sold) VALUES (@VIN, @Model, @YearProd, @Maker, @NumberSeats, @Price, @Sold)";
            insertTruck.CommandText = "INSERT INTO Truck(VIN, TowingCapacity) VALUES (@VIN, @TowingCapacity)";

            insertVehical.Parameters.AddWithValue("@VIN", VIN);
            insertVehical.Parameters.AddWithValue("@Model", Model);
            insertVehical.Parameters.AddWithValue("@YearProd", YearProd);
            insertVehical.Parameters.AddWithValue("@Maker", Maker);
            insertVehical.Parameters.AddWithValue("@NumberSeats", NumberSeats);
            insertVehical.Parameters.AddWithValue("@Price", Price);
            insertVehical.Parameters.AddWithValue("@Sold", Sold);

            insertTruck.Parameters.AddWithValue("@VIN", VIN);
            insertTruck.Parameters.AddWithValue("@TowingCapacity", TowingCapacity);

            try {
                insertVehical.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }
            if (noError)
            {
                try {
                    insertTruck.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    OleDbCommand deletePart = cn.CreateCommand();
                    deletePart.CommandText = ("DELETE FROM Vehicle WHERE VIN =" + VIN);
                    deletePart.ExecuteNonQuery();
                    noError = false;
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }
            }
            
            if (noError)
            {
                if(used == true)
                {
                    VehicleHistoryReport newWindow = new VehicleHistoryReport(Parent, cn);
                    newWindow.ShowDialog();
                }
                this.Close();
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
