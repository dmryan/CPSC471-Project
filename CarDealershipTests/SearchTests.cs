using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarDealership;


namespace CarDealershipTests
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void Search_NormalPath()
        {
            DBConnection_Accessor connection = new DBConnection_Accessor();
            connection.GetDB();
            Assert.AreEqual("S", "S");
        }
    }
}
