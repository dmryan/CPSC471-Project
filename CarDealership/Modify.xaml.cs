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
    public partial class Mod : Window
    {
        private OleDbConnection cn;
        bool Employee;
        bool Customer;
        bool Truck;
        bool Car;
        bool Part;
        bool Engine;
        bool Tires;
        ModClass MC;

        public Mod(MainWindow p, OleDbConnection c)
        {
            cn = c;
            MC = new ModClass(cn);
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
                string[] data = new string[8];
                data[0] = PersonIDBox.GetLineText(0);
                data[1] = PersonNameBox.GetLineText(0);
                data[2] = PersonPhoneBox.GetLineText(0);
                data[3] = PersonAddressBox.GetLineText(0);
                data[4] = PersonSexBox.GetLineText(0);
                data[5] = PersonOther1Box.GetLineText(0);
                data[6] = PersonOther2Box.GetLineText(0);
                data[7] = PersonOther3Box.GetLineText(0);

                MC.ModifyEmployee(data);

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
                string[] data = new string[6];
                data[0] = PersonIDBox.GetLineText(0);
                data[1] = PersonNameBox.GetLineText(0);
                data[2] = PersonPhoneBox.GetLineText(0);
                data[3] = PersonAddressBox.GetLineText(0);
                data[4] = PersonSexBox.GetLineText(0);
                data[5] = PersonOther1Box.GetLineText(0);

                MC.ModifyCustomer(data);

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
                string[] data = new string[6];
                data[0] = VINBox.GetLineText(0);
                data[1] = VehicleModelBox.GetLineText(0);
                data[2] = VehicleYearBox.GetLineText(0);
                data[3] = VehicleMakerBox.GetLineText(0);
                data[4] = VehicleSeatsBox.GetLineText(0);
                data[5] = VehiclePriceBox.GetLineText(0);
                data[6] = VehicleOther1Box.GetLineText(0);

                MC.ModifyCar(data);

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
                string[] data = new string[6];
                data[0] = VINBox.GetLineText(0);
                data[1] = VehicleModelBox.GetLineText(0);
                data[2] = VehicleYearBox.GetLineText(0);
                data[3] = VehicleMakerBox.GetLineText(0);
                data[4] = VehicleSeatsBox.GetLineText(0);
                data[5] = VehiclePriceBox.GetLineText(0);
                data[6] = VehicleOther1Box.GetLineText(0);

                MC.ModifyTruck(data);

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
            string[] data = new string[6];
            data[0] = VHRVINBox.GetLineText(0);
            data[1] = VHRPreviousOwnersBox.GetLineText(0);
            data[2] = VHRRatingBox.GetLineText(0);
            data[3] = VHRMileageBox.GetLineText(0);

            MC.ModifyVHR(data);

            VHRVINBox.Clear();
            VHRPreviousOwnersBox.Clear();
            VHRRatingBox.Clear();
            VHRMileageBox.Clear();
        }
        private void SubmitPart_Click(object sender, RoutedEventArgs e)
        {
            if (Tires)
            {
                string[] data = new string[6];
                data[0] = PartSerialNumberBox.GetLineText(0);
                data[1] = PartVINBox.GetLineText(0);
                data[2] = PartNameBox.GetLineText(0);
                data[3] = PartManufacturerBox.GetLineText(0);
                data[4] = PartOther2Box.GetLineText(0);
                data[5] = PartOther1Box.GetLineText(0);

                MC.ModifyTires(data);

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
                string[] data = new string[6];
                data[0] = PartSerialNumberBox.GetLineText(0);
                data[1] = PartVINBox.GetLineText(0);
                data[2] = PartNameBox.GetLineText(0);
                data[3] = PartManufacturerBox.GetLineText(0);
                data[4] = PartOther2Box.GetLineText(0);
                data[5] = PartOther1Box.GetLineText(0);

                MC.ModifyEngine(data);

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
                string[] data = new string[6];
                data[0] = PartSerialNumberBox.GetLineText(0);
                data[1] = PartVINBox.GetLineText(0);
                data[2] = PartNameBox.GetLineText(0);
                data[3] = PartManufacturerBox.GetLineText(0);

                MC.ModifyPart(data);

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
            PersonOther1Label.Text = "Salary (Ex. 50,000.00)";
            PersonOther2Label.Text = "Start Date (mm/dd/yyyy)";
            PersonOther3Label.Text = "Manager EID";
            Employee = true;
        }
        private void CustomerCheck_Checked(object sender, RoutedEventArgs e)
        {
            EmployeeCheck.Visibility = Visibility.Collapsed;
            PersonOther1Box.Visibility = Visibility.Visible;
            PersonOther1Label.Visibility = Visibility.Visible;
            PersonOther1Label.Text = "Type (Returning/Preffered/Etc.)";
            Customer = true;
        }
        private void CarCheck_Checked(object sender, RoutedEventArgs e)
        {
            TruckCheck.Visibility = Visibility.Collapsed;
            VehicleOther1Box.Visibility = Visibility.Visible;
            VehicleOther1Label.Visibility = Visibility.Visible;
            VehicleOther1Label.Text = "Type (Sedan/SUV/Etc.)";
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
            PartOther1Label.Text = "Size (cm)";
            PartOther2Label.Text = "Type (Winter/Summer/Etc.)";
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
