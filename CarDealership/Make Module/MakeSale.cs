using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    public class MakeSale
    {
        /**
         * @param Data          Array of data for the Sale
         * @param cn            Connection to the database
         */
        private string[] Data;
        private OleDbConnection cn;

        /**
         * Constructor that gets the connection to the database and Sale information
         * 
         * @param D             Array of data for the Sale
         * @param cn            Connection to the database
         */
        public MakeSale(string[] D, OleDbConnection cn)
        {
            this.Data = D;
            this.cn = cn;
        }

        /**
         * Creates an instance of a Sale in the database and updates the Vehicle as sold
         */
        public void CreateSale()
        {
            MakeQuery().ExecuteNonQuery();
            UpdateQuery().ExecuteNonQuery();
        }

        /**
         * Creates a command that when executed will add a Sale to the database 
         * 
         * @return insertSale   Executable command for adding a Person to the database
         */
        private OleDbCommand MakeQuery()
        {
            OleDbCommand insertSale = cn.CreateCommand();
            insertSale.CommandText = "INSERT INTO Sale(VIN, CID, EID, SellDate, SalePrice) VALUES (@VIN, @CID, @EID, @SellDate, @SalePrice)";

            insertSale.Parameters.AddWithValue("@VIN", Data[0]);
            insertSale.Parameters.AddWithValue("@CID", Data[1]);
            insertSale.Parameters.AddWithValue("@EID", Data[2]);
            insertSale.Parameters.AddWithValue("@SellDate", Data[3]);
            insertSale.Parameters.AddWithValue("@SalePrice", Data[4]);

            return insertSale;
        }

        /**
         * Creates a command that when executed will update a Vehicle to the database to sold
         * 
         * @return updateSale   Executable command for adding a Person to the database
         */
        private OleDbCommand UpdateQuery()
        {
            OleDbCommand updateSale = cn.CreateCommand();
            updateSale.CommandText = "UPDATE Vehicle SET Sold = ? WHERE VIN = ?";

            updateSale.Parameters.AddWithValue("@Sold", true);
            updateSale.Parameters.AddWithValue("@VIN", Data[0]);

            return updateSale;
        }
    }
}
