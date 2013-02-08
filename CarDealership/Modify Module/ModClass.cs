using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CarDealership
{
    class ModClass
    {
        private OleDbConnection cn;
        public ModClass(OleDbConnection cn)
        {
            this.cn = cn;
        }
        public void ModifyEmployee(string[] data)
        {
                OleDbCommand updatePerson = cn.CreateCommand();
                OleDbCommand updateEmployee = cn.CreateCommand();
                OleDbCommand selectEmployee = cn.CreateCommand();
                selectEmployee.CommandText = "SELECT EID FROM Employee WHERE EID = @EID";
                selectEmployee.Parameters.AddWithValue("@EID", data[0]);

                if (data[0].CompareTo("") == 0 || selectEmployee.ExecuteScalar() == null)
                {
                    ErrorWindow Error = new ErrorWindow("Please enter a valid EID");
                    Error.Title = "EID Field Error";
                    Error.ShowDialog();
                }
                else
                {
                    if (data[1].CompareTo("") != 0)
                    {
                        try
                        {
                            updatePerson.CommandText = "UPDATE Person SET PersonName = ? WHERE ID = ?";
                            updatePerson.Parameters.AddWithValue("@PersonName", data[1]);
                            updatePerson.Parameters.AddWithValue("@ID", data[0]);

                            updatePerson.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Name Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (data[2].CompareTo("") != 0)
                    {
                        try
                        {
                            updatePerson.CommandText = "UPDATE Person SET PhoneNumber = ? WHERE ID = ?";
                            updatePerson.Parameters.AddWithValue("@PhoneNumber", data[2]);
                            updatePerson.Parameters.AddWithValue("@ID", data[0]);

                            updatePerson.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Phone Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (data[3].CompareTo("") != 0)
                    {
                        try
                        {
                            updatePerson.CommandText = "UPDATE Person SET Address = ? WHERE ID = ?";
                            updatePerson.Parameters.AddWithValue("@Address", data[3]);
                            updatePerson.Parameters.AddWithValue("@ID", data[0]);

                            updatePerson.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Address Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (data[4].CompareTo("") != 0)
                    {
                        try
                        {
                            updatePerson.CommandText = "UPDATE Person SET Sex = ? WHERE ID = ?";
                            updatePerson.Parameters.AddWithValue("@Sex", data[4]);
                            updatePerson.Parameters.AddWithValue("@ID", data[0]);

                            updatePerson.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Sex Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (data[5].CompareTo("") != 0)
                    {
                        try
                        {
                            updateEmployee.CommandText = "UPDATE Employee SET Salary = ? WHERE EID = ?";
                            updateEmployee.Parameters.AddWithValue("@Salary", data[5]);
                            updateEmployee.Parameters.AddWithValue("@EID", data[0]);

                            updateEmployee.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Salary Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (data[6].CompareTo("") != 0)
                    {
                        try
                        {
                            updateEmployee.CommandText = "UPDATE Employee SET StartDate = ? WHERE EID = ?";
                            updateEmployee.Parameters.AddWithValue("@StartDate", data[6]);
                            updateEmployee.Parameters.AddWithValue("@EID", data[0]);

                            updateEmployee.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Start Date Field Error";
                            Error.ShowDialog();
                        }
                    }
                    if (data[7].CompareTo("") != 0)
                    {
                        try
                        {
                            updateEmployee.CommandText = "UPDATE Employee SET ManagerID = ? WHERE EID = ?";
                            updateEmployee.Parameters.AddWithValue("@ManagerID", data[7]);
                            updateEmployee.Parameters.AddWithValue("@EID", data[0]);

                            updateEmployee.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            ErrorWindow Error = new ErrorWindow(ex.Message);
                            Error.Title = "Manager Field Error";
                            Error.ShowDialog();
                        }
                    }
                }
        }

        public void ModifyCustomer(string[] data)
        {
            OleDbCommand updatePerson = cn.CreateCommand();
            OleDbCommand updateCustomer = cn.CreateCommand();
            OleDbCommand selectCustomer = cn.CreateCommand();

            selectCustomer.CommandText = "SELECT CID FROM Customer WHERE CID = @CID";
            selectCustomer.Parameters.AddWithValue("@CID", data[0]);

            if (data[0].CompareTo("") == 0 || selectCustomer.ExecuteScalar() == null)
            {
                ErrorWindow Error = new ErrorWindow("Please enter a valid CID");
                Error.Title = "CID Field Error";
                Error.ShowDialog();
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    try
                    {
                        updatePerson.CommandText = "UPDATE Person SET PersonName = ? WHERE ID = ?";
                        updatePerson.Parameters.AddWithValue("@PersonName", data[1]);
                        updatePerson.Parameters.AddWithValue("@ID", data[0]);

                        updatePerson.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Name Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[2].CompareTo("") != 0)
                {
                    try
                    {
                        updatePerson.CommandText = "UPDATE Person SET PhoneNumber = ? WHERE ID = ?";
                        updatePerson.Parameters.AddWithValue("@PhoneNumber", data[2]);
                        updatePerson.Parameters.AddWithValue("@ID", data[0]);

                        updatePerson.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Phone Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[3].CompareTo("") != 0)
                {
                    try
                    {
                        updatePerson.CommandText = "UPDATE Person SET Address = ? WHERE ID = ?";
                        updatePerson.Parameters.AddWithValue("@Address", data[3]);
                        updatePerson.Parameters.AddWithValue("@ID", data[0]);

                        updatePerson.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Address Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[4].CompareTo("") != 0)
                {
                    try
                    {
                        updatePerson.CommandText = "UPDATE Person SET Sex = ? WHERE ID = ?";
                        updatePerson.Parameters.AddWithValue("@Sex", data[4]);
                        updatePerson.Parameters.AddWithValue("@ID", data[0]);

                        updatePerson.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Sex Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[5].CompareTo("") != 0)
                {
                    try
                    {
                        updateCustomer.CommandText = "UPDATE Customer SET Type = ? WHERE CID = ?";
                        updateCustomer.Parameters.AddWithValue("@Type", data[5]);
                        updateCustomer.Parameters.AddWithValue("@CID", data[0]);

                        updateCustomer.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Salary Field Error";
                        Error.ShowDialog();
                    }
                }
            }
        }

        public void ModifyCar(string[] data)
        {
            OleDbCommand updateVehicle = cn.CreateCommand();
            OleDbCommand updateCar = cn.CreateCommand();
            OleDbCommand selectCar = cn.CreateCommand();

            selectCar.CommandText = "SELECT VIN FROM Car WHERE VIN = @VIN";
            selectCar.Parameters.AddWithValue("@VIN", data[0]);

            if (data[0].CompareTo("") == 0 || selectCar.ExecuteScalar() == null)
            {
                ErrorWindow Error = new ErrorWindow("Please enter a valid VIN");
                Error.Title = "VIN Field Error";
                Error.ShowDialog();
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    try
                    {
                        updateVehicle.CommandText = "UPDATE Vehicle SET Model = ? WHERE VIN = ?";
                        updateVehicle.Parameters.AddWithValue("@Model", data[1]);
                        updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                        updateVehicle.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Model Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[2].CompareTo("") != 0)
                {
                    try
                    {
                        updateVehicle.CommandText = "UPDATE Vehicle SET YearProd = ? WHERE VIN = ?";
                        updateVehicle.Parameters.AddWithValue("@YearProd", data[2]);
                        updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                        updateVehicle.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Year Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[3].CompareTo("") != 0)
                {
                    try
                    {
                        updateVehicle.CommandText = "UPDATE Vehicle SET Maker = ? WHERE VIN = ?";
                        updateVehicle.Parameters.AddWithValue("@Maker", data[3]);
                        updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                        updateVehicle.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Maker Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[4].CompareTo("") != 0)
                {
                    try
                    {
                        updateVehicle.CommandText = "UPDATE Vehicle SET NumberSeats = ? WHERE VIN = ?";
                        updateVehicle.Parameters.AddWithValue("@NumberSeats", data[4]);
                        updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                        updateVehicle.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Number of Seats Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[5].CompareTo("") != 0)
                {
                    try
                    {
                        updateVehicle.CommandText = "UPDATE Vehicle SET Price = ? WHERE VIN = ?";
                        updateVehicle.Parameters.AddWithValue("@Price", data[5]);
                        updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                        updateVehicle.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Price Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[6].CompareTo("") != 0)
                {
                    try
                    {
                        updateCar.CommandText = "UPDATE Car SET Type = ? WHERE VIN = ?";
                        updateCar.Parameters.AddWithValue("@Type", data[6]);
                        updateCar.Parameters.AddWithValue("@VIN", data[0]);

                        updateCar.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Type Field Error";
                        Error.ShowDialog();
                    }
                }
            }
        }

        public void ModifyTruck(string[] data)
        {
            OleDbCommand updateVehicle = cn.CreateCommand();
            OleDbCommand updateTruck = cn.CreateCommand();
            OleDbCommand selectTruck = cn.CreateCommand();

            selectTruck.CommandText = "SELECT VIN FROM Truck WHERE VIN = @VIN";
            selectTruck.Parameters.AddWithValue("@VIN", data[0]);

            if (data[0].CompareTo("") == 0 || selectTruck.ExecuteScalar() == null)
            {
                ErrorWindow Error = new ErrorWindow("Please enter a valid VIN");
                Error.Title = "VIN Field Error";
                Error.ShowDialog();
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    try
                    {
                        updateVehicle.CommandText = "UPDATE Vehicle SET Model = ? WHERE VIN = ?";
                        updateVehicle.Parameters.AddWithValue("@Model", data[1]);
                        updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                        updateVehicle.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Model Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[2].CompareTo("") != 0)
                {
                    try
                    {
                        updateVehicle.CommandText = "UPDATE Vehicle SET YearProd = ? WHERE VIN = ?";
                        updateVehicle.Parameters.AddWithValue("@YearProd", data[2]);
                        updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                        updateVehicle.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Year Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[3].CompareTo("") != 0)
                {
                    try
                    {
                        updateVehicle.CommandText = "UPDATE Vehicle SET Maker = ? WHERE VIN = ?";
                        updateVehicle.Parameters.AddWithValue("@Maker", data[3]);
                        updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                        updateVehicle.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Maker Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[4].CompareTo("") != 0)
                {
                    try
                    {
                        updateVehicle.CommandText = "UPDATE Vehicle SET NumberSeats = ? WHERE VIN = ?";
                        updateVehicle.Parameters.AddWithValue("@NumberSeats", data[4]);
                        updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                        updateVehicle.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Number of Seats Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[5].CompareTo("") != 0)
                {
                    try
                    {
                        updateVehicle.CommandText = "UPDATE Vehicle SET Price = ? WHERE VIN = ?";
                        updateVehicle.Parameters.AddWithValue("@Price", data[5]);
                        updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                        updateVehicle.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Price Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[6].CompareTo("") != 0)
                {
                    try
                    {
                        updateTruck.CommandText = "UPDATE Truck SET TowingCapacity = ? WHERE VIN = ?";
                        updateTruck.Parameters.AddWithValue("@TowingCapacity", data[6]);
                        updateTruck.Parameters.AddWithValue("@VIN", data[0]);

                        updateTruck.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "TowingCapacity Field Error";
                        Error.ShowDialog();
                    }
                }
            }
        }

        public void ModifyVHR(string[] data)
        {
            OleDbCommand updateVHR = cn.CreateCommand();
            OleDbCommand selectVHR = cn.CreateCommand();

            selectVHR.CommandText = "SELECT VIN FROM VehicleHistoryReport WHERE VIN = @VIN";
            selectVHR.Parameters.AddWithValue("@VIN", data[0]);

            if (data[0].CompareTo("") == 0 || selectVHR.ExecuteScalar() == null)
            {
                ErrorWindow Error = new ErrorWindow("Please enter a valid VIN");
                Error.Title = "VIN Field Error";
                Error.ShowDialog();
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    try
                    {
                        updateVHR.CommandText = "UPDATE VehicleHistoryReport SET NumberOwners = ? WHERE VIN = ?";
                        updateVHR.Parameters.AddWithValue("@NumberOwners", data[1]);
                        updateVHR.Parameters.AddWithValue("@VIN", data[0]);

                        updateVHR.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Number of Owners Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[2].CompareTo("") != 0)
                {
                    try
                    {
                        updateVHR.CommandText = "UPDATE VehicleHistoryReport SET Rating = ? WHERE VIN = ?";
                        updateVHR.Parameters.AddWithValue("@Rating", data[2]);
                        updateVHR.Parameters.AddWithValue("@VIN", data[0]);

                        updateVHR.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Rating Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[3].CompareTo("") != 0)
                {
                    try
                    {
                        updateVHR.CommandText = "UPDATE VehicleHistoryReport SET Mileage = ? WHERE VIN = ?";
                        updateVHR.Parameters.AddWithValue("@Mileage", data[3]);
                        updateVHR.Parameters.AddWithValue("@VIN", data[0]);

                        updateVHR.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Mileage Field Error";
                        Error.ShowDialog();
                    }
                }
            }
        }

        public void ModifyPart(string[] data)
        {
            OleDbCommand updatePart = cn.CreateCommand();
            OleDbCommand selectPart = cn.CreateCommand();

            selectPart.CommandText = "SELECT SerialNumber FROM Part WHERE SerialNumber = @SerialNumber";
            selectPart.Parameters.AddWithValue("@SerialNumber", data[0]);

            if (data[0].CompareTo("") == 0 || selectPart.ExecuteScalar() == null)
            {
                ErrorWindow Error = new ErrorWindow("Please enter a valid Serial Number");
                Error.Title = "Serial# Field Error";
                Error.ShowDialog();
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    try
                    {
                        updatePart.CommandText = "UPDATE Part SET VIN = ? WHERE SerialNumber = ?";
                        updatePart.Parameters.AddWithValue("@VIN", data[1]);
                        updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updatePart.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "VIN Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[2].CompareTo("") != 0)
                {
                    try
                    {
                        updatePart.CommandText = "UPDATE Part SET PartName = ? WHERE SerialNumber = ?";
                        updatePart.Parameters.AddWithValue("@PartName", data[2]);
                        updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updatePart.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "PartName Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[3].CompareTo("") != 0)
                {
                    try
                    {
                        updatePart.CommandText = "UPDATE Part SET Manufacturer = ? WHERE SerialNumber = ?";
                        updatePart.Parameters.AddWithValue("@Manufacturer", data[3]);
                        updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updatePart.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Manufacturer Field Error";
                        Error.ShowDialog();
                    }
                }
            }
        }

        public void ModifyTires(string[] data)
        {
            OleDbCommand updatePart = cn.CreateCommand();
            OleDbCommand updateTire = cn.CreateCommand();
            OleDbCommand selectTire = cn.CreateCommand();

            selectTire.CommandText = "SELECT SerialNumber FROM Tire WHERE SerialNumber = @SerialNumber";
            selectTire.Parameters.AddWithValue("@SerialNumber", data[0]);

            if (data[0].CompareTo("") == 0 || selectTire.ExecuteScalar() == null)
            {
                ErrorWindow Error = new ErrorWindow("Please enter a valid Serial Number");
                Error.Title = "Serial# Field Error";
                Error.ShowDialog();
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    try
                    {
                        updatePart.CommandText = "UPDATE Part SET VIN = ? WHERE SerialNumber = ?";
                        updatePart.Parameters.AddWithValue("@VIN", data[1]);
                        updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updatePart.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "VIN Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[2].CompareTo("") != 0)
                {
                    try
                    {
                        updatePart.CommandText = "UPDATE Part SET PartName = ? WHERE SerialNumber = ?";
                        updatePart.Parameters.AddWithValue("@PartName", data[2]);
                        updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updatePart.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "PartName Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[3].CompareTo("") != 0)
                {
                    try
                    {
                        updatePart.CommandText = "UPDATE Part SET Manufacturer = ? WHERE SerialNumber = ?";
                        updatePart.Parameters.AddWithValue("@Manufacturer", data[3]);
                        updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updatePart.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Manufacturer Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[4].CompareTo("") != 0)
                {
                    try
                    {
                        updateTire.CommandText = "UPDATE Tire SET Type = ? WHERE SerialNumber = ?";
                        updateTire.Parameters.AddWithValue("@NumberSeats", data[4]);
                        updateTire.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updateTire.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Type Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[5].CompareTo("") != 0)
                {
                    try
                    {
                        updateTire.CommandText = "UPDATE Tire SET TireSize = ? WHERE SerialNumber = ?";
                        updateTire.Parameters.AddWithValue("@TireSize", data[5]);
                        updateTire.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updateTire.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Size Field Error";
                        Error.ShowDialog();
                    }
                }
            }
        }

        public void ModifyEngine(string[] data)
        {
            OleDbCommand updatePart = cn.CreateCommand();
            OleDbCommand updateEngine = cn.CreateCommand();
            OleDbCommand selectEngine = cn.CreateCommand();

            selectEngine.CommandText = "SELECT SerialNumber FROM Engine WHERE SerialNumber = @SerialNumber";
            selectEngine.Parameters.AddWithValue("@SerialNumber", data[0]);

            if (data[0].CompareTo("") == 0 || selectEngine.ExecuteScalar() == null)
            {
                ErrorWindow Error = new ErrorWindow("Please enter a valid Serial Number");
                Error.Title = "Serial# Field Error";
                Error.ShowDialog();
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    try
                    {
                        updatePart.CommandText = "UPDATE Part SET VIN = ? WHERE SerialNumber = ?";
                        updatePart.Parameters.AddWithValue("@VIN", data[1]);
                        updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updatePart.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "VIN Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[2].CompareTo("") != 0)
                {
                    try
                    {
                        updatePart.CommandText = "UPDATE Part SET PartName = ? WHERE SerialNumber = ?";
                        updatePart.Parameters.AddWithValue("@PartName", data[2]);
                        updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updatePart.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "PartName Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[3].CompareTo("") != 0)
                {
                    try
                    {
                        updatePart.CommandText = "UPDATE Part SET Manufacturer = ? WHERE SerialNumber = ?";
                        updatePart.Parameters.AddWithValue("@Manufacturer", data[3]);
                        updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updatePart.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Manufacturer Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[4].CompareTo("") != 0)
                {
                    try
                    {
                        updateEngine.CommandText = "UPDATE Engine SET Cylinders = ? WHERE SerialNumber = ?";
                        updateEngine.Parameters.AddWithValue("@Cylinders", data[4]);
                        updateEngine.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updateEngine.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "Cylinders Field Error";
                        Error.ShowDialog();
                    }
                }
                if (data[5].CompareTo("") != 0)
                {
                    try
                    {
                        updateEngine.CommandText = "UPDATE Engine SET HorsePower = ? WHERE SerialNumber = ?";
                        updateEngine.Parameters.AddWithValue("@HorsePower", data[5]);
                        updateEngine.Parameters.AddWithValue("@SerialNumber", data[0]);

                        updateEngine.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        ErrorWindow Error = new ErrorWindow(ex.Message);
                        Error.Title = "HorsePower Field Error";
                        Error.ShowDialog();
                    }
                }
            }
        }
    }
}
