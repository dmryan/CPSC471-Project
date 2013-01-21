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
    /// Interaction logic for AddTires.xaml
    /// </summary>
    public partial class AddTires : Window
    {
        private OleDbConnection cn;
        private MainWindow Parent;
        private bool noError;

        public AddTires(MainWindow p, OleDbConnection c)
        {
            cn = c;
            Parent = p;
            InitializeComponent();
        }

        private void AddTire_Click(object sender, RoutedEventArgs e)
        {
            noError = true;
            string[] Data = new string[4];
            Data[0] = SerialNumberText.GetLineText(0);
            Data[1] = VINText.GetLineText(0);
            Data[2] = NameText.GetLineText(0);
            Data[3] = ManufacturerText.GetLineText(0);
            string SerialNumber = Data[0];
            string Type = TypeText.GetLineText(0);
            string Size = SizeText.GetLineText(0);

            MakePart P = new MakePart(Data, cn);
            MakeTires T = new MakeTires(SerialNumber, Type, Size, cn);

            try
            {
                P.CreatePart();
            }
            catch (OleDbException ex)
            {
                noError = false;
                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
            }
            try
            {
                T.CreateTires();
            }
            catch (OleDbException ex)
            {
                try
                {
                    P.DeletePart();
                }
                catch (OleDbException ex2) { }

                ErrorWindow Error = new ErrorWindow(ex.Message);
                Error.ShowDialog();
                return;
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
