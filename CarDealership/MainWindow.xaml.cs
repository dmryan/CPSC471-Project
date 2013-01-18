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
            string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CarDealershipDatabase.accdb";

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
            SecondWindow = new Search(this, cn, "Person");
            ((Search)SecondWindow).ShowDialog();
        }

        private void FindVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow = new Search(this, cn, "Vehicle");
            ((Search)SecondWindow).ShowDialog();
        }

        private void FindPartButton_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow = new Search(this, cn, "Part");
            ((Search)SecondWindow).ShowDialog();
        }

        private void FindSaleButton_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow = new Search(this, cn, "Sale");
            ((Search)SecondWindow).ShowDialog();
        }

        private void SubmitSaleButton_Click(object sender, RoutedEventArgs e)
        {
            string[] Data = new string[5];
            Data[0] = VehicleText.GetLineText(0);
            string CID = CustomerText.GetLineText(0);
            string EID = EmployeeText.GetLineText(0);
            string SellDate = DateText.GetLineText(0);
            string SalePrice = PriceText.GetLineText(0);



            MakeSale Sale = new MakeSale(this, cn);
            Sale.AddSale();
        }

        private void AddTiresButton_Click(object sender, RoutedEventArgs e)
        {
             SecondWindow = new AddTires(this, cn);
             ((AddTires)SecondWindow).ShowDialog();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow = new Remove(this, cn);
            ((Remove)SecondWindow).ShowDialog();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow = new Modify(this, cn);
            ((Modify)SecondWindow).ShowDialog();
        }

        private void MonthlySalesButton_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow = new MonthlySales(cn);
            ((MonthlySales)SecondWindow).ShowDialog();
        }

        private void Revenue_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow = new Revenue(cn);
            ((Revenue)SecondWindow).ShowDialog();
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow = new Inventory(cn);
            ((Inventory)SecondWindow).ShowDialog();
        }

        private void EmployeeProgress_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow = new EmployeeProgress(cn);
            ((EmployeeProgress)SecondWindow).ShowDialog();
        }

        private void Vehicle_Parts_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow = new VehicleParts(cn);
            ((VehicleParts)SecondWindow).ShowDialog();
        }
    }
}
