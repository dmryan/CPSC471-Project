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
            string[] Data = new string[5];
            Data[0] = IDText.GetLineText(0);
            Data[1] = NameText.GetLineText(0);
            Data[2] = PhoneText.GetLineText(0);
            Data[3] = AddressText.GetLineText(0);
            Data[4] = SexText.GetLineText(0);
            string Salary = SalaryText.GetLineText(0);
            string StartDate = StartDateText.GetLineText(0);
            string ManagerID = ManagerText.GetLineText(0);

            MakePerson P = new MakePerson(Data, cn);

            try
            {
                P.CreatePerson();
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
