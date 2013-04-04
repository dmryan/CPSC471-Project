using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using CarDealership;
using CarDealershipTests;
using System.Data;


namespace CarDealershipTests
{
    /// <summary>
    /// Summary description for GUIAddCarTests
    /// </summary>
    [CodedUITest]
    public class GUIAddCarTests
    {
        public GUIAddCarTests()
        {
        }

        [TestMethod]
        public void GUIAddCarTest_NormalPath()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
            UIMap.GUIAddCar_NormalPath();
            DBConnection_Accessor db = new DBConnection_Accessor();
            SearchFunction_Accessor sc = new SearchFunction_Accessor(db.GetDB());
            DataTable dt = sc.SearchVehicle("55555");
            int expected = 1;
            int actual = dt.Rows.Count;
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void GUIAddCarTest_NormalPath2()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
            this.UIMap.GUIAddCar_NormalPath2();

            DBConnection_Accessor db = new DBConnection_Accessor();
            SearchFunction_Accessor sc = new SearchFunction_Accessor(db.GetDB());
            DataTable dt = sc.SearchVehicle("55555");
            String actual = dt.Rows[0][0].ToString();
            String expected = "55555";
            Assert.AreEqual(expected, actual);

        }


        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
