﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace CarDealership
{
    /// <summary>
    /// Interaction logic for AddTruck.xaml
    /// </summary>
    public partial class AddTruck : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        private VehicleHistoryReport R;
        private bool used;
        private bool noError;

        public AddTruck(MainWindow p, OleDbConnection c, bool u)
        {
            cn = c;
            Parent = p;
            used = u;
            InitializeComponent();
        }

        private void AddTruckSubmit_Click(object sender, RoutedEventArgs e)
        {
            string[] Data = new string[6];
            Data[0] = VINText.GetLineText(0);
            Data[1] = ModelText.GetLineText(0);
            Data[2] = YearText.GetLineText(0);
            Data[3] = ManufacturerText.GetLineText(0);
            Data[4] = SeatsText.GetLineText(0);
            Data[5] = PriceText.GetLineText(0);
            string TowingCapacity = TowingCapText.GetLineText(0);
            string VIN = Data[0];

            MakeVehicle V = new MakeVehicle(Data, cn);
            MakeTruck T = new MakeTruck(VIN, TowingCapacity, cn);

            try
            {
                V.CreateVehicle();
            }
            catch (OleDbException ex)
            {
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
                return;
            }
            try
            {
                T.CreateTruck();
            }
            catch (OleDbException ex)
            {
                try
                {
                    V.DeleteVehicle();
                }
                catch (OleDbException ex2) { }

                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
                return;
            }

            if (used)
            {
                R = new VehicleHistoryReport(Parent, cn);
                R.ShowDialog();
            }
            this.Close();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
