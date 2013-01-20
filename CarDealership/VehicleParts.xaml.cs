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
    /// Interaction logic for VehicleParts.xaml
    /// </summary>
    public partial class VehicleParts : Window
    {
        OleDbConnection cn;
        public VehicleParts(OleDbConnection c)
        {
            cn = c;
            InitializeComponent();
            ResponseBlock1.Visibility = Visibility.Collapsed;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string VIN = Parameter1.GetLineText(0);
            ResponseBlock1.Visibility = Visibility.Visible;

            StatsCalc SC = new StatsCalc(cn);

            try
            {
                ResponseBlock1.ItemsSource = SC.VehicleParts(VIN).DefaultView;
            }
            catch (OleDbException ex)
            {
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResponseBlock1.ItemsSource = null;
            ResponseBlock1.Visibility = Visibility.Collapsed;
        }

    }
}
