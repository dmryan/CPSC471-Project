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
    public partial class Modify : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        bool Employee;
        bool Customer;
        bool Truck;
        bool Car;
        bool Part;
        bool Engine;
        bool Tires;
        private bool used;
        private bool noError;

        public Modify(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            InitializeComponent();
            PersonOther1Box.Visibility = Visibility.Collapsed;
            PersonOther1Label.Visibility = Visibility.Collapsed;
            PersonOther2Box.Visibility = Visibility.Collapsed;
            PersonOther2Label.Visibility = Visibility.Collapsed;
            PersonOther3Box.Visibility = Visibility.Collapsed;
            PersonOther3Label.Visibility = Visibility.Collapsed;

            VehicleOther1Box.Visibility = Visibility.Collapsed;
            VehicleOther1Label.Visibility = Visibility.Collapsed;

            PartOther1Box.Visibility = Visibility.Collapsed;
            PartOther1Label.Visibility = Visibility.Collapsed;
            PartOther2Box.Visibility = Visibility.Collapsed;
            PartOther2Label.Visibility = Visibility.Collapsed;
        }

        private void SubmitPerson_Click(object sender, RoutedEventArgs e)
        {
            if (Employee)
            {
                string EID = PersonIDBox.GetLineText(0);
                string Name = PersonNameBox.GetLineText(0);
                string Phone = PersonPhoneBox.GetLineText(0);
                string Address = PersonAddressBox.GetLineText(0);
                string Sex = PersonSexBox.GetLineText(0);
                string Salary = PersonOther1Box.GetLineText(0);
                string StartDate = PersonOther2Box.GetLineText(0);
                string Manager = PersonOther3Box.GetLineText(0);
               
                //SQL
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand updatePerson = cn.CreateCommand();
                OleDbCommand updateEmployee = cn.CreateCommand();
                OleDbCommand selectEmployee = cn.CreateCommand();

                selectEmployee.CommandText = "SELECT EID FROM Employee WHERE EID = @EID";
                selectEmployee.Parameters.AddWithValue("@EID", EID);

                if (EID.CompareTo("") == 0 || selectEmployee.ExecuteScalar() == null)
                {
                    ErrorWindow Error = new ErrorWindow("Please enter a valid EID");
                    Error.Title = "EID Field Error";
                    Error.ShowDialog();
                }
                else
                {
                    if (Name.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePerson.CommandText = "UPDATE Person SET PersonName = ? WHERE ID = ?";
                            updatePerson.Parameters.AddWithValue("@PersonName", Name);
                            updatePerson.Parameters.AddWithValue("@ID", EID);
                        
                            updatePerson.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Name Field Error";
                            Error.ShowDialog();
                        }
                    } 
                    if (Phone.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePerson.CommandText = "UPDATE Person SET PhoneNumber = ? WHERE ID = ?";
                            updatePerson.Parameters.AddWithValue("@PhoneNumber", Phone);
                            updatePerson.Parameters.AddWithValue("@ID", EID);
                        
                            updatePerson.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Phone Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Address.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePerson.CommandText = "UPDATE Person SET Address = ? WHERE ID = ?";
                            updatePerson.Parameters.AddWithValue("@Address", Address);
                            updatePerson.Parameters.AddWithValue("@ID", EID);
                        
                            updatePerson.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Address Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Sex.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePerson.CommandText = "UPDATE Person SET Sex = ? WHERE ID = ?";
                            updatePerson.Parameters.AddWithValue("@Sex", Sex);
                            updatePerson.Parameters.AddWithValue("@ID", EID);

                            updatePerson.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Sex Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Salary.CompareTo("") != 0)
                    {
                        try
                        {
                            updateEmployee.CommandText = "UPDATE Employee SET Salary = ? WHERE EID = ?";
                            updateEmployee.Parameters.AddWithValue("@Salary", Salary);
                            updateEmployee.Parameters.AddWithValue("@EID", EID);

                            updateEmployee.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Salary Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (StartDate.CompareTo("") != 0)
                    {
                        try
                        {
                            updateEmployee.CommandText = "UPDATE Employee SET StartDate = ? WHERE EID = ?";
                            updateEmployee.Parameters.AddWithValue("@StartDate", StartDate);
                            updateEmployee.Parameters.AddWithValue("@EID", EID);

                            updateEmployee.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Start Date Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Manager.CompareTo("") != 0)
                    {
                        try
                        {
                            updateEmployee.CommandText = "UPDATE Employee SET ManagerID = ? WHERE EID = ?";
                            updateEmployee.Parameters.AddWithValue("@ManagerID", Manager);
                            updateEmployee.Parameters.AddWithValue("@EID", EID);

                            updateEmployee.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Manager Field Error";
                            Error.ShowDialog();
                        }
                    }
                }

                PersonIDBox.Clear();
                PersonNameBox.Clear();
                PersonPhoneBox.Clear();
                PersonAddressBox.Clear();
                PersonSexBox.Clear();
                PersonOther1Box.Clear();
                PersonOther2Box.Clear();
                PersonOther3Box.Clear();
                
                Employee = false;
                EmployeeCheck.IsChecked = false;
                CustomerCheck.Visibility = Visibility.Visible;
                PersonOther1Box.Visibility = Visibility.Collapsed;
                PersonOther1Label.Visibility = Visibility.Collapsed;
                PersonOther2Box.Visibility = Visibility.Collapsed;
                PersonOther2Label.Visibility = Visibility.Collapsed;
                PersonOther3Box.Visibility = Visibility.Collapsed;
                PersonOther3Label.Visibility = Visibility.Collapsed;
            }
            else if (Customer)
            {
                string CID = PersonIDBox.GetLineText(0);
                string Name = PersonNameBox.GetLineText(0);
                string Phone = PersonPhoneBox.GetLineText(0);
                string Address = PersonAddressBox.GetLineText(0);
                string Sex = PersonSexBox.GetLineText(0);
                string Type = PersonOther1Box.GetLineText(0);

                //SQL
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand updatePerson = cn.CreateCommand();
                OleDbCommand updateCustomer = cn.CreateCommand();
                OleDbCommand selectCustomer = cn.CreateCommand();

                selectCustomer.CommandText = "SELECT CID FROM Customer WHERE CID = @CID";
                selectCustomer.Parameters.AddWithValue("@CID", CID);

                if (CID.CompareTo("") == 0 || selectCustomer.ExecuteScalar() == null)
                {
                    ErrorWindow Error = new ErrorWindow("Please enter a valid CID");
                    Error.Title = "CID Field Error";
                    Error.ShowDialog();
                }
                else
                {
                    if (Name.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePerson.CommandText = "UPDATE Person SET PersonName = ? WHERE ID = ?";
                            updatePerson.Parameters.AddWithValue("@PersonName", Name);
                            updatePerson.Parameters.AddWithValue("@ID", CID);

                            updatePerson.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Name Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Phone.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePerson.CommandText = "UPDATE Person SET PhoneNumber = ? WHERE ID = ?";
                            updatePerson.Parameters.AddWithValue("@PhoneNumber", Phone);
                            updatePerson.Parameters.AddWithValue("@ID", CID);

                            updatePerson.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Phone Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Address.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePerson.CommandText = "UPDATE Person SET Address = ? WHERE ID = ?";
                            updatePerson.Parameters.AddWithValue("@Address", Address);
                            updatePerson.Parameters.AddWithValue("@ID", CID);

                            updatePerson.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Address Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Sex.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePerson.CommandText = "UPDATE Person SET Sex = ? WHERE ID = ?";
                            updatePerson.Parameters.AddWithValue("@Sex", Sex);
                            updatePerson.Parameters.AddWithValue("@ID", CID);

                            updatePerson.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Sex Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Type.CompareTo("") != 0)
                    {
                        try
                        {
                            updateCustomer.CommandText = "UPDATE Customer SET Type = ? WHERE CID = ?";
                            updateCustomer.Parameters.AddWithValue("@Type", Type);
                            updateCustomer.Parameters.AddWithValue("@CID", CID);

                            updateCustomer.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Salary Field Error";
                            Error.ShowDialog();
                        }
                    }
                }

                PersonIDBox.Clear();
                PersonNameBox.Clear();
                PersonPhoneBox.Clear();
                PersonAddressBox.Clear();
                PersonSexBox.Clear();
                PersonOther1Box.Clear();

                Customer = false;
                CustomerCheck.IsChecked = false;
                EmployeeCheck.Visibility = Visibility.Visible;
                PersonOther1Box.Visibility = Visibility.Collapsed;
                PersonOther1Label.Visibility = Visibility.Collapsed;
            }
        }
        private void SubmitVehicle_Click(object sender, RoutedEventArgs e)
        {
            if (Car)
            {
                string VIN = VINBox.GetLineText(0);
                string Model = VehicleModelBox.GetLineText(0);
                string YearProd = VehicleYearBox.GetLineText(0);
                string Maker = VehicleMakerBox.GetLineText(0);
                string NumberSeats = VehicleSeatsBox.GetLineText(0);
                string Price = VehiclePriceBox.GetLineText(0);
                string Type = VehicleOther1Box.GetLineText(0);

                //SQL
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand updateVehicle = cn.CreateCommand();
                OleDbCommand updateCar = cn.CreateCommand();
                OleDbCommand selectCar = cn.CreateCommand();

                selectCar.CommandText = "SELECT VIN FROM Car WHERE VIN = @VIN";
                selectCar.Parameters.AddWithValue("@VIN", VIN);

                if (VIN.CompareTo("") == 0 || selectCar.ExecuteScalar() == null)
                {
                    ErrorWindow Error = new ErrorWindow("Please enter a valid VIN");
                    Error.Title = "VIN Field Error";
                    Error.ShowDialog();
                }
                else
                {
                    if (Model.CompareTo("") != 0)
                    {
                        try
                        {
                            updateVehicle.CommandText = "UPDATE Vehicle SET Model = ? WHERE VIN = ?";
                            updateVehicle.Parameters.AddWithValue("@Model", Model);
                            updateVehicle.Parameters.AddWithValue("@VIN", VIN);

                            updateVehicle.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Model Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (YearProd.CompareTo("") != 0)
                    {
                        try
                        {
                            updateVehicle.CommandText = "UPDATE Vehicle SET YearProd = ? WHERE VIN = ?";
                            updateVehicle.Parameters.AddWithValue("@YearProd", YearProd);
                            updateVehicle.Parameters.AddWithValue("@VIN", VIN);

                            updateVehicle.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Year Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Maker.CompareTo("") != 0)
                    {
                        try
                        {
                            updateVehicle.CommandText = "UPDATE Vehicle SET Maker = ? WHERE VIN = ?";
                            updateVehicle.Parameters.AddWithValue("@Maker", Maker);
                            updateVehicle.Parameters.AddWithValue("@VIN", VIN);

                            updateVehicle.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Maker Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (NumberSeats.CompareTo("") != 0)
                    {
                        try
                        {
                            updateVehicle.CommandText = "UPDATE Vehicle SET NumberSeats = ? WHERE VIN = ?";
                            updateVehicle.Parameters.AddWithValue("@NumberSeats", NumberSeats);
                            updateVehicle.Parameters.AddWithValue("@VIN", VIN);

                            updateVehicle.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Number of Seats Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Price.CompareTo("") != 0)
                    {
                        try
                        {
                            updateVehicle.CommandText = "UPDATE Vehicle SET Price = ? WHERE VIN = ?";
                            updateVehicle.Parameters.AddWithValue("@Price", Price);
                            updateVehicle.Parameters.AddWithValue("@VIN", VIN);

                            updateVehicle.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Price Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Type.CompareTo("") != 0)
                    {
                        try
                        {
                            updateCar.CommandText = "UPDATE Car SET Type = ? WHERE VIN = ?";
                            updateCar.Parameters.AddWithValue("@Type", Type);
                            updateCar.Parameters.AddWithValue("@VIN", VIN);

                            updateCar.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Type Field Error";
                            Error.ShowDialog();
                        }
                    }
                }

                VINBox.Clear();
                VehicleModelBox.Clear();
                VehicleYearBox.Clear();
                VehicleMakerBox.Clear();
                VehicleSeatsBox.Clear();
                VehiclePriceBox.Clear();
                VehicleOther1Box.Clear();

                Car = false;
                CarCheck.IsChecked = false;
                TruckCheck.Visibility = Visibility.Visible;
                VehicleOther1Box.Visibility = Visibility.Collapsed;
                VehicleOther1Label.Visibility = Visibility.Collapsed;
            }
            else if (Truck)
            {
                string VIN = VINBox.GetLineText(0);
                string Model = VehicleModelBox.GetLineText(0);
                string YearProd = VehicleYearBox.GetLineText(0);
                string Maker = VehicleMakerBox.GetLineText(0);
                string NumberSeats = VehicleSeatsBox.GetLineText(0);
                string Price = VehiclePriceBox.GetLineText(0);
                string TowingCapacity = VehicleOther1Box.GetLineText(0);
                
                //SQL
                //SQL
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand updateVehicle = cn.CreateCommand();
                OleDbCommand updateTruck = cn.CreateCommand();
                OleDbCommand selectTruck = cn.CreateCommand();

                selectTruck.CommandText = "SELECT VIN FROM Truck WHERE VIN = @VIN";
                selectTruck.Parameters.AddWithValue("@VIN", VIN);

                if (VIN.CompareTo("") == 0 || selectTruck.ExecuteScalar() == null)
                {
                    ErrorWindow Error = new ErrorWindow("Please enter a valid VIN");
                    Error.Title = "VIN Field Error";
                    Error.ShowDialog();
                }
                else
                {
                    if (Model.CompareTo("") != 0)
                    {
                        try
                        {
                            updateVehicle.CommandText = "UPDATE Vehicle SET Model = ? WHERE VIN = ?";
                            updateVehicle.Parameters.AddWithValue("@Model", Model);
                            updateVehicle.Parameters.AddWithValue("@VIN", VIN);

                            updateVehicle.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Model Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (YearProd.CompareTo("") != 0)
                    {
                        try
                        {
                            updateVehicle.CommandText = "UPDATE Vehicle SET YearProd = ? WHERE VIN = ?";
                            updateVehicle.Parameters.AddWithValue("@YearProd", YearProd);
                            updateVehicle.Parameters.AddWithValue("@VIN", VIN);

                            updateVehicle.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Year Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Maker.CompareTo("") != 0)
                    {
                        try
                        {
                            updateVehicle.CommandText = "UPDATE Vehicle SET Maker = ? WHERE VIN = ?";
                            updateVehicle.Parameters.AddWithValue("@Maker", Maker);
                            updateVehicle.Parameters.AddWithValue("@VIN", VIN);

                            updateVehicle.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Maker Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (NumberSeats.CompareTo("") != 0)
                    {
                        try
                        {
                            updateVehicle.CommandText = "UPDATE Vehicle SET NumberSeats = ? WHERE VIN = ?";
                            updateVehicle.Parameters.AddWithValue("@NumberSeats", NumberSeats);
                            updateVehicle.Parameters.AddWithValue("@VIN", VIN);

                            updateVehicle.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Number of Seats Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Price.CompareTo("") != 0)
                    {
                        try
                        {
                            updateVehicle.CommandText = "UPDATE Vehicle SET Price = ? WHERE VIN = ?";
                            updateVehicle.Parameters.AddWithValue("@Price", Price);
                            updateVehicle.Parameters.AddWithValue("@VIN", VIN);

                            updateVehicle.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Price Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (TowingCapacity.CompareTo("") != 0)
                    {
                        try
                        {
                            updateTruck.CommandText = "UPDATE Truck SET TowingCapacity = ? WHERE VIN = ?";
                            updateTruck.Parameters.AddWithValue("@TowingCapacity", TowingCapacity);
                            updateTruck.Parameters.AddWithValue("@VIN", VIN);

                            updateTruck.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "TowingCapacity Field Error";
                            Error.ShowDialog();
                        }
                    }
                }

                VINBox.Clear();
                VehicleModelBox.Clear();
                VehicleYearBox.Clear();
                VehicleMakerBox.Clear();
                VehicleSeatsBox.Clear();
                VehiclePriceBox.Clear();
                VehicleOther1Box.Clear();

                Truck = false;
                TruckCheck.IsChecked = false;
                CarCheck.Visibility = Visibility.Visible;
                VehicleOther1Box.Visibility = Visibility.Collapsed;
                VehicleOther1Label.Visibility = Visibility.Collapsed;
            }
        }
        private void SubmitVHR_Click(object sender, RoutedEventArgs e)
        {
            string VIN = VHRVINBox.GetLineText(0);
            string NumberOwners = VHRPreviousOwnersBox.GetLineText(0);
            string Rating = VHRRatingBox.GetLineText(0);
            string Mileage = VHRMileageBox.GetLineText(0);

            //SQL
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand updateVHR = cn.CreateCommand();
            OleDbCommand selectVHR = cn.CreateCommand();

            selectVHR.CommandText = "SELECT VIN FROM VehicleHistoryReport WHERE VIN = @VIN";
            selectVHR.Parameters.AddWithValue("@VIN", VIN);

            if (VIN.CompareTo("") == 0 || selectVHR.ExecuteScalar() == null)
            {
                ErrorWindow Error = new ErrorWindow("Please enter a valid VIN");
                Error.Title = "VIN Field Error";
                Error.ShowDialog();
            }
            else
            {
                if (NumberOwners.CompareTo("") != 0)
                {
                    try
                    {
                        updateVHR.CommandText = "UPDATE VehicleHistoryReport SET NumberOwners = ? WHERE VIN = ?";
                        updateVHR.Parameters.AddWithValue("@NumberOwners", NumberOwners);
                        updateVHR.Parameters.AddWithValue("@VIN", VIN);

                        updateVHR.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Number of Owners Field Error";
                        Error.ShowDialog();
                    }
                }
                if (Rating.CompareTo("") != 0)
                {
                    try
                    {
                        updateVHR.CommandText = "UPDATE VehicleHistoryReport SET Rating = ? WHERE VIN = ?";
                        updateVHR.Parameters.AddWithValue("@Rating", Rating);
                        updateVHR.Parameters.AddWithValue("@VIN", VIN);

                        updateVHR.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Rating Field Error";
                        Error.ShowDialog();
                    }
                }
                if (Mileage.CompareTo("") != 0)
                {
                    try
                    {
                        updateVHR.CommandText = "UPDATE VehicleHistoryReport SET Mileage = ? WHERE VIN = ?";
                        updateVHR.Parameters.AddWithValue("@Mileage", Mileage);
                        updateVHR.Parameters.AddWithValue("@VIN", VIN);

                        updateVHR.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Mileage Field Error";
                        Error.ShowDialog();
                    }
                }
            }

            VHRVINBox.Clear();
            VHRPreviousOwnersBox.Clear();
            VHRRatingBox.Clear();
            VHRMileageBox.Clear();
        }
        private void SubmitPart_Click(object sender, RoutedEventArgs e)
        {
            if (Tires)
            {
                string SerialNumber = PartSerialNumberBox.GetLineText(0);
                string VIN = PartVINBox.GetLineText(0);
                string PartName = PartNameBox.GetLineText(0);
                string Manufacturer = PartManufacturerBox.GetLineText(0);
                string Type = PartOther2Box.GetLineText(0);
                string TireSize = PartOther1Box.GetLineText(0);
                
                //SQL
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand updatePart = cn.CreateCommand();
                OleDbCommand updateTire = cn.CreateCommand();
                OleDbCommand selectTire = cn.CreateCommand();

                selectTire.CommandText = "SELECT SerialNumber FROM Tire WHERE SerialNumber = @SerialNumber";
                selectTire.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                if (VIN.CompareTo("") == 0 || selectTire.ExecuteScalar() == null)
                {
                    ErrorWindow Error = new ErrorWindow("Please enter a valid Serial Number");
                    Error.Title = "Serial# Field Error";
                    Error.ShowDialog();
                }
                else
                {
                    if (VIN.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePart.CommandText = "UPDATE Part SET VIN = ? WHERE SerialNumber = ?";
                            updatePart.Parameters.AddWithValue("@VIN", VIN);
                            updatePart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updatePart.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "VIN Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (PartName.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePart.CommandText = "UPDATE Part SET PartName = ? WHERE SerialNumber = ?";
                            updatePart.Parameters.AddWithValue("@PartName", PartName);
                            updatePart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updatePart.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "PartName Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Manufacturer.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePart.CommandText = "UPDATE Part SET Manufacturer = ? WHERE SerialNumber = ?";
                            updatePart.Parameters.AddWithValue("@Manufacturer", Manufacturer);
                            updatePart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updatePart.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Manufacturer Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Type.CompareTo("") != 0)
                    {
                        try
                        {
                            updateTire.CommandText = "UPDATE Tire SET Type = ? WHERE SerialNumber = ?";
                            updateTire.Parameters.AddWithValue("@NumberSeats", Type);
                            updateTire.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updateTire.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Type Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (TireSize.CompareTo("") != 0)
                    {
                        try
                        {
                            updateTire.CommandText = "UPDATE Tire SET TireSize = ? WHERE SerialNumber = ?";
                            updateTire.Parameters.AddWithValue("@TireSize", TireSize);
                            updateTire.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updateTire.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Size Field Error";
                            Error.ShowDialog();
                        }
                    }
                }

                PartSerialNumberBox.Clear();
                PartVINBox.Clear();
                PartNameBox.Clear();
                PartManufacturerBox.Clear();
                PartOther1Box.Clear();
                PartOther2Box.Clear();

                Tires = false;
                TiresCheck.IsChecked = false;
                EngineCheck.Visibility = Visibility.Visible;
                OtherPartCheck.Visibility = Visibility.Visible;
                PartOther1Box.Visibility = Visibility.Collapsed;
                PartOther1Label.Visibility = Visibility.Collapsed;
                PartOther2Box.Visibility = Visibility.Collapsed;
                PartOther2Label.Visibility = Visibility.Collapsed;
            }
            else if (Engine)
            {
                string SerialNumber = PartSerialNumberBox.GetLineText(0);
                string VIN = PartVINBox.GetLineText(0);
                string PartName = PartNameBox.GetLineText(0);
                string Manufacturer = PartManufacturerBox.GetLineText(0);
                string HorsePower = PartOther2Box.GetLineText(0);
                string Cylinders = PartOther1Box.GetLineText(0);
                
                //SQL
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand updatePart = cn.CreateCommand();
                OleDbCommand updateEngine = cn.CreateCommand();
                OleDbCommand selectEngine = cn.CreateCommand();

                selectEngine.CommandText = "SELECT SerialNumber FROM Engine WHERE SerialNumber = @SerialNumber";
                selectEngine.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                if (VIN.CompareTo("") == 0 || selectEngine.ExecuteScalar() == null)
                {
                    ErrorWindow Error = new ErrorWindow("Please enter a valid Serial Number");
                    Error.Title = "Serial# Field Error";
                    Error.ShowDialog();
                }
                else
                {
                    if (VIN.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePart.CommandText = "UPDATE Part SET VIN = ? WHERE SerialNumber = ?";
                            updatePart.Parameters.AddWithValue("@VIN", VIN);
                            updatePart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updatePart.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "VIN Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (PartName.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePart.CommandText = "UPDATE Part SET PartName = ? WHERE SerialNumber = ?";
                            updatePart.Parameters.AddWithValue("@PartName", PartName);
                            updatePart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updatePart.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "PartName Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Manufacturer.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePart.CommandText = "UPDATE Part SET Manufacturer = ? WHERE SerialNumber = ?";
                            updatePart.Parameters.AddWithValue("@Manufacturer", Manufacturer);
                            updatePart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updatePart.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Manufacturer Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Cylinders.CompareTo("") != 0)
                    {
                        try
                        {
                            updateEngine.CommandText = "UPDATE Engine SET Cylinders = ? WHERE SerialNumber = ?";
                            updateEngine.Parameters.AddWithValue("@Cylinders", Cylinders);
                            updateEngine.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updateEngine.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Cylinders Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (HorsePower.CompareTo("") != 0)
                    {
                        try
                        {
                            updateEngine.CommandText = "UPDATE Engine SET HorsePower = ? WHERE SerialNumber = ?";
                            updateEngine.Parameters.AddWithValue("@HorsePower", HorsePower);
                            updateEngine.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updateEngine.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "HorsePower Field Error";
                            Error.ShowDialog();
                        }
                    }
                }

                PartSerialNumberBox.Clear();
                PartVINBox.Clear();
                PartNameBox.Clear();
                PartManufacturerBox.Clear();
                PartOther1Box.Clear();
                PartOther2Box.Clear();

                Engine = false;
                EngineCheck.IsChecked = false;
                TiresCheck.Visibility = Visibility.Visible;
                OtherPartCheck.Visibility = Visibility.Visible;
                PartOther1Box.Visibility = Visibility.Collapsed;
                PartOther1Label.Visibility = Visibility.Collapsed;
                PartOther2Box.Visibility = Visibility.Collapsed;
                PartOther2Label.Visibility = Visibility.Collapsed;
            }
            else if (Part)
            {
                string SerialNumber = PartSerialNumberBox.GetLineText(0);
                string VIN = PartVINBox.GetLineText(0);
                string PartName = PartNameBox.GetLineText(0);
                string Manufacturer = PartManufacturerBox.GetLineText(0);

                //SQL
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand updatePart = cn.CreateCommand();
                OleDbCommand selectPart = cn.CreateCommand();

                selectPart.CommandText = "SELECT SerialNumber FROM Part WHERE SerialNumber = @SerialNumber";
                selectPart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                if (VIN.CompareTo("") == 0 || selectPart.ExecuteScalar() == null)
                {
                    ErrorWindow Error = new ErrorWindow("Please enter a valid Serial Number");
                    Error.Title = "Serial# Field Error";
                    Error.ShowDialog();
                }
                else
                {
                    if (VIN.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePart.CommandText = "UPDATE Part SET VIN = ? WHERE SerialNumber = ?";
                            updatePart.Parameters.AddWithValue("@VIN", VIN);
                            updatePart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updatePart.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "VIN Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (PartName.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePart.CommandText = "UPDATE Part SET PartName = ? WHERE SerialNumber = ?";
                            updatePart.Parameters.AddWithValue("@PartName", PartName);
                            updatePart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updatePart.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "PartName Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (Manufacturer.CompareTo("") != 0)
                    {
                        try
                        {
                            updatePart.CommandText = "UPDATE Part SET Manufacturer = ? WHERE SerialNumber = ?";
                            updatePart.Parameters.AddWithValue("@Manufacturer", Manufacturer);
                            updatePart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                            updatePart.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Manufacturer Field Error";
                            Error.ShowDialog();
                        }
                    }
                }

                PartSerialNumberBox.Clear();
                PartVINBox.Clear();
                PartNameBox.Clear();
                PartManufacturerBox.Clear();

                Part = false;
                OtherPartCheck.IsChecked = false;
                TiresCheck.Visibility = Visibility.Visible;
                EngineCheck.Visibility = Visibility.Visible;
            }
        }
        private void EmployeeCheck_Checked(object sender, RoutedEventArgs e)
        {
            CustomerCheck.Visibility = Visibility.Collapsed;
            PersonOther1Box.Visibility = Visibility.Visible;
            PersonOther1Label.Visibility = Visibility.Visible;
            PersonOther2Box.Visibility = Visibility.Visible;
            PersonOther2Label.Visibility = Visibility.Visible;
            PersonOther3Box.Visibility = Visibility.Visible;
            PersonOther3Label.Visibility = Visibility.Visible;
            PersonOther1Label.Text = "Salary";
            PersonOther2Label.Text = "Start Date";
            PersonOther3Label.Text = "Manager EID";
            Employee = true;
        }
        private void CustomerCheck_Checked(object sender, RoutedEventArgs e)
        {
            EmployeeCheck.Visibility = Visibility.Collapsed;
            PersonOther1Box.Visibility = Visibility.Visible;
            PersonOther1Label.Visibility = Visibility.Visible;
            PersonOther1Label.Text = "Type";
            Customer = true;
        }
        private void CarCheck_Checked(object sender, RoutedEventArgs e)
        {
            TruckCheck.Visibility = Visibility.Collapsed;
            VehicleOther1Box.Visibility = Visibility.Visible;
            VehicleOther1Label.Visibility = Visibility.Visible;
            VehicleOther1Label.Text = "Type";
            Car = true;

        }
        private void TruckCheck_Checked(object sender, RoutedEventArgs e)
        {
            CarCheck.Visibility = Visibility.Collapsed;
            VehicleOther1Box.Visibility = Visibility.Visible;
            VehicleOther1Label.Visibility = Visibility.Visible;
            VehicleOther1Label.Text = "Towing Capacity (Tonnes)";
            Truck = true;
        }
        private void EngineCheck_Checked(object sender, RoutedEventArgs e)
        {
            TiresCheck.Visibility = Visibility.Collapsed;
            OtherPartCheck.Visibility = Visibility.Collapsed;
            PartOther1Box.Visibility = Visibility.Visible;
            PartOther1Label.Visibility = Visibility.Visible;
            PartOther2Box.Visibility = Visibility.Visible;
            PartOther2Label.Visibility = Visibility.Visible;
            Engine = true;
            PartOther1Label.Text = "Cylinders";
            PartOther2Label.Text = "HorsePower";
        }
        private void TiresCheck_Checked(object sender, RoutedEventArgs e)
        {
            EngineCheck.Visibility = Visibility.Collapsed;
            OtherPartCheck.Visibility = Visibility.Collapsed;
            PartOther1Box.Visibility = Visibility.Visible;
            PartOther1Label.Visibility = Visibility.Visible;
            PartOther2Box.Visibility = Visibility.Visible;
            PartOther2Label.Visibility = Visibility.Visible;
            Tires = true;
            PartOther1Label.Text = "Size";
            PartOther2Label.Text = "Type";
        }
        private void OtherPartCheck_Checked(object sender, RoutedEventArgs e)
        {
            EngineCheck.Visibility = Visibility.Collapsed;
            TiresCheck.Visibility = Visibility.Collapsed;
            Part = true;
        }
        private void EmployeeCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            CustomerCheck.Visibility = Visibility.Visible;
            PersonOther1Box.Visibility = Visibility.Collapsed;
            PersonOther1Label.Visibility = Visibility.Collapsed;
            PersonOther2Box.Visibility = Visibility.Collapsed;
            PersonOther2Label.Visibility = Visibility.Collapsed;
            PersonOther3Box.Visibility = Visibility.Collapsed;
            PersonOther3Label.Visibility = Visibility.Collapsed;
            Employee = false;
        }
        private void CustomerCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            EmployeeCheck.Visibility = Visibility.Visible;
            PersonOther1Box.Visibility = Visibility.Collapsed;
            PersonOther1Label.Visibility = Visibility.Collapsed;
            Customer = false;
        }
        private void CarCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            TruckCheck.Visibility = Visibility.Visible;
            VehicleOther1Box.Visibility = Visibility.Collapsed;
            VehicleOther1Label.Visibility = Visibility.Collapsed;
            Car = false;

        }
        private void TruckCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            CarCheck.Visibility = Visibility.Visible;
            VehicleOther1Box.Visibility = Visibility.Collapsed;
            VehicleOther1Label.Visibility = Visibility.Collapsed;
            Truck = false;
        }
        private void EngineCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            TiresCheck.Visibility = Visibility.Visible;
            OtherPartCheck.Visibility = Visibility.Visible;
            PartOther1Box.Visibility = Visibility.Collapsed;
            PartOther1Label.Visibility = Visibility.Collapsed;
            PartOther2Box.Visibility = Visibility.Collapsed;
            PartOther2Label.Visibility = Visibility.Collapsed;
            Engine = false;
        }
        private void TiresCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            EngineCheck.Visibility = Visibility.Visible;
            OtherPartCheck.Visibility = Visibility.Visible;
            PartOther1Box.Visibility = Visibility.Collapsed;
            PartOther1Label.Visibility = Visibility.Collapsed;
            PartOther2Box.Visibility = Visibility.Collapsed;
            PartOther2Label.Visibility = Visibility.Collapsed;
            Tires = false;
        }
        private void OtherPartCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            EngineCheck.Visibility = Visibility.Visible;
            TiresCheck.Visibility = Visibility.Visible;
            Part = false;
        }
    }
}
