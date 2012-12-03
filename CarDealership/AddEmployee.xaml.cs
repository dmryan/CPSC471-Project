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

        public AddEmployee(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            InitializeComponent();
        }

        private void AddEmployeeSubmit_Click(object sender, RoutedEventArgs e)
        {
            noError = true;

            string EID = IDText.GetLineText(0);
            string Name = NameText.GetLineText(0);
            string Phone = PhoneText.GetLineText(0);
            string Address = AddressText.GetLineText(0);
            string Sex = SexText.GetLineText(0);
            string Salary = SalaryText.GetLineText(0);
            string StartDate = StartDateText.GetLineText(0);
            string ManagerID = ManagerText.GetLineText(0);

            //SQL Statement
            OleDbCommand insertPerson = cn.CreateCommand();
            OleDbCommand insertEmployee = cn.CreateCommand();

            //insertPerson.CommandText = "INSERT INTO Person(ID, PersonName, PhoneNumber, Address, Sex) VALUES (@ID, @PersonName, @PeronsNumber, @Address, @Sex)";
            string person1 = "INSERT INTO Person(ID";
            string person2 = " Values (@ID";
            string employee1 = "INSERT INTO Employee(EID";
            string employee2 = " VALUES (@EID";
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
            if (EID.CompareTo("") != 0)
            {
                insertPerson.Parameters.AddWithValue("@ID", EID);
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
            if (Salary.CompareTo("") != 0)
            {
                employee1 += ", Salary";
                employee2 += ", @Salary";
            }
            if (StartDate.CompareTo("") != 0)
            {
                employee1 += ", StartDate";
                employee2 += ", @StartDate";
            }
            if (ManagerID.CompareTo("") != 0)
            {
                employee1 += ", ManagerID";
                employee2 += ", @ManagerID";
            }
            insertEmployee.CommandText = employee1;
            insertEmployee.CommandText += ")";
            insertEmployee.CommandText += employee2;
            insertEmployee.CommandText += ")";
            if (EID.CompareTo("") != 0)
            {
                insertEmployee.Parameters.AddWithValue("@EID", EID);
            }
            if (Salary.CompareTo("") != 0)
            {
                insertEmployee.Parameters.AddWithValue("@Salary", Salary);
            }
            if (StartDate.CompareTo("") != 0)
            {
                insertEmployee.Parameters.AddWithValue("@StartDate", StartDate);
            }
            if (ManagerID.CompareTo("") != 0)
            {
                insertEmployee.Parameters.AddWithValue("@ManagerID", ManagerID);
            }
            try
            {
                insertEmployee.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                OleDbCommand deletePerson = cn.CreateCommand();
                deletePerson.CommandText = ("DELETE FROM PERSON WHERE ID =" + EID);
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
