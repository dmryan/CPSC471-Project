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
    /// Interaction logic for VehicleHistoryReport.xaml
    /// </summary>
    public partial class VehicleHistoryReport : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        public VehicleHistoryReport(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            InitializeComponent();
        }

        private void AddVehicleHistoryReport_Click(object sender, RoutedEventArgs e)
        {
            string VIN = VINText.GetLineText(0);
            string NumOwners = NumOwnersText.GetLineText(0);
            string Mileage = MileageText.GetLineText(0);
            string Rating = RatingText.GetLineText(0);

            //sql statement

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
