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
    /// Interaction logic for EmployeeProgress.xaml
    /// </summary>
    public partial class EmployeeProgress : Window
    {
        private OleDbConnection cn;

        public EmployeeProgress( OleDbConnection c )
        {
            cn = c;
            InitializeComponent();
        }

        private void CalculateEmployeeProgress_Click(object sender, RoutedEventArgs e)
        {
            StatsCalc SC = new StatsCalc(cn);

            try
            {
                EmployeeProgressGrid.ItemsSource = SC.CalculateProgress().DefaultView;
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
