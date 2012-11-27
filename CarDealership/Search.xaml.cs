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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        private bool used;
        private bool noError;
        private string type;

        public Search(MainWindow p, OleDbConnection c, string t)
        {
            cn = c;
            Parent = p;
            type = t;
            InitializeComponent();
            if (type.CompareTo("Person") == 0)
            {
                StatementBlock.Text = "Enter ID# to Find a Specific Person";
                Parameter1.Visibility = Visibility.Collapsed; Parameter2.Visibility = Visibility.Collapsed;
            }
            else if (type.CompareTo("Vehicle") == 0)
            {
                StatementBlock.Text = "Enter VIN to Find a Specific Vehicle\nVehicle History Reports are Included with Used Vehicles";
                Parameter1.Visibility = Visibility.Collapsed; Parameter2.Visibility = Visibility.Collapsed;
            }
            else if (type.CompareTo("Part") == 0)
            {
                StatementBlock.Text = "(1) Enter Serial# to Find a Specific Part\n(2) Perform a General Search with up to Three Criteria";
                Parameter1.Visibility = Visibility.Collapsed; Parameter2.Visibility = Visibility.Collapsed;
            }
            else
            {
                StatementBlock.Text = "Enter Employee and Customer ID#s and VIN to Find a Specific Sale";
                Parameter1.Text = "(EID)100456"; Parameter2.Text = "(CustID)105043"; Parameter3.Text = "(VIN)598786";
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string Para1 = Parameter1.GetLineText(0);
            string Para2 = Parameter2.GetLineText(0);
            string Para3 = Parameter3.GetLineText(0);

            string message = "Initiating " + type + " Search...\n";

            ResponseBlock.AppendText(message);

            if (type.CompareTo("Person") == 0)
            {
                //sql statement ID is in Para3 //  use ResponseBlcok.ApppendText(string); to add info
            }
            else if (type.CompareTo("Vehicle") == 0)
            {
                //sql statement VIN is in Para3
            }
            else if (type.CompareTo("Part") == 0)
            {
                //sql statement Serial# is in Para3
            }
            else
            {
                //sql statement EID is Para1, CustID is Para2, VIN is Para3
            }

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextRange text = new TextRange(ResponseBlock.Document.ContentStart, ResponseBlock.Document.ContentEnd); text.Text = "\n";
        }
    }
}
