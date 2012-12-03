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
            noError = true;

            string CID = IDText.GetLineText(0);
            string Name = NameText.GetLineText(0);
            string Phone = PhoneText.GetLineText(0);
            string Address = AddressText.GetLineText(0);
            string Sex = SexText.GetLineText(0);
            string Type = TypeText.GetLineText(0);

            //SQL Statement
            //SQL Statement
            OleDbCommand insertPerson = cn.CreateCommand();
            OleDbCommand insertCustomer = cn.CreateCommand();

            //insertPerson.CommandText = "INSERT INTO Person(ID, PersonName, PhoneNumber, Address, Sex) VALUES (@ID, @PersonName, @PeronsNumber, @Address, @Sex)";
            string person1 = "INSERT INTO Person(ID";
            string person2 = " Values (@ID";
            string customer1 = "INSERT INTO Customer(CID";
            string customer2 = " VALUES (@CID";
            //insertEmployee.CommandText = "INSERT INTO Employee(EID, Salary, StartDate, ManagerID) VALUES (@EID, @Salary, @StartDate, @ManagerID)";

            if (Name.CompareTo("") != 0)
            {
                person1 += ", PersonName";
                person2 += ", @PersonName";
            }
            if (Phone.CompareTo("") != 0)
            {
                person1 += ", PhoneNumber";
                person2 += ", @PhoneNumber";
            }
            if (Address.CompareTo("") != 0)
            {
                person1 += ", Address";
                person2 += ", @Address";
            }
            if (Sex.CompareTo("") != 0)
            {
                person1 += ", Sex";
                person2 += ", @Sex";
            }
            insertPerson.CommandText = person1;
            insertPerson.CommandText += ")";
            insertPerson.CommandText += person2;
            insertPerson.CommandText += ")";
            if (CID.CompareTo("") != 0)
            {
                insertPerson.Parameters.AddWithValue("@ID", CID);
            }
            if (Name.CompareTo("") != 0)
            {
                insertPerson.Parameters.AddWithValue("@PersonName", Name);
            }
            if (Phone.CompareTo("") != 0)
            {
                insertPerson.Parameters.AddWithValue("@PhoneNumber", Phone);
            }
            if (Address.CompareTo("") != 0)
            {
                insertPerson.Parameters.AddWithValue("@Address", Address);
            }
            if (Sex.CompareTo("") != 0)
            {
                insertPerson.Parameters.AddWithValue("@Sex", Sex);
            }
            try
            {
                insertPerson.ExecuteNonQuery();
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
                customer1 += ", Type";
                customer2 += ", @Type";
            }
            insertCustomer.CommandText = customer1;
            insertCustomer.CommandText += ")";
            insertCustomer.CommandText += customer2;
            insertCustomer.CommandText += ")";
            if (CID.CompareTo("") != 0)
            {
                insertCustomer.Parameters.AddWithValue("@EID", CID);
            }
            if (Type.CompareTo("") != 0)
            {
                insertCustomer.Parameters.AddWithValue("@Type", Type);
            }
            try
            {
                insertCustomer.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                OleDbCommand deletePerson = cn.CreateCommand();
                deletePerson.CommandText = ("DELETE FROM PERSON WHERE ID =" + CID);
                try
                {
                    deletePerson.ExecuteNonQuery();
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
