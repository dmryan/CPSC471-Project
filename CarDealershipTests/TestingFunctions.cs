using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealershipTests
{
    class TestingFunctions
    {
       private OleDbConnection cn;

        /*
         * Constructor that use the database connection
         * 
         * @param cn        Database connection
         */
        public TestingFunctions(OleDbConnection cn)
        {
            this.cn = cn;
        }

        public void DeleteSale(string VIN, string CID, string EID)
        {
            OleDbCommand deleteSale = cn.CreateCommand();
            
            deleteSale.CommandText = ("DELETE FROM Sale WHERE VIN =" + VIN + " AND CID =" + CID +" AND EID =" + EID);
            deleteSale.ExecuteNonQuery();
        }
    }
}
