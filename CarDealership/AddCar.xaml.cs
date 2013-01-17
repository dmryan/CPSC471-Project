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
    /// Interaction logic for AddCar.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        private VehicleHistoryReport R;
        private bool used;
        private bool noError;

        public AddCar(MainWindow p, OleDbConnection c, bool u)
        {
            cn = c;
            Parent = p;
            used = u;
            InitializeComponent();
        }

        private void AddCarSubmit_Click(object sender, RoutedEventArgs e)
        {
            noError = true;
            string[] Data = new string[6];
            Data[0] = VINText.GetLineText(0);
            Data[1] = ModelText.GetLineText(0);
            Data[2] = YearText.GetLineText(0);
            Data[3] = ManufacturerText.GetLineText(0);
            Data[4] = SeatsText.GetLineText(0);
            Data[5] = PriceText.GetLineText(0);
            string Type = TypeText.GetLineText(0);
            string VIN = Data[0];
            
            MakeVehicle V = new MakeVehicle(Data, cn);
            MakeCar C = new MakeCar(VIN, Type, cn);

            try
            {
                V.CreateVehicle();
            }
            catch (OleDbException ex)
            {
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }
            try
            {
                C.CreateCar();
            }
            catch (OleDbException ex)
            {
                OleDbCommand deleteVehicle = cn.CreateCommand();
                deleteVehicle.CommandText = ("DELETE FROM VEHICLE WHERE ID =" + VIN);
                try
                {
                    deleteVehicle.ExecuteNonQuery();
                }
                catch (OleDbException ex2) { }
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }
            if (noError)
            {
                if (used)
                {
                    R = new VehicleHistoryReport(Parent, cn);
                    R.Show();
                }
                this.Close();
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
