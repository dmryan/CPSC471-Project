using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeEmployee
    {
        /**
         * @param ID            ID of the Employee
         * @param Salary        Salary of the Employee
         * @param StartDate     Start date of the Employee
         * @param ManagerID     Manager ID of the Employee
         * @param cn            Connection to the database
         */
        private string ID;
        private string Salary;
        private string StartDate;
        private string ManagerID;
        private OleDbConnection cn;

        /**
         * Constructor that gets the connection to the database and Employee information
         * 
         * @param ID            ID of the Employee
         * @param S             Salary of the Employee
         * @param SD            Start date of the Employee
         * @param MID           Manager ID of the Employee
         * @param cn            Connection to the database
         */
        public MakeEmployee(string ID, string S, string SD, string MID, OleDbConnection cn)
        {
            this.ID = ID;
            this.Salary = S;
            this.StartDate = SD;
            this.ManagerID = MID;
            this.cn = cn;
        }

        /**
         * Creates an instance of an Employee in the database
         */
        public void CreateEmployee()
        {
            MakeQuery(MakeEmployeeSQLString()).ExecuteNonQuery();
        }

        /**
         * Creates a command that when executed will add an Employee to the database 
         * 
         * @param SQLString     SQL statement for adding an Employee to the database
         * @return insertEmployee   Executable command for adding an Employee to the database
         */
        private OleDbCommand MakeQuery(string SQLString)
        {
            OleDbCommand insertEmployee = cn.CreateCommand();
            insertEmployee.CommandText = SQLString;

            if (ID.CompareTo("") != 0)
            {
                insertEmployee.Parameters.AddWithValue("@EID", ID);
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

            return insertEmployee;
        }

        /**
         * Creates a SQL statement for adding an Employee to the database 
         * 
         * @return SQLString    SQL statement for adding an Employee to the database
         */
        private string MakeEmployeeSQLString()
        {
            string SQLString;
            string InsertEmployee = "INSERT INTO Employee(EID";
            string InsertValues = " VALUES (@EID";

            if (Salary.CompareTo("") != 0)
            {
                InsertEmployee += ", Salary";
                InsertValues += ", @Salary";
            }
            if (StartDate.CompareTo("") != 0)
            {
                InsertEmployee += ", StartDate";
                InsertValues += ", @StartDate";
            }
            if (ManagerID.CompareTo("") != 0)
            {
                InsertEmployee += ", ManagerID";
                InsertValues += ", @ManagerID";
            }

            SQLString = InsertEmployee;
            SQLString += ")";
            SQLString += InsertValues;
            SQLString += ")";

            return SQLString;
        }
    }
}
