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
    public class AddPartTests
    {
        [TestMethod]
        public void AddPart_NormalPath()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();

            String[] D = new String[] { "1", "22", "123", "123", "123", "123" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeletePart(1);
            }
            catch (Exception)
            {

            }
            mc.CreatePart();

        }

        [TestMethod]
        public void AddPart_OnlyID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "2", "", "", "", "", "" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeletePart(2);
            }
            catch (Exception)
            {

            }
            mc.CreatePart();

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddPart_NullID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "", "", "", "", "", "" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());

            mc.CreatePart();

        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddPart_DuplicateID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "1", "22", "123", "123", "123", "123" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeletePart(1);
            }
            catch (Exception)
            {

            }
            mc.CreatePart();
            mc.CreatePart();

        }


        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void AddPart_NegativeID()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "-5", "22", "", "", "", "" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeletePart(-5);
            }
            catch (Exception)
            {

            }
            mc.CreatePart();

        }
       

        /// <summary>
        /// //////////////////////////////////////////
        /// </summary>
        /// 
        [TestMethod]
        public void AddEngine_NormalPath()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "1", "22", "Name", "Man", "", "" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            MakeEngine_Accessor me = new MakeEngine_Accessor("1", "350", "6", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            try
            {
                d.DeletePart(1);
            }
            catch (Exception)
            {

            }
            mc.CreatePart();
            me.CreateEngine();


        }
        [TestMethod]
        public void AddTires_NormalPath()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "1", "22", "Name", "Man", "", "" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            MakeTires_Accessor me = new MakeTires_Accessor("1", "Winter", "50", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            try
            {
                d.DeletePart(1);
            }
            catch (Exception)
            {

            }
            mc.CreatePart();
            me.CreateTires();

        }
        [TestMethod]
        public void AddEngine_Empty()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "2", "", "", "", "", "" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            MakeEngine_Accessor me = new MakeEngine_Accessor("2", "", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeletePart(2);
            }
            catch (Exception)
            {

            }
            mc.CreatePart();
            me.CreateEngine();

        }
        [TestMethod]
        public void AddTires_Empty()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            String[] D = new String[] { "1", "", "", "", "", "" };
            MakePart_Accessor mc = new MakePart_Accessor(D, db.GetDB());
            MakeTires_Accessor me = new MakeTires_Accessor("1", "", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());

            MakeVehicle_Accessor mp = new MakeVehicle_Accessor(D, db.GetDB());
            try
            {
                d.DeletePart(1);
            }
            catch (Exception)
            {

            }
            mc.CreatePart();
            me.CreateTires();

        }
        [TestMethod]
        public void AddEngine_DeleteInstance()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeEngine_Accessor mc = new MakeEngine_Accessor("1", "", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "", "", "", "", "" };

            MakePart_Accessor mp = new MakePart_Accessor(D, db.GetDB());
            try
            {
                d.DeletePart(1);
            }
            catch (Exception)
            {

            }
            mp.CreatePart();
            mc.CreateEngine();

            SearchFunction_Accessor SF = new SearchFunction_Accessor(db.GetDB());
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            try
            {
                dt2 = SF.SearchPart("1");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            mc.DeleteEngine();
            mp.DeletePart();

            try
            {
                dt1 = SF.SearchPart("1");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            Assert.IsTrue(dt1.Rows.Count == 0 && dt2.Rows.Count == 1);

        }
        [TestMethod]
        public void AddTires_DeleteInstance()
        {
            DBConnection_Accessor db = new DBConnection_Accessor();
            MakeTires_Accessor mc = new MakeTires_Accessor("1", "", "", db.GetDB());
            Delete_Accessor d = new Delete_Accessor(db.GetDB());
            String[] D = new String[] { "1", "", "", "", "", "" };

            MakePart_Accessor mp = new MakePart_Accessor(D, db.GetDB());
            try
            {
                d.DeletePart(1);
            }
            catch (Exception)
            {

            }
            mp.CreatePart();
            mc.CreateTires();

            SearchFunction_Accessor SF = new SearchFunction_Accessor(db.GetDB());
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            try
            {
                dt2 = SF.SearchPart("1");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            mc.DeleteTires();
            mp.DeletePart();

            try
            {
                dt1 = SF.SearchPart("1");
            }
            catch (OleDbException ex)
            {
                throw ex;
            }

            Assert.IsTrue(dt1.Rows.Count == 0 && dt2.Rows.Count == 1);

        }
     
    }
}

