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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object SecondWindow = null;
        public OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();        
            string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\David Ryan\Documents\Contacts.accdb";
            cn = new OleDbConnection(ConnectionString);
            cn.Open();
        }
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (SecondWindow == null)
            {
                SecondWindow = new AddCustomer(this, cn);
                ((AddCustomer)SecondWindow).Show();  
                ((AddCustomer)SecondWindow).Activate();
            }
        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (SecondWindow == null)
            {
                SecondWindow = new AddEmployee(this, cn);
                ((AddEmployee)SecondWindow).Show();
                ((AddEmployee)SecondWindow).Activate();
            }
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (SecondWindow == null)
            {
                bool used = false;
                SecondWindow = new AddCar(this, cn, used);
                ((AddCar)SecondWindow).Show();
                ((AddCar)SecondWindow).Activate();
            }
        }

        private void AddTruckButton_Click(object sender, RoutedEventArgs e)
        {
            if (SecondWindow == null)
            {
                bool used = false;
                SecondWindow = new AddTruck(this, cn, used);
                ((AddTruck)SecondWindow).Show();
                ((AddTruck)SecondWindow).Activate();
            }
        }

        private void AddUsedCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (SecondWindow == null)
            {
                bool used = true;
                SecondWindow = new AddCar(this, cn, used);
                ((AddCar)SecondWindow).Show();
                ((AddCar)SecondWindow).Activate();
            }
        }

        private void AddUsedTruckButton_Click(object sender, RoutedEventArgs e)
        {
            if (SecondWindow == null)
            {
                bool used = true;
                SecondWindow = new AddTruck(this, cn, used);
                ((AddTruck)SecondWindow).Show();
                ((AddTruck)SecondWindow).Activate();
            }
        }

        private void AddEngineButton_Click(object sender, RoutedEventArgs e)
        {
            if (SecondWindow == null)
            {
                SecondWindow = new AddEngine(this, cn);
                ((AddEngine)SecondWindow).Show();
                ((AddEngine)SecondWindow).Activate();
            }
        }

        private void AddOtherPartButton_Click(object sender, RoutedEventArgs e)
        {
            if (SecondWindow == null)
            {
                SecondWindow = new AddPart(this, cn);
                ((AddPart)SecondWindow).Show();
                ((AddPart)SecondWindow).Activate();
            }
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
            if (SecondWindow == null)
            {
                SecondWindow = new AddTires(this, cn);
                ((AddTires)SecondWindow).Show();
                ((AddTires)SecondWindow).Activate();
            }
        }
    }
}
