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

        public AddCustomer(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            InitializeComponent();
        }

        private void AddCustomerSubmit_Click(object sender, RoutedEventArgs e)
        {
            string[] Data = new string[5];
            Data[0] = IDText.GetLineText(0);
            Data[1] = NameText.GetLineText(0);
            Data[2] = PhoneText.GetLineText(0);
            Data[3] = AddressText.GetLineText(0);
            Data[4] = SexText.GetLineText(0);
            string EID = Data[0];
            string Type = TypeText.GetLineText(0);

            MakePerson P = new MakePerson(Data, cn);
            MakeCustomer E = new MakeCustomer(EID, Type, cn);

            try
            {
                P.CreatePerson();
            }
            catch (OleDbException ex)
            {
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
                return;
            }

            try
            {
                E.CreateCustomer();
            }
            catch (OleDbException ex)
            {
                try
                {
                    P.DeletePerson();
                }
                catch (OleDbException ex2) { }

                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
                return;
            }

            this.Close();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
