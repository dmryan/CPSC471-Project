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
            int VIN2 = int.Parse(VIN);
            int CID2 = int.Parse(CID);
            int EID2 = int.Parse(EID);

            OleDbCommand deleteSale = cn.CreateCommand();
            
            deleteSale.CommandText = ("DELETE FROM Sale WHERE VIN =" + VIN2 + " AND CID =" + CID2 +" AND EID =" + EID2);
            deleteSale.ExecuteNonQuery();

            OleDbCommand updateSale = cn.CreateCommand();
            updateSale.CommandText = "UPDATE Vehicle SET Sold = ? WHERE VIN = ?";

            updateSale.Parameters.AddWithValue("@Sold", false);
            updateSale.Parameters.AddWithValue("@VIN", VIN2);
            updateSale.ExecuteNonQuery();
        }
    }
}
