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
        public AddTruck(MainWindow p, OleDbConnection c, bool u)
        {
            cn = c;
            Parent = p;
            used = u;
            InitializeComponent();
        }

        private void AddEmployeeSubmit_Click(object sender, RoutedEventArgs e)
        {
            string VIN = VINText.GetLineText(0);
            string Model = ModelText.GetLineText(0);
            string Year = YearText.GetLineText(0);
            string Manufacturer = ManufacturerText.GetLineText(0);
            string Seats = SeatsText.GetLineText(0);
            string Price = PriceText.GetLineText(0);
            string TowingCapacity = TowingCapText.GetLineText(0);
            bool Sold = false;

            //sql statement

            if(used == true)
            {
                Parent.SecondWindow = new VehicleHistoryReport(Parent, cn);
                ((VehicleHistoryReport)Parent.SecondWindow).Show();
                ((VehicleHistoryReport)Parent.SecondWindow).Activate();
            }
            if(used == false)
                Parent.SecondWindow = null;

            this.Close();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Parent.SecondWindow = null;
            base.OnClosing(e);
        }
    }
}
