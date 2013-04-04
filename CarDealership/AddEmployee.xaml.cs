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
        private bool noError;
        private AddEmployeeControl aec;

        public AddEmployee(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            InitializeComponent();
            aec = new AddEmployeeControl(cn);
        }

        private void AddEmployeeSubmit_Click(object sender, RoutedEventArgs e)
        {
            string[] Data = new string[9];
            Data[0] = IDText.GetLineText(0);
            Data[1] = NameText.GetLineText(0);
            Data[2] = PhoneText.GetLineText(0);
            Data[3] = AddressText.GetLineText(0);
            Data[4] = SexText.GetLineText(0);
            Data[5] = Data[0];
            Data[6] = SalaryText.GetLineText(0);
            Data[7] = StartDateText.GetLineText(0);
            Data[8] = ManagerText.GetLineText(0);

            aec.createEmployee(Data).ShowDialog();

            this.Close();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
