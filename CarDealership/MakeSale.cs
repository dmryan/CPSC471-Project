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
        private bool noError;

        public MakeSale(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
        }

        public void AddSale()
        {
            noError = true;

            string VIN = Parent.VehicleText.GetLineText(0);
            string CID = Parent.CustomerText.GetLineText(0);
            string EID = Parent.EmployeeText.GetLineText(0);
            string SellDate = Parent.DateText.GetLineText(0);
            string SalePrice = Parent.PriceText.GetLineText(0);

            //SQL Statement
            OleDbCommand insertSale = cn.CreateCommand();
            OleDbCommand markSale = cn.CreateCommand();

            insertSale.CommandText = "INSERT INTO Sale(VIN, CID, EID, SellDate, SalePrice) VALUES (@VIN, @CID, @EID, @SellDate, @SalePrice)";
            markSale.CommandText = "UPDATE Vehicle SET Sold = ? WHERE VIN = ?";

            insertSale.Parameters.AddWithValue("@VIN", VIN);
            insertSale.Parameters.AddWithValue("@CID", CID);
            insertSale.Parameters.AddWithValue("@EID", EID);
            insertSale.Parameters.AddWithValue("@SellDate", SellDate);
            insertSale.Parameters.AddWithValue("@SalePrice", SalePrice);
            
            markSale.Parameters.AddWithValue("@Sold", true);
            markSale.Parameters.AddWithValue("@VIN", VIN);

            try 
            {
                insertSale.ExecuteNonQuery();
                markSale.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }

            if (noError)
            {
                Parent.VehicleText.Clear();
                Parent.CustomerText.Clear();
                Parent.EmployeeText.Clear();
                Parent.DateText.Clear();
                Parent.PriceText.Clear();
            }
        }
    }
}
