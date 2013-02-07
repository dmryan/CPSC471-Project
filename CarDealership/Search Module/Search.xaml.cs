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
        bool PersonName = false;
        bool PersonID = false;

        public Search(MainWindow p, OleDbConnection c, string t)
        {       
            cn = c;
            Parent = p;
            type = t;
            InitializeComponent();
            ResponseBlock.Visibility = Visibility.Collapsed;
            ResponseBlock2.Visibility = Visibility.Collapsed;

            if (type.CompareTo("Person") == 0)
            {
                StatementBlock.Text = "Enter ID# to Find a Specific Person";
                Parameter1.Visibility = Visibility.Collapsed; Parameter2.Visibility = Visibility.Collapsed;
                label1.Content = ""; label2.Content = ""; label3.Content = "";
                NameCheck.Visibility = Visibility.Visible; IDCheck.Visibility = Visibility.Visible; 
            }
            else if (type.CompareTo("Vehicle") == 0)
            {
                StatementBlock.Text = "Enter VIN to Find a Specific Vehicle\nVehicle History Reports are Included with Used Vehicles";
                Parameter1.Visibility = Visibility.Collapsed; Parameter2.Visibility = Visibility.Collapsed;
                label1.Content = ""; label2.Content = ""; label3.Content = "VIN";
                NameCheck.Visibility = Visibility.Collapsed; IDCheck.Visibility = Visibility.Collapsed; 
            }
            else if (type.CompareTo("Part") == 0)
            {
                StatementBlock.Text = "Enter Serial# to Find a Specific Part";
                Parameter1.Visibility = Visibility.Collapsed; Parameter2.Visibility = Visibility.Collapsed;
                label1.Content = ""; label2.Content = ""; label3.Content = "Serial Number";
                NameCheck.Visibility = Visibility.Collapsed; IDCheck.Visibility = Visibility.Collapsed; 
            }
            else
            {
                StatementBlock.Text = "Enter Employee and Customer ID#s and VIN to Find a Specific Sale";
                label1.Content = "Employee ID"; label2.Content = "Customer ID"; label3.Content = "VIN";
                NameCheck.Visibility = Visibility.Collapsed; IDCheck.Visibility = Visibility.Collapsed; 
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string Para1 = Parameter1.GetLineText(0);
            string Para2 = Parameter2.GetLineText(0);
            string Para3 = Parameter3.GetLineText(0);

            if (type.CompareTo("Person") == 0)
            {
                if (PersonID)
                {
                    ResponseBlock.Visibility = Visibility.Visible;

                    SearchFunction SF = new SearchFunction(cn);

                    try
                    {
                        ResponseBlock.ItemsSource = SF.SearchPersonID(Para3).DefaultView;
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.ShowDialog();
                    }
                }
                if (PersonName)
                {
                    ResponseBlock.Visibility = Visibility.Visible;

                    SearchFunction SF = new SearchFunction(cn);

                    try
                    {
                        ResponseBlock.ItemsSource = SF.SearchPersonName(Para3).DefaultView;
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.ShowDialog();
                    }
                }
            }
            else if (type.CompareTo("Vehicle") == 0)
            {
                ResponseBlock.Visibility = Visibility.Visible;
                ResponseBlock2.Visibility = Visibility.Visible;

                SearchFunction SF = new SearchFunction(cn);

                try
                {
                    ResponseBlock.ItemsSource = SF.SearchVehicle(Para3).DefaultView;
                    ResponseBlock2.ItemsSource = SF.SearchVHR(Para3).DefaultView;
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }
            }
            else if (type.CompareTo("Part") == 0)
            {
                ResponseBlock.Visibility = Visibility.Visible;

                SearchFunction SF = new SearchFunction(cn);

                try
                {
                    ResponseBlock.ItemsSource = SF.SearchPart(Para3).DefaultView;
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }
            }
            else
            {
                ResponseBlock.Visibility = Visibility.Visible;

                SearchFunction SF = new SearchFunction(cn);

                try
                {
                    ResponseBlock.ItemsSource = SF.SearchSale(Para1, Para2, Para3).DefaultView;
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }
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
            ResponseBlock.ItemsSource = null;
            ResponseBlock2.ItemsSource = null;
            ResponseBlock.Visibility = Visibility.Collapsed;
            ResponseBlock2.Visibility = Visibility.Collapsed;
        }

        private void IDCheck_Checked(object sender, RoutedEventArgs e)
        {
            PersonID = true;
            label3.Content = "ID";
            NameCheck.Visibility = Visibility.Collapsed;  
        }

        private void NameCheck_Checked(object sender, RoutedEventArgs e)
        {
            PersonName = true;
            label3.Content = "Name";
            IDCheck.Visibility = Visibility.Collapsed;
        }

        private void IDCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            PersonID = false;
            label3.Content = "";
            NameCheck.Visibility = Visibility.Visible;
        }

        private void NameCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            PersonName = false;
            label3.Content = "";
            IDCheck.Visibility = Visibility.Visible;
        }
    }
}
