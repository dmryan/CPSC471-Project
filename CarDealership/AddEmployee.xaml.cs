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
            OleDbCommand selectEmployee = cn.CreateCommand();

            insertPerson.CommandText = "INSERT INTO Person(ID, PersonName, PhoneNumber, Address, Sex) VALUES (@ID, @PersonName, @PeronsNumber, @Address, @Sex)";
            insertEmployee.CommandText = "INSERT INTO Employee(EID, Salary, StartDate, ManagerID) VALUES (@EID, @Salary, @StartDate, @ManagerID)";
            selectEmployee.CommandText = "SELECT EID FROM Employee WHERE EID = @ManagerID";

            if(ManagerID == "")
                selectEmployee.Parameters.AddWithValue("@ManagerID", -99999);
            else
                selectEmployee.Parameters.AddWithValue("@ManagerID", ManagerID);

            insertPerson.Parameters.AddWithValue("@ID", EID);
            insertPerson.Parameters.AddWithValue("@PersonName", Name);
            insertPerson.Parameters.AddWithValue("@PhoneNumber", Phone);
            insertPerson.Parameters.AddWithValue("@Address", Address);
            insertPerson.Parameters.AddWithValue("@Sex", Sex);

            insertEmployee.Parameters.AddWithValue("@EID", EID);
            insertEmployee.Parameters.AddWithValue("@Salary", Salary);
            insertEmployee.Parameters.AddWithValue("@StartDate", StartDate);
            if (selectEmployee.ExecuteScalar() == null && ManagerID != "")
            {
                ErrorWindow Error = new ErrorWindow("Required field does not match any values within the database.");
                Error.ShowDialog();
                return;
            }
            else if( ManagerID != "" )
                insertEmployee.Parameters.AddWithValue("@ManagerID", ManagerID);
            else
                selectEmployee.Parameters.AddWithValue("@ManagerID", -1);

            try {
                insertPerson.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }
            if (noError)
            {
                try {
                    insertEmployee.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    OleDbCommand deletePerson = cn.CreateCommand();
                    deletePerson.CommandText = ("DELETE FROM PERSON WHERE ID =" + EID);
                    deletePerson.ExecuteNonQuery();
                    noError = false;
                    ErrorWindow Error = new ErrorWindow(ex.Message);
                    Error.ShowDialog();
                }
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
