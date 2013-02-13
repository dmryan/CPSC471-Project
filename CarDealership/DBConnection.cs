using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CarDealership
{
    class DBConnection
    {
        private OleDbConnection connection;
        
        public DBConnection(){

            string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\nolan\database\cardealership\bin\debug\CarDealershipDatabase.accdb";
                //@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\boydst\CPSC471-Project\cardealership\bin\debug\CarDealershipDatabase.accdb";
                //@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\nolan\database\cardealership\bin\debug\CarDealershipDatabase.accdb";
            connection = new OleDbConnection(ConnectionString);
            try
            {
                connection.Open();
            }
            catch (OleDbException ex)
            {
                Console.Error.WriteLine("Unable to connect to database.");
                return;
            }
        }

        public OleDbConnection GetDB()
        {
            return connection;
        }

    }
}
