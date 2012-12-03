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
            string Para1 = Parameter1.GetLineText(0);
            //sql statement VIN is in Para3
            OleDbCommand viewPart = cn.CreateCommand();
            OleDbCommand viewEngine = cn.CreateCommand();
            OleDbCommand viewTire = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();
            ResponseBlock1.Visibility = Visibility.Visible;

            viewPart.CommandText = "SELECT * FROM Part WHERE Part.VIN = @VIN";            
            viewPart.Parameters.AddWithValue("@VIN", Para1);
            try
            {
                da.SelectCommand = viewPart;
                da.Fill(dt);
                ResponseBlock1.ItemsSource = dt.DefaultView;
                if (ResponseBlock1.Items.Count == 0)
                {
                    da.SelectCommand = viewPart;
                    da.Fill(dt);
                    ResponseBlock1.ItemsSource = dt.DefaultView;
                }
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
