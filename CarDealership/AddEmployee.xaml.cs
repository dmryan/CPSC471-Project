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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        public AddEmployee(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            InitializeComponent();
        }

        private void AddEmployeeSubmit_Click(object sender, RoutedEventArgs e)
        {
            string EID = IDText.GetLineText(0);
            string Name = NameText.GetLineText(0);
            string Phone = PhoneText.GetLineText(0);
            string Address = AddressText.GetLineText(0);
            string Sex = SexText.GetLineText(0);
            string Salary = SalaryText.GetLineText(0);
            string StartDate = StartDateText.GetLineText(0);
            string ManagerID = ManagerText.GetLineText(0);

            //sql statement

            Parent.SecondWindow = null;
            this.Close();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Parent.SecondWindow = null;
            base.OnClosing(e);
        }
    }
}
