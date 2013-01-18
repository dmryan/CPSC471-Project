using System;
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
    /// Interaction logic for VehicleHistoryReport.xaml
    /// </summary>
    public partial class VehicleHistoryReport : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        private bool noError;

        public VehicleHistoryReport(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            InitializeComponent();
        }

        private void AddVehicleHistoryReport_Click(object sender, RoutedEventArgs e)
        {
            noError = true;
            string[] Data = new string[4];
            Data[0] = VINText.GetLineText(0);
            Data[1] = NumOwnersText.GetLineText(0);
            Data[2] = RatingText.GetLineText(0);
            Data[3] = MileageText.GetLineText(0);

            MakeVHR VHR = new MakeVHR(Data, cn);

            try
            {
                VHR.CreateVHR();
            }
            catch (OleDbException ex)
            {
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }
            if (noError)
                this.Close();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
