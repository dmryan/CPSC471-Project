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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        private MainWindow Parent;
        private OleDbConnection cn;
        private bool noError = true;
        private AddCustomerControl acc;

        public AddCustomer(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            InitializeComponent();
            acc = new AddCustomerControl(cn);
        }

        private void AddCustomerSubmit_Click(object sender, RoutedEventArgs e)
        {
            string[] Data = new string[7];
            Data[0] = IDText.GetLineText(0);
            Data[1] = NameText.GetLineText(0);
            Data[2] = PhoneText.GetLineText(0);
            Data[3] = AddressText.GetLineText(0);
            Data[4] = SexText.GetLineText(0);
            Data[5] = Data[0];
            Data[6] = TypeText.GetLineText(0);

            acc.createCustomer(Data).ShowDialog();

            this.Close();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
