using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace CarDealership
{
    public class MakeSale
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        private string[] Data;

        public MakeSale(MainWindow p, string[] D, OleDbConnection cn)
        {
            this.Parent = p;
            this.Data = D;
            this.cn = cn;
        }

        public void CreateSale()
        {
            MakeQuery().ExecuteNonQuery();
            UpdateQuery().ExecuteNonQuery();
        }

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

        private OleDbCommand UpdateQuery()
        {
            OleDbCommand markSale = cn.CreateCommand();
            markSale.CommandText = "UPDATE Vehicle SET Sold = ? WHERE VIN = ?";

            markSale.Parameters.AddWithValue("@Sold", true);
            markSale.Parameters.AddWithValue("@VIN", Data[0]);

            return markSale;
        }
    }
}
