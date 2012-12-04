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
    /// Interaction logic for AddTires.xaml
    /// </summary>
    public partial class AddTires : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        private bool noError;

        public AddTires(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            InitializeComponent();
        }

        private void AddTire_Click(object sender, RoutedEventArgs e)
        {
            noError = true;

            string SerialNumber = SerialNumberText.GetLineText(0);
            string VIN = VINText.GetLineText(0);
            string Name = NameText.GetLineText(0);
            string Manufacturer = ManufacturerText.GetLineText(0);
            string Type = TypeText.GetLineText(0);
            string Size = SizeText.GetLineText(0);

            //SQL Statement
            OleDbCommand insertPart = cn.CreateCommand();
            OleDbCommand insertTires = cn.CreateCommand();

            // insertVehicle.CommandText = "INSERT INTO Vehicle(VIN, Model, YearProd, Maker, NumberSeats, Price, Sold) VALUES (@VIN, @Model, @YearProd, @Maker, @NumberSeats, @Price, @Sold)";
            //insertTruck.CommandText = "INSERT INTO Truck(VIN, TowingCapacity) VALUES (@VIN, @TowingCapacity)";

            string Part1 = "INSERT INTO Part(SerialNumber";
            string Part2 = " Values (@SerialNumber";
            string tires1 = "INSERT INTO Tire(SerialNumber";
            string tires2 = " VALUES (@SerialNumber";
            //insertEmployee.CommandText = "INSERT INTO Employee(EID, Salary, StartDate, ManagerID) VALUES (@EID, @Salary, @StartDate, @ManagerID)";

            if (VIN.CompareTo("") != 0)
            {
                Part1 += ", VIN";
                Part2 += ", @VIN";
            }
            if (Name.CompareTo("") != 0)
            {
                Part1 += ", PartName";
                Part2 += ", @PartName";
            }
            if (Manufacturer.CompareTo("") != 0)
            {
                Part1 += ", Manufacturer";
                Part2 += ", @Manufacturer";
            }

            insertPart.CommandText = Part1;
            insertPart.CommandText += ")";
            insertPart.CommandText += Part2;
            insertPart.CommandText += ")";
            if (VIN.CompareTo("") != 0)
            {
                insertPart.Parameters.AddWithValue("@SerialNumber", SerialNumber);
            }
            if (VIN.CompareTo("") != 0)
            {
                insertPart.Parameters.AddWithValue("@VIN", VIN);
            }
            if (Name.CompareTo("") != 0)
            {
                insertPart.Parameters.AddWithValue("@PartName", Name);
            }
            if (Manufacturer.CompareTo("") != 0)
            {
                insertPart.Parameters.AddWithValue("@Manufacturer", Manufacturer);
            }
            try
            {
                insertPart.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }
            ///////////////////////////////////////////////////////////////////////
            if (Type.CompareTo("") != 0)
            {
                tires1 += ", Type";
                tires2 += ", @Type";
            }
            if (Size.CompareTo("") != 0)
            {
                tires1 += ", TireSize";
                tires2 += ", @TireSize";
            }
            insertTires.CommandText = tires1;
            insertTires.CommandText += ")";
            insertTires.CommandText += tires2;
            insertTires.CommandText += ")";
            if (VIN.CompareTo("") != 0)
            {
                insertTires.Parameters.AddWithValue("@SerialNumber", SerialNumber);
            }
            if (Type.CompareTo("") != 0)
            {
                insertTires.Parameters.AddWithValue("@Type", Type);
            }
            if (Size.CompareTo("") != 0)
            {
                insertTires.Parameters.AddWithValue("@TireSize", Size);
            }
            try
            {
                insertTires.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                OleDbCommand deletePart = cn.CreateCommand();
                deletePart.CommandText = ("DELETE FROM PART WHERE SerialNumber =" + SerialNumber);
                try
                {
                    deletePart.ExecuteNonQuery();
                }
                catch (OleDbException ex2) { }
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }
            if (noError)
                this.Close();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
