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
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;

namespace CarDealership
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Window
    {
        private OleDbConnection cn;

        public Inventory( OleDbConnection c )
        {
            cn = c;
            InitializeComponent();
        }

        private void CalculateInventory_Click(object sender, RoutedEventArgs e)
        {
            OleDbCommand viewInventory = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();

            viewInventory.CommandText = "SELECT * FROM Vehicle"/* INNER JOIN Car ON Vehicle.VIN = Car.VIN WHERE Sold = @False"*/;
            
            viewInventory.Parameters.AddWithValue("@False", false);

            try
            {
                da.SelectCommand = viewInventory;
                da.Fill(dt);
                InventoryList.ItemsSource = dt.DefaultView;
            }
            catch (OleDbException ex)
            {
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
