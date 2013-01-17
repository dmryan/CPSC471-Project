using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    class MakeEmployee
    {
        private string ID;
        private string Salary;
        private string StartDate;
        private string ManagerID;
        private OleDbConnection cn;
        public MakeEmployee(string ID, string S, string SD, string MID, OleDbConnection cn)
        {
            this.ID = ID;
            this.Salary = S;
            this.StartDate = SD;
            this.ManagerID = MID;
            this.cn = cn;
        }
        public void CreateEmployee()
        {
            MakeQuery(MakeEmployeeSQLString()).ExecuteNonQuery();
        }
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
