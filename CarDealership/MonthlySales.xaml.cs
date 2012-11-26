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
    /// Interaction logic for MonthlySales.xaml
    /// </summary>
    public partial class MonthlySales : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        private bool noError;

        public MonthlySales(OleDbConnection c)
        {
            cn = c;
            InitializeComponent();
        }

        private void CalculateMonthlySales_Click(object sender, RoutedEventArgs e)
        {
            noError = true;

            string MonthYear = MonthYearText.GetLineText(0);

            //SQL Statement
            OleDbCommand calculateMonthlySales = cn.CreateCommand();

            calculateMonthlySales.CommandText = "SELECT SUM(SalePrice) FROM Sale WHERE SellDate LIKE @MonthYear";

            calculateMonthlySales.Parameters.AddWithValue("@MonthYear", "%" + MonthYear);

            try 
            {
                Object Total = new Object();
                Total = calculateMonthlySales.ExecuteScalar();
                if (Total is DBNull || Total == "" || MonthYear == "")
                    Total = "0";
                    
                MonthlySalesText.Text= Total.ToString();;
            }
            catch (OleDbException ex)
            {
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }

            
        }
    }
}
