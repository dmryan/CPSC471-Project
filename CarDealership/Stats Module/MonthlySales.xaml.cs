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

        public MonthlySales(OleDbConnection c)
        {
            cn = c;
            InitializeComponent();
        }

        private void CalculateMonthlySales_Click(object sender, RoutedEventArgs e)
        {
            string Month = MonthText.GetLineText(0);
            string Year = YearText.GetLineText(0);

            StatsCalc SC = new StatsCalc(cn);

            try 
            {
                MonthlySalesText.Text = SC.MonthlySales(Month, Year);
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
