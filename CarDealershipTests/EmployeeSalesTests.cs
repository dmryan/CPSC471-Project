using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarDealership;
using System.Data.OleDb;
using System.Data;

namespace CarDealershipTests
{
    [TestClass]
    public class EmployeeSalesTests
    {
        
        [TestMethod]
        public void EmployeeProgress_NormalPath()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            TestingFunctions tf = new TestingFunctions(db.GetDB());
            try
            {
                tf.DeleteSale("3", "121", "9");
            }
            catch (Exception e)
            {
            }
            

            String[] sale = new String[] { "3", "121", "9", "4/10/2008", "34000" };
            MakeSale sa = new MakeSale(sale, db.GetDB());
            sa.CreateSale();
            
            DataTable dt = st.CalculateProgress();
            Double actual = (Double)dt.Rows[0].ItemArray[2];
            Double expected = 34000;
            Assert.IsTrue(actual == expected);

            tf.DeleteSale("3", "121", "9");
        }

        [TestMethod]
        public void EmployeeProgress_NoSales()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            StatsCalc_Accessor st = new StatsCalc_Accessor(db.GetDB());

            DataTable dt = st.CalculateProgress();

            Assert.IsTrue(dt.Rows.Count == 0);
        }
         

    }
}
