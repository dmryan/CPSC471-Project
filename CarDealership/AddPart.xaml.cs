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
    /// Interaction logic for AddPart.xaml
    /// </summary>
    public partial class AddPart : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        private bool noError;

        public AddPart(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            InitializeComponent();
        }

        private void AddPart_Click(object sender, RoutedEventArgs e)
        {
            noError = true;

            string SerialNumber = SerialNumberText.GetLineText(0);
            string VIN = VINText.GetLineText(0);
            string Name = NameText.GetLineText(0);
            string Manufacturer = ManufacturerText.GetLineText(0);

            //SQL Statement
            OleDbCommand insertPart = cn.CreateCommand();

            string Part1 = "INSERT INTO Part(SerialNumber";
            string Part2 = " VALUES (@SerialNumber";

            if (VIN.CompareTo("") != 0)
            {
                Part1 += ", VIN";
                Part2 += ", @VIN";
            }
            if (Name.CompareTo("") != 0)
            {
                Part1 += ", Name";
                Part2 += ", @Name";
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
                insertPart.Parameters.AddWithValue("@Name", Name);
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
            if (noError)
                this.Close();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
