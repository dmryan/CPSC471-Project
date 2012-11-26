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
        public bool noError;
        public AddCustomer(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            noError = true;
            InitializeComponent();
        }

        private void AddCustomerSubmit_Click(object sender, RoutedEventArgs e)
        {
            string PID = IDText.GetLineText(0);
            string Name = NameText.GetLineText(0);
            string Phone = PhoneText.GetLineText(0);
            string Address = AddressText.GetLineText(0);
            string Sex = SexText.GetLineText(0);
            string Type = TypeText.GetLineText(0);

            //sql statement
            OleDbCommand insertPerson = cn.CreateCommand();
            OleDbCommand insertCustomer = cn.CreateCommand();

            insertPerson.CommandText = "INSERT INTO Person(ID, PersonName, PhoneNumber, Address, Sex) VALUES (@ID, @PersonName, @PeronsNumber, @Address, @Sex)";
            insertCustomer.CommandText = "INSERT INTO Customer(PID, Type) VALUES (@PID, @Type)";

            insertPerson.Parameters.AddWithValue("@ID", PID);
            insertPerson.Parameters.AddWithValue("@PersonName", Name);
            insertPerson.Parameters.AddWithValue("@PhoneNumber", Phone);
            insertPerson.Parameters.AddWithValue("@Address", Address);
            insertPerson.Parameters.AddWithValue("@Sex", Sex);

            insertCustomer.Parameters.AddWithValue("@ID", PID);
            insertCustomer.Parameters.AddWithValue("@Type", Type);

            try
            {
                insertPerson.ExecuteNonQuery();
                insertCustomer.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
                Error.Activate();
            }

            if (noError)
            {
                Parent.SecondWindow = null;
                this.Close();
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Parent.SecondWindow = null;
            base.OnClosing(e);
        }
    }
}
