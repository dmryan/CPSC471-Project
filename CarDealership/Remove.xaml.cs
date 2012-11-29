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
        bool Person;
        bool Vehicle;
        bool Part;
        private bool used;
        private bool noError;

        public Remove(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
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
                //sql num represents the id num
                OleDbCommand deletePerson = cn.CreateCommand();
                OleDbCommand deleteEmployee = cn.CreateCommand();
                OleDbCommand deleteCustomer = cn.CreateCommand();
                OleDbCommand selectPerson = cn.CreateCommand();

                deletePerson.CommandText = ("DELETE FROM Person WHERE ID =" + KeyNum);
                deleteEmployee.CommandText = ("DELETE FROM Employee WHERE EID =" + KeyNum);
                deleteCustomer.CommandText = ("DELETE FROM Customer WHERE CID =" + KeyNum);
                selectPerson.CommandText = ("SELECT ID FROM Person WHERE ID = @ID");

                selectPerson.Parameters.AddWithValue("@ID", KeyNum);

                try
                {
                    if (selectPerson.ExecuteScalar() == null)
                    {
                        ErrorWindow Error = new ErrorWindow("Required field does not match any values within the database.");
                        Error.ShowDialog();
                        return;
                    }

                    deleteEmployee.ExecuteNonQuery();
                    deleteCustomer.ExecuteNonQuery();
                    deletePerson.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }
            }
            else if (Vehicle)
            {
                //sql num represents the id num
                OleDbCommand deleteVehicle = cn.CreateCommand();
                OleDbCommand deleteVHR = cn.CreateCommand();
                OleDbCommand deleteCar = cn.CreateCommand();
                OleDbCommand deleteTruck = cn.CreateCommand();
                OleDbCommand selectSale = cn.CreateCommand();
                OleDbCommand selectPart = cn.CreateCommand();
                OleDbCommand selectVehicle = cn.CreateCommand();

                deleteVHR.CommandText = ("DELETE FROM VehicleHistoryReport WHERE VIN =" + KeyNum);
                deleteVehicle.CommandText = ("DELETE FROM Vehicle WHERE VIN =" + KeyNum);
                deleteCar.CommandText = ("DELETE FROM Car WHERE VIN =" + KeyNum);
                deleteTruck.CommandText = ("DELETE FROM Truck WHERE VIN =" + KeyNum);
                selectVehicle.CommandText = ("SELECT VIN FROM Vehicle WHERE VIN = @VIN");
                selectSale.CommandText = "SELECT VIN FROM Sale WHERE VIN = @VIN";
                selectPart.CommandText = "SELECT VIN FROM Part WHERE VIN = @VIN";

                selectVehicle.Parameters.AddWithValue("@VIN", KeyNum);
                selectSale.Parameters.AddWithValue("@VIN", KeyNum);
                selectPart.Parameters.AddWithValue("@VIN", KeyNum);

                try
                {
                    if (selectVehicle.ExecuteScalar() == null)
                    {
                        ErrorWindow Error = new ErrorWindow("Required field does not match any values within the database.");
                        Error.ShowDialog();
                        return;
                    }

                    if (selectSale.ExecuteScalar() == null && selectPart.ExecuteScalar() == null)
                        ;
                    else
                    {
                        ErrorWindow Error = new ErrorWindow("Cannot delete Vehicle because it is referenced in Sale and/or Part");
                        Error.ShowDialog();
                        return;
                    }

                    deleteCar.ExecuteNonQuery();
                    deleteTruck.ExecuteNonQuery();
                    deleteVHR.ExecuteNonQuery();
                    deleteVehicle.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }
            }
            else if (Part)
            {
                //sql num represents the id num
                OleDbCommand deletePart = cn.CreateCommand();
                OleDbCommand deleteEngine = cn.CreateCommand();
                OleDbCommand deleteTire = cn.CreateCommand();
                OleDbCommand selectPart = cn.CreateCommand();

                deletePart.CommandText = ("DELETE FROM Part WHERE SerialNumber =" + KeyNum);
                deleteEngine.CommandText = ("DELETE FROM Engine WHERE SerialNumber =" + KeyNum);
                deleteTire.CommandText = ("DELETE FROM Tire WHERE SerialNumber =" + KeyNum);
                selectPart.CommandText = ("SELECT SerialNumber FROM Part WHERE SerialNumber = @SerialNumber");

                selectPart.Parameters.AddWithValue("@SerialNumber", KeyNum);

                try
                {
                    if (selectPart.ExecuteScalar() == null)
                    {
                        ErrorWindow Error = new ErrorWindow("Required field does not match any values within the database.");
                        Error.ShowDialog();
                        return;
                    }

                    deleteEngine.ExecuteNonQuery();
                    deleteTire.ExecuteNonQuery();
                    deletePart.ExecuteNonQuery();
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
    }
}
