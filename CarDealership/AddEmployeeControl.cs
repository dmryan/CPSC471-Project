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
    class AddEmployeeControl
    {
        private OleDbConnection cn;

        public AddEmployeeControl(OleDbConnection cn)
        {
            this.cn = cn;
        }
        public ErrorWindow createEmployee(string[] d)
        {
            MakePerson P = new MakePerson(d, cn);
            MakeEmployee E = new MakeEmployee(d[5], d[6], d[7], d[8], cn);

            try
            {
                P.CreatePerson();
            }
            catch (OleDbException ex)
            {
                ErrorWindow Error = new ErrorWindow(ex.Message);
                return Error;
            }

            try
            {
                E.CreateEmployee();
            }
            catch (OleDbException ex)
            {
                try
                {
                    P.DeletePerson();
                }
                catch (OleDbException ex2) { }

                ErrorWindow Error = new ErrorWindow(ex.Message);
                return Error;
            }
            return null;
        }
    }
}
