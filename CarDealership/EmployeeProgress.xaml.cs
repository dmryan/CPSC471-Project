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
            OleDbCommand viewEmployeeProgress = cn.CreateCommand();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();

            viewEmployeeProgress.CommandText = "SELECT EID, PersonName, SUM(SalePrice) FROM Sale INNER JOIN Person ON Person.ID = Sale.EID GROUP BY EID, PersonName";

            viewEmployeeProgress.Parameters.AddWithValue("@False", false);

            try
            {
                da.SelectCommand = viewEmployeeProgress;
                da.Fill(dt);
                dt.Columns[2].ColumnName = "Sale Money Earned ($)";
                EmployeeProgressGrid.ItemsSource = dt.DefaultView;

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
