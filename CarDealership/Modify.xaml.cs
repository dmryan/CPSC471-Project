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
                OleDbCommand viewEmployee = cn.CreateCommand();
                OleDbCommand updatePerson = cn.CreateCommand();
                OleDbCommand updateEmployee = cn.CreateCommand();

                viewEmployee.CommandText = "SELECT * FROM Person INNER JOIN Employee ON Person.ID = Employee.EID WHERE ID = @EID";
                updatePerson.CommandText = "UPDATE Person SET PersonName = ?, PhoneNumber = ?, Address = ?, Sex = ? WHERE ID = ?";
                updateEmployee.CommandText = "UPDATE Employee SET Salary = ?, StartDate = ?, ManagerID = ? WHERE EID = ?";

                viewEmployee.Parameters.AddWithValue("@EID", EID);

                try
                {
                    da.SelectCommand = viewEmployee;
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        ErrorWindow Error = new ErrorWindow("Required field does not match any values within the database.");
                        Error.ShowDialog();
                        return;
                    }

                    if (Name != "")
                        updatePerson.Parameters.AddWithValue("@PersonName", Name);
                    else
                        updatePerson.Parameters.AddWithValue("@PersonName", dt.Rows[0]["PersonName"].ToString());
                    if (Phone != "")
                        updatePerson.Parameters.AddWithValue("@PhoneNumber", Phone);
                    else
                        updatePerson.Parameters.AddWithValue("@PhoneNumber", dt.Rows[0]["PhoneNumber"].ToString());
                    if (Address != "")
                        updatePerson.Parameters.AddWithValue("@Address", Address);
                    else
                        updatePerson.Parameters.AddWithValue("@Address", dt.Rows[0]["Address"].ToString());
                    if (Sex != "")
                        updatePerson.Parameters.AddWithValue("@Sex", Sex);
                    else
                        updatePerson.Parameters.AddWithValue("@Sex", dt.Rows[0]["Sex"].ToString());
                    updatePerson.Parameters.AddWithValue("@ID", EID);

                    Console.WriteLine(Address);
                    if (Salary != "")
                        updateEmployee.Parameters.AddWithValue("@Salary", Salary);
                    else
                        updateEmployee.Parameters.AddWithValue("@Salary", dt.Rows[0]["Salary"].ToString());
                    if (StartDate != "")
                        updateEmployee.Parameters.AddWithValue("@StartDate", StartDate);
                    else
                        updateEmployee.Parameters.AddWithValue("@StartDate", dt.Rows[0]["StartDate"].ToString());
                    if (Manager != "")
                        updateEmployee.Parameters.AddWithValue("@ManagerID", Manager);
                    else
                        updateEmployee.Parameters.AddWithValue("@ManagerID", dt.Rows[0]["ManagerID"].ToString());
                    updateEmployee.Parameters.AddWithValue("@EID", EID);

                    updatePerson.ExecuteNonQuery();
                    updateEmployee.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                    return;
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
                OleDbCommand viewCustomer = cn.CreateCommand();
                OleDbCommand updatePerson = cn.CreateCommand();
                OleDbCommand updateCustomer = cn.CreateCommand();

                viewCustomer.CommandText = "SELECT * FROM Person INNER JOIN Customer ON Person.ID = Customer.CID WHERE ID = @CID";
                updatePerson.CommandText = "UPDATE Person SET PersonName = ?, PhoneNumber = ?, Address = ?, Sex = ? WHERE ID = ?";
                updateCustomer.CommandText = "UPDATE Customer SET Type = ? WHERE CID = ?";

                viewCustomer.Parameters.AddWithValue("@CID", CID);

                try
                {
                    da.SelectCommand = viewCustomer;
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        ErrorWindow Error = new ErrorWindow("Required field does not match any values within the database.");
                        Error.ShowDialog();
                        return;
                    }

                    if (Name != "")
                        updatePerson.Parameters.AddWithValue("@PersonName", Name);
                    else
                        updatePerson.Parameters.AddWithValue("@PersonName", dt.Rows[0]["PersonName"].ToString());
                    if (Phone != "")
                        updatePerson.Parameters.AddWithValue("@PhoneNumber", Phone);
                    else
                        updatePerson.Parameters.AddWithValue("@PhoneNumber", dt.Rows[0]["PhoneNumber"].ToString());
                    if (Address != "")
                        updatePerson.Parameters.AddWithValue("@Address", Address);
                    else
                        updatePerson.Parameters.AddWithValue("@Address", dt.Rows[0]["Address"].ToString());
                    if (Sex != "")
                        updatePerson.Parameters.AddWithValue("@Sex", Sex);
                    else
                        updatePerson.Parameters.AddWithValue("@Sex", dt.Rows[0]["Sex"].ToString());
                    updatePerson.Parameters.AddWithValue("@ID", CID);

                    if (Type != "")
                        updateCustomer.Parameters.AddWithValue("@Type", Type);
                    else
                        updateCustomer.Parameters.AddWithValue("@Type", dt.Rows[0]["Type"].ToString());
                    updateCustomer.Parameters.AddWithValue("@CID", CID);

                    updatePerson.ExecuteNonQuery();
                    updateCustomer.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                    return;
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
                OleDbCommand viewCar = cn.CreateCommand();
                OleDbCommand updateVehicle = cn.CreateCommand();
                OleDbCommand updateCar = cn.CreateCommand();

                viewCar.CommandText = "SELECT * FROM Vehicle INNER JOIN Car ON Vehicle.VIN = Car.VIN WHERE Vehicle.VIN = @VIN";
                updateVehicle.CommandText = "UPDATE Vehicle SET Model = ?, YearProd = ?, Maker = ?, NumberSeats = ?, Price = ? WHERE VIN = ?";
                updateCar.CommandText = "UPDATE Car SET Type = ? WHERE VIN = ?";

                viewCar.Parameters.AddWithValue("@VIN", VIN);

                try
                {
                    da.SelectCommand = viewCar;
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        ErrorWindow Error = new ErrorWindow("Required field does not match any values within the database.");
                        Error.ShowDialog();
                        return;
                    }

                    if (Model != "")
                        updateVehicle.Parameters.AddWithValue("@Model", Model);
                    else
                        updateVehicle.Parameters.AddWithValue("@Model", dt.Rows[0]["Model"].ToString());
                    if (YearProd != "")
                        updateVehicle.Parameters.AddWithValue("@YearProd", YearProd);
                    else
                        updateVehicle.Parameters.AddWithValue("@YearProd", dt.Rows[0]["YearProd"].ToString());
                    if (Maker != "")
                        updateVehicle.Parameters.AddWithValue("@Maker", Maker);
                    else
                        updateVehicle.Parameters.AddWithValue("@Maker", dt.Rows[0]["Maker"].ToString());
                    if (NumberSeats != "")
                        updateVehicle.Parameters.AddWithValue("@NumberSeats", NumberSeats);
                    else
                        updateVehicle.Parameters.AddWithValue("@NumberSeats", dt.Rows[0]["NumberSeats"].ToString());
                    if (Price != "")
                        updateVehicle.Parameters.AddWithValue("@Price", Price);
                    else
                        updateVehicle.Parameters.AddWithValue("@Price", dt.Rows[0]["Price"].ToString());
                    updateVehicle.Parameters.AddWithValue("@VIN", VIN);


                    if (Type != "")
                        updateCar.Parameters.AddWithValue("@Type", Type);
                    else
                        updateCar.Parameters.AddWithValue("@Type", dt.Rows[0]["Type"].ToString());
                    updateCar.Parameters.AddWithValue("@VIN", VIN);

                    updateVehicle.ExecuteNonQuery();
                    updateCar.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                    return;
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
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand viewTruck = cn.CreateCommand();
                OleDbCommand updateVehicle = cn.CreateCommand();
                OleDbCommand updateTruck = cn.CreateCommand();

                viewTruck.CommandText = "SELECT * FROM Vehicle INNER JOIN Truck ON Vehicle.VIN = Truck.VIN WHERE Vehicle.VIN = @VIN";
                updateVehicle.CommandText = "UPDATE Vehicle SET Model = ?, YearProd = ?, Maker = ?, NumberSeats = ?, Price = ? WHERE VIN = ?";
                updateTruck.CommandText = "UPDATE Truck SET TowingCapacity = ? WHERE VIN = ?";

                viewTruck.Parameters.AddWithValue("@VIN", VIN);

                try
                {
                    da.SelectCommand = viewTruck;
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        ErrorWindow Error = new ErrorWindow("Required field does not match any values within the database.");
                        Error.ShowDialog();
                        return;
                    }

                    if (Model != "")
                        updateVehicle.Parameters.AddWithValue("@Model", Model);
                    else
                        updateVehicle.Parameters.AddWithValue("@Model", dt.Rows[0]["Model"].ToString());
                    if (YearProd != "")
                        updateVehicle.Parameters.AddWithValue("@YearProd", YearProd);
                    else
                        updateVehicle.Parameters.AddWithValue("@YearProd", dt.Rows[0]["YearProd"].ToString());
                    if (Maker != "")
                        updateVehicle.Parameters.AddWithValue("@Maker", Maker);
                    else
                        updateVehicle.Parameters.AddWithValue("@Maker", dt.Rows[0]["Maker"].ToString());
                    if (NumberSeats != "")
                        updateVehicle.Parameters.AddWithValue("@NumberSeats", NumberSeats);
                    else
                        updateVehicle.Parameters.AddWithValue("@NumberSeats", dt.Rows[0]["NumberSeats"].ToString());
                    if (Price != "")
                        updateVehicle.Parameters.AddWithValue("@Price", Price);
                    else
                        updateVehicle.Parameters.AddWithValue("@Price", dt.Rows[0]["Price"].ToString());
                    updateVehicle.Parameters.AddWithValue("@VIN", VIN);


                    if (TowingCapacity != "")
                        updateTruck.Parameters.AddWithValue("@TowingCapacity", TowingCapacity);
                    else
                        updateTruck.Parameters.AddWithValue("@TowingCapacity", dt.Rows[0]["TowingCapacity"].ToString());
                    updateTruck.Parameters.AddWithValue("@VIN", VIN);

                    updateVehicle.ExecuteNonQuery();
                    updateTruck.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                    return;
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
            OleDbCommand viewVHR = cn.CreateCommand();
            OleDbCommand updateVHR = cn.CreateCommand();

            viewVHR.CommandText = "SELECT * FROM VehicleHistoryReport WHERE VIN = @VIN";
            updateVHR.CommandText = "UPDATE VehicleHistoryReport SET NumberOwners = ?, Rating = ?, Mileage = ? WHERE VIN = ?";

            viewVHR.Parameters.AddWithValue("@VIN", VIN);
           
            try
            {
                da.SelectCommand = viewVHR;
                da.Fill(dt);
 
                if (dt.Rows.Count == 0)
                {
                    ErrorWindow Error = new ErrorWindow("Required field does not match any values within the database.");
                    Error.ShowDialog();
                    return;
                }

                if (NumberOwners != "")
                    updateVHR.Parameters.AddWithValue("@NumberOwners", NumberOwners);
                else
                    updateVHR.Parameters.AddWithValue("@NumberOwners", dt.Rows[0]["NumberOwners"].ToString());
                if (Rating != "")
                    updateVHR.Parameters.AddWithValue("@Rating", Rating);
                else
                    updateVHR.Parameters.AddWithValue("@Rating", dt.Rows[0]["Rating"].ToString());
                if (Mileage != "")
                    updateVHR.Parameters.AddWithValue("@Mileage", Mileage);
                else
                    updateVHR.Parameters.AddWithValue("@Mileage", dt.Rows[0]["Mileage"].ToString());
                updateVHR.Parameters.AddWithValue("@VIN", VIN);

                updateVHR.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
                return;
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
                OleDbCommand viewTire = cn.CreateCommand();
                OleDbCommand updatePart = cn.CreateCommand();
                OleDbCommand updateTire = cn.CreateCommand();

                viewTire.CommandText = "SELECT * FROM Part INNER JOIN Tire ON Part.SerialNumber = Tire.SerialNumber WHERE Part.SerialNumber = @SerialNumber";
                updatePart.CommandText = "UPDATE Part SET VIN = ?, PartName = ?, Manufacturer = ? WHERE SerialNumber = ?";
                updateTire.CommandText = "UPDATE Tire SET Type = ?, TireSize = ? WHERE SerialNumber = ?";

                viewTire.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                try
                {
                    da.SelectCommand = viewTire;
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        ErrorWindow Error = new ErrorWindow("Required field does not match any values within the database.");
                        Error.ShowDialog();
                        return;
                    }

                    if (VIN != "")
                        updatePart.Parameters.AddWithValue("@VIN", VIN);
                    else
                        updatePart.Parameters.AddWithValue("@VIN", dt.Rows[0]["VIN"].ToString());
                    if (PartName != "")
                        updatePart.Parameters.AddWithValue("@PartName", PartName);
                    else
                        updatePart.Parameters.AddWithValue("@PartName", dt.Rows[0]["PartName"].ToString());
                    if (Manufacturer != "")
                        updatePart.Parameters.AddWithValue("@Manufacturer", Manufacturer);
                    else
                        updatePart.Parameters.AddWithValue("@Manufacturer", dt.Rows[0]["Manufacturer"].ToString());
                    updatePart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                    if (Type != "")
                        updateTire.Parameters.AddWithValue("@Type", Type);
                    else
                        updateTire.Parameters.AddWithValue("@Type", dt.Rows[0]["Type"].ToString());
                    if (TireSize != "")
                        updateTire.Parameters.AddWithValue("@TireSize", TireSize);
                    else
                        updateTire.Parameters.AddWithValue("@TireSize", dt.Rows[0]["TireSize"].ToString());
                    updateTire.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                    updatePart.ExecuteNonQuery();
                    updateTire.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                    return;
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
                OleDbCommand viewEngine = cn.CreateCommand();
                OleDbCommand updatePart = cn.CreateCommand();
                OleDbCommand updateEngine = cn.CreateCommand();

                viewEngine.CommandText = "SELECT * FROM Part INNER JOIN Engine ON Part.SerialNumber = Engine.SerialNumber WHERE Part.SerialNumber = @SerialNumber";
                updatePart.CommandText = "UPDATE Part SET VIN = ?, PartName = ?, Manufacturer = ? WHERE SerialNumber = ?";
                updateEngine.CommandText = "UPDATE Engine SET HorsePower = ?, Cylinders = ? WHERE SerialNumber = ?";

                viewEngine.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                try
                {
                    da.SelectCommand = viewEngine;
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        ErrorWindow Error = new ErrorWindow("Required field does not match any values within the database.");
                        Error.ShowDialog();
                        return;
                    }

                    if (VIN != "")
                        updatePart.Parameters.AddWithValue("@VIN", VIN);
                    else
                        updatePart.Parameters.AddWithValue("@VIN", dt.Rows[0]["VIN"].ToString());
                    if (PartName != "")
                        updatePart.Parameters.AddWithValue("@PartName", PartName);
                    else
                        updatePart.Parameters.AddWithValue("@PartName", dt.Rows[0]["PartName"].ToString());
                    if (Manufacturer != "")
                        updatePart.Parameters.AddWithValue("@Manufacturer", Manufacturer);
                    else
                        updatePart.Parameters.AddWithValue("@Manufacturer", dt.Rows[0]["Manufacturer"].ToString());
                    updatePart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                    if (HorsePower != "")
                        updateEngine.Parameters.AddWithValue("@HorsePower", HorsePower);
                    else
                        updateEngine.Parameters.AddWithValue("@HorsePower", dt.Rows[0]["HorsePower"].ToString());
                    if (Cylinders != "")
                        updateEngine.Parameters.AddWithValue("@Cylinders", Cylinders);
                    else
                        updateEngine.Parameters.AddWithValue("@Cylinders", dt.Rows[0]["Cylinders"].ToString());
                    updateEngine.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                    updatePart.ExecuteNonQuery();
                    updateEngine.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                    return;
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
                OleDbCommand viewPart = cn.CreateCommand();
                OleDbCommand updatePart = cn.CreateCommand();
                OleDbCommand selectTire = cn.CreateCommand();
                OleDbCommand selectEngine = cn.CreateCommand();

                viewPart.CommandText = "SELECT VIN, PartName, Manufacturer FROM Part, Engine, Tire WHERE Part.SerialNumber = @SerialNumber";
                updatePart.CommandText = "UPDATE Part SET VIN = ?, PartName = ?, Manufacturer = ? WHERE SerialNumber = ?";
                selectTire.CommandText = "SELECT SerialNumber FROM Tire WHERE SerialNumber = @SerialNumber";
                selectEngine.CommandText = "SELECT SerialNumber FROM Engine WHERE SerialNumber = @SerialNumber";

                viewPart.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                selectTire.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                selectEngine.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                Object temp = selectEngine.ExecuteScalar();
                if( temp == null || temp is DBNull)
                    Console.WriteLine("HEER");
                else
                    Console.WriteLine(temp.ToString());

                try
                {
                    da.SelectCommand = viewPart;
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        ErrorWindow Error = new ErrorWindow("Required field does not match any values within the database.");
                        Error.ShowDialog();
                        return;
                    }

                    if (selectEngine.ExecuteScalar() == null && selectTire.ExecuteScalar() == null )
                        ;
                    else
                    {
                        ErrorWindow Error = new ErrorWindow("Part is of type Engine or Tire. Retry by selecting the specific part you wish to modify.");
                        Error.ShowDialog();
                        return;
                    }

                    if (VIN != "")
                        updatePart.Parameters.AddWithValue("@VIN", VIN);
                    else
                        updatePart.Parameters.AddWithValue("@VIN", dt.Rows[0]["VIN"].ToString());
                    if (PartName != "")
                        updatePart.Parameters.AddWithValue("@PartName", PartName);
                    else
                        updatePart.Parameters.AddWithValue("@PartName", dt.Rows[0]["PartName"].ToString());
                    if (Manufacturer != "")
                        updatePart.Parameters.AddWithValue("@Manufacturer", Manufacturer);
                    else
                        updatePart.Parameters.AddWithValue("@Manufacturer", dt.Rows[0]["Manufacturer"].ToString());
                    updatePart.Parameters.AddWithValue("@SerialNumber", SerialNumber);

                    updatePart.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                    return;
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
