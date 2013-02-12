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
    /// Interaction logic for Remove.xaml
    /// </summary>
    public partial class Remove : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        Delete D;
        bool Person;
        bool Vehicle;
        bool Part;
        private bool used;
        private bool noError;

        public Remove(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            D = new Delete(cn);
            InitializeComponent();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            int KeyNum = 0;
            string Num = IDText.GetLineText(0);
            try
            {
                KeyNum = int.Parse(Num);
            }
            catch (Exception ex)
            {
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }

            if (Person)
            {
                try
                {
                    D.DeletePerson(KeyNum);
                }
                catch (ArgumentException ae)
                {
                    ErrorWindow Error = new ErrorWindow(ae.Message);
                    Error.ShowDialog();
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }
            }
            else if (Vehicle)
            {
                try
                {
                    D.DeleteVehicle(KeyNum);
                }
                catch (ArgumentException ae)
                {
                    ErrorWindow Error = new ErrorWindow(ae.Message);
                    Error.ShowDialog();
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }
            }
            else if (Part)
            {   try
                {
                    D.DeletePart(KeyNum);
                }
                catch (ArgumentException ae)
                {
                    ErrorWindow Error = new ErrorWindow(ae.Message);
                    Error.ShowDialog();
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }  
            }
            PersonCheck.IsChecked = false;
            VehicleCheck.IsChecked = false;
            PartCheck.IsChecked = false;
            Person = false;
            Vehicle = false;
            Part = false;
            PersonCheck.Visibility = Visibility.Visible;
            VehicleCheck.Visibility = Visibility.Visible;
            PartCheck.Visibility = Visibility.Visible;
            TextBoxLabel.Text = "";
            IDText.Clear();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PersonCheck_Checked(object sender, RoutedEventArgs e)
        {
            VehicleCheck.Visibility = Visibility.Collapsed;
            PartCheck.Visibility = Visibility.Collapsed;
            TextBoxLabel.Text = "ID";
            Person = true;
        }

        private void VehicleCheck_Checked(object sender, RoutedEventArgs e)
        {
            PersonCheck.Visibility = Visibility.Collapsed;
            PartCheck.Visibility = Visibility.Collapsed;
            TextBoxLabel.Text = "VIN";
            Vehicle = true;
        }

        private void PartCheck_Checked(object sender, RoutedEventArgs e)
        {
            PersonCheck.Visibility = Visibility.Collapsed;
            VehicleCheck.Visibility = Visibility.Collapsed;
            TextBoxLabel.Text = "Serial Number";
            Part = true;
        }

        private void PersonCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            VehicleCheck.Visibility = Visibility.Visible;
            PartCheck.Visibility = Visibility.Visible;
            TextBoxLabel.Text = "";
            Person = false;
        }

        private void VehicleCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            PersonCheck.Visibility = Visibility.Visible;
            PartCheck.Visibility = Visibility.Visible;
            TextBoxLabel.Text = "";
            Vehicle = false;
        }

        private void PartCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            PersonCheck.Visibility = Visibility.Visible;
            VehicleCheck.Visibility = Visibility.Visible;
            TextBoxLabel.Text = "";
            Part = false;
        }
    }
}
