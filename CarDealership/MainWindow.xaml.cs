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
// now includes remove/modify
namespace CarDealership
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Window SecondWindow = null;
        public OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            // Make sure you use database in the Git
            //string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\David Ryan\Documents\CarDealershipDatabase.accdb";
            //string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Sean\Documents\Git\CPSC471\CPSC471-Project\CarDealershipDatabase.accdb";
            string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\boydst\SENG_GIT\CPSC471\CPSC471-Project\CarDealershipDatabase.accdb";
            cn = new OleDbConnection(ConnectionString);
            try
            {
                cn.Open();
            }
            catch (OleDbException ex)
            {
                SecondWindow = new ErrorWindow(ex.Message);
                ((ErrorWindow)SecondWindow).ShowDialog();
            }
        }
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
                SecondWindow = new AddCustomer(this, cn);
                ((AddCustomer)SecondWindow).ShowDialog();  
        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
                SecondWindow = new AddEmployee(this, cn);
                ((AddEmployee)SecondWindow).ShowDialog();
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
                bool used = false;
                SecondWindow = new AddCar(this, cn, used);
                ((AddCar)SecondWindow).ShowDialog();
        }

        private void AddTruckButton_Click(object sender, RoutedEventArgs e)
        {
                bool used = false;
                SecondWindow = new AddTruck(this, cn, used);
                ((AddTruck)SecondWindow).ShowDialog();
        }

        private void AddUsedCarButton_Click(object sender, RoutedEventArgs e)
        {
                bool used = true;
                SecondWindow = new AddCar(this, cn, used);
                ((AddCar)SecondWindow).ShowDialog();
        }

        private void AddUsedTruckButton_Click(object sender, RoutedEventArgs e)
        {
                bool used = true;
                SecondWindow = new AddTruck(this, cn, used);
                ((AddTruck)SecondWindow).ShowDialog();
        }

        private void AddEngineButton_Click(object sender, RoutedEventArgs e)
        {
                SecondWindow = new AddEngine(this, cn);
                ((AddEngine)SecondWindow).ShowDialog();
        }

        private void AddOtherPartButton_Click(object sender, RoutedEventArgs e)
        {
                SecondWindow = new AddPart(this, cn);
                ((AddPart)SecondWindow).ShowDialog();
        }

        private void FindPersonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindVehicleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindPartButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindSaleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SubmitSaleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTiresButton_Click(object sender, RoutedEventArgs e)
        {
                SecondWindow = new AddTires(this, cn);
                ((AddTires)SecondWindow).ShowDialog();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
