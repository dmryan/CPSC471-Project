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

namespace CarDealership
{
    /// <summary>
    /// Interaction logic for Revenue.xaml
    /// </summary>
    public partial class Revenue : Window
    {
        private OleDbConnection cn;

        public Revenue(OleDbConnection c)
        {
            cn = c;
            InitializeComponent();
        }

        private void CalculateRevenue_Click(object sender, RoutedEventArgs e)
        {
            //SQL Statement
            OleDbCommand calculateRevenue = cn.CreateCommand();

            calculateRevenue.CommandText = "SELECT SUM(SalePrice) FROM Sale";

            try
            {
                Object Total = new Object();
                Total = calculateRevenue.ExecuteScalar();
                if (Total is DBNull || Total == "")
                    Total = "0";

                RevenueText.Text = "$ " + Total.ToString();
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
