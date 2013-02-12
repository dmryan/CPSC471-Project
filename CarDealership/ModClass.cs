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
                throw new System.ArgumentException("Please Enter a Valid EID", "Modify");
                return;
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {

                    updatePerson.CommandText = "UPDATE Person SET PersonName = ? WHERE ID = ?";
                    updatePerson.Parameters.AddWithValue("@PersonName", data[1]);
                    updatePerson.Parameters.AddWithValue("@ID", data[0]);

                    updatePerson.ExecuteNonQuery();

                }
                if (data[2].CompareTo("") != 0)
                {

                    updatePerson.CommandText = "UPDATE Person SET PhoneNumber = ? WHERE ID = ?";
                    updatePerson.Parameters.AddWithValue("@PhoneNumber", data[2]);
                    updatePerson.Parameters.AddWithValue("@ID", data[0]);

                    updatePerson.ExecuteNonQuery();

                }
                if (data[3].CompareTo("") != 0)
                {

                    updatePerson.CommandText = "UPDATE Person SET Address = ? WHERE ID = ?";
                    updatePerson.Parameters.AddWithValue("@Address", data[3]);
                    updatePerson.Parameters.AddWithValue("@ID", data[0]);

                    updatePerson.ExecuteNonQuery();

                }
                if (data[4].CompareTo("") != 0)
                {

                    updatePerson.CommandText = "UPDATE Person SET Sex = ? WHERE ID = ?";
                    updatePerson.Parameters.AddWithValue("@Sex", data[4]);
                    updatePerson.Parameters.AddWithValue("@ID", data[0]);

                    updatePerson.ExecuteNonQuery();
                }
                if (data[5].CompareTo("") != 0)
                {

                    updateEmployee.CommandText = "UPDATE Employee SET Salary = ? WHERE EID = ?";
                    updateEmployee.Parameters.AddWithValue("@Salary", data[5]);
                    updateEmployee.Parameters.AddWithValue("@EID", data[0]);

                    updateEmployee.ExecuteNonQuery();

                }
                if (data[6].CompareTo("") != 0)
                {
                    updateEmployee.CommandText = "UPDATE Employee SET StartDate = ? WHERE EID = ?";
                    updateEmployee.Parameters.AddWithValue("@StartDate", data[6]);
                    updateEmployee.Parameters.AddWithValue("@EID", data[0]);

                    updateEmployee.ExecuteNonQuery();

                }
                if (data[7].CompareTo("") != 0)
                {
                    updateEmployee.CommandText = "UPDATE Employee SET ManagerID = ? WHERE EID = ?";
                    updateEmployee.Parameters.AddWithValue("@ManagerID", data[7]);
                    updateEmployee.Parameters.AddWithValue("@EID", data[0]);

                    updateEmployee.ExecuteNonQuery();
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
                throw new System.ArgumentException("Please Enter a Valid CID", "Modify");
                return;
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    updatePerson.CommandText = "UPDATE Person SET PersonName = ? WHERE ID = ?";
                    updatePerson.Parameters.AddWithValue("@PersonName", data[1]);
                    updatePerson.Parameters.AddWithValue("@ID", data[0]);

                    updatePerson.ExecuteNonQuery();
                }
                if (data[2].CompareTo("") != 0)
                {
                    updatePerson.CommandText = "UPDATE Person SET PhoneNumber = ? WHERE ID = ?";
                    updatePerson.Parameters.AddWithValue("@PhoneNumber", data[2]);
                    updatePerson.Parameters.AddWithValue("@ID", data[0]);

                    updatePerson.ExecuteNonQuery();
                }
                if (data[3].CompareTo("") != 0)
                {
                    updatePerson.CommandText = "UPDATE Person SET Address = ? WHERE ID = ?";
                    updatePerson.Parameters.AddWithValue("@Address", data[3]);
                    updatePerson.Parameters.AddWithValue("@ID", data[0]);

                    updatePerson.ExecuteNonQuery();
                }
                if (data[4].CompareTo("") != 0)
                {
                    updatePerson.CommandText = "UPDATE Person SET Sex = ? WHERE ID = ?";
                    updatePerson.Parameters.AddWithValue("@Sex", data[4]);
                    updatePerson.Parameters.AddWithValue("@ID", data[0]);

                    updatePerson.ExecuteNonQuery();
                }
                if (data[5].CompareTo("") != 0)
                {
                    updateCustomer.CommandText = "UPDATE Customer SET Type = ? WHERE CID = ?";
                    updateCustomer.Parameters.AddWithValue("@Type", data[5]);
                    updateCustomer.Parameters.AddWithValue("@CID", data[0]);

                    updateCustomer.ExecuteNonQuery();
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
                throw new System.ArgumentException("Please Enter a Valid VIN", "Modify");
                return;
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    updateVehicle.CommandText = "UPDATE Vehicle SET Model = ? WHERE VIN = ?";
                    updateVehicle.Parameters.AddWithValue("@Model", data[1]);
                    updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                    updateVehicle.ExecuteNonQuery();
                }
                if (data[2].CompareTo("") != 0)
                {
                    updateVehicle.CommandText = "UPDATE Vehicle SET YearProd = ? WHERE VIN = ?";
                    updateVehicle.Parameters.AddWithValue("@YearProd", data[2]);
                    updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                    updateVehicle.ExecuteNonQuery();
                }
                if (data[3].CompareTo("") != 0)
                {
                    updateVehicle.CommandText = "UPDATE Vehicle SET Maker = ? WHERE VIN = ?";
                    updateVehicle.Parameters.AddWithValue("@Maker", data[3]);
                    updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                    updateVehicle.ExecuteNonQuery();
                }
                if (data[4].CompareTo("") != 0)
                {
                    updateVehicle.CommandText = "UPDATE Vehicle SET NumberSeats = ? WHERE VIN = ?";
                    updateVehicle.Parameters.AddWithValue("@NumberSeats", data[4]);
                    updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                    updateVehicle.ExecuteNonQuery();
                }
                if (data[5].CompareTo("") != 0)
                {
                    updateVehicle.CommandText = "UPDATE Vehicle SET Price = ? WHERE VIN = ?";
                    updateVehicle.Parameters.AddWithValue("@Price", data[5]);
                    updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                    updateVehicle.ExecuteNonQuery();
                }
                if (data[6].CompareTo("") != 0)
                {
                    updateCar.CommandText = "UPDATE Car SET Type = ? WHERE VIN = ?";
                    updateCar.Parameters.AddWithValue("@Type", data[6]);
                    updateCar.Parameters.AddWithValue("@VIN", data[0]);

                    updateCar.ExecuteNonQuery();
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
                throw new System.ArgumentException("Please Enter a Valid VIN", "Modify");
                return;
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    updateVehicle.CommandText = "UPDATE Vehicle SET Model = ? WHERE VIN = ?";
                    updateVehicle.Parameters.AddWithValue("@Model", data[1]);
                    updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                    updateVehicle.ExecuteNonQuery();
                }
                if (data[2].CompareTo("") != 0)
                {
                    updateVehicle.CommandText = "UPDATE Vehicle SET YearProd = ? WHERE VIN = ?";
                    updateVehicle.Parameters.AddWithValue("@YearProd", data[2]);
                    updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                    updateVehicle.ExecuteNonQuery();
                }
                if (data[3].CompareTo("") != 0)
                {
                    updateVehicle.CommandText = "UPDATE Vehicle SET Maker = ? WHERE VIN = ?";
                    updateVehicle.Parameters.AddWithValue("@Maker", data[3]);
                    updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                    updateVehicle.ExecuteNonQuery();
                }
                if (data[4].CompareTo("") != 0)
                {
                    updateVehicle.CommandText = "UPDATE Vehicle SET NumberSeats = ? WHERE VIN = ?";
                    updateVehicle.Parameters.AddWithValue("@NumberSeats", data[4]);
                    updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                    updateVehicle.ExecuteNonQuery();
                }
                if (data[5].CompareTo("") != 0)
                {
                    updateVehicle.CommandText = "UPDATE Vehicle SET Price = ? WHERE VIN = ?";
                    updateVehicle.Parameters.AddWithValue("@Price", data[5]);
                    updateVehicle.Parameters.AddWithValue("@VIN", data[0]);

                    updateVehicle.ExecuteNonQuery();
                }
                if (data[6].CompareTo("") != 0)
                {
                    updateTruck.CommandText = "UPDATE Truck SET TowingCapacity = ? WHERE VIN = ?";
                    updateTruck.Parameters.AddWithValue("@TowingCapacity", data[6]);
                    updateTruck.Parameters.AddWithValue("@VIN", data[0]);

                    updateTruck.ExecuteNonQuery();
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
                throw new System.ArgumentException("Please Enter a Valid VIN", "Modify");
                return;
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    updateVHR.CommandText = "UPDATE VehicleHistoryReport SET NumberOwners = ? WHERE VIN = ?";
                    updateVHR.Parameters.AddWithValue("@NumberOwners", data[1]);
                    updateVHR.Parameters.AddWithValue("@VIN", data[0]);

                    updateVHR.ExecuteNonQuery();
                }
                if (data[2].CompareTo("") != 0)
                {
                    updateVHR.CommandText = "UPDATE VehicleHistoryReport SET Rating = ? WHERE VIN = ?";
                    updateVHR.Parameters.AddWithValue("@Rating", data[2]);
                    updateVHR.Parameters.AddWithValue("@VIN", data[0]);

                    updateVHR.ExecuteNonQuery();
                }
                if (data[3].CompareTo("") != 0)
                {
                    updateVHR.CommandText = "UPDATE VehicleHistoryReport SET Mileage = ? WHERE VIN = ?";
                    updateVHR.Parameters.AddWithValue("@Mileage", data[3]);
                    updateVHR.Parameters.AddWithValue("@VIN", data[0]);

                    updateVHR.ExecuteNonQuery();
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
                throw new System.ArgumentException("Please Enter a Valid Serial Number", "Modify");
                return;
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    updatePart.CommandText = "UPDATE Part SET VIN = ? WHERE SerialNumber = ?";
                    updatePart.Parameters.AddWithValue("@VIN", data[1]);
                    updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updatePart.ExecuteNonQuery();
                }
                if (data[2].CompareTo("") != 0)
                {
                    updatePart.CommandText = "UPDATE Part SET PartName = ? WHERE SerialNumber = ?";
                    updatePart.Parameters.AddWithValue("@PartName", data[2]);
                    updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updatePart.ExecuteNonQuery();
                }
                if (data[3].CompareTo("") != 0)
                {
                    updatePart.CommandText = "UPDATE Part SET Manufacturer = ? WHERE SerialNumber = ?";
                    updatePart.Parameters.AddWithValue("@Manufacturer", data[3]);
                    updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updatePart.ExecuteNonQuery();
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
                throw new System.ArgumentException("Please Enter a Valid Serial Number", "Modify");
                return;
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    updatePart.CommandText = "UPDATE Part SET VIN = ? WHERE SerialNumber = ?";
                    updatePart.Parameters.AddWithValue("@VIN", data[1]);
                    updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updatePart.ExecuteNonQuery();
                }
                if (data[2].CompareTo("") != 0)
                {
                    updatePart.CommandText = "UPDATE Part SET PartName = ? WHERE SerialNumber = ?";
                    updatePart.Parameters.AddWithValue("@PartName", data[2]);
                    updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updatePart.ExecuteNonQuery();
                }
                if (data[3].CompareTo("") != 0)
                {
                    updatePart.CommandText = "UPDATE Part SET Manufacturer = ? WHERE SerialNumber = ?";
                    updatePart.Parameters.AddWithValue("@Manufacturer", data[3]);
                    updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updatePart.ExecuteNonQuery();
                }
                if (data[4].CompareTo("") != 0)
                {
                    updateTire.CommandText = "UPDATE Tire SET Type = ? WHERE SerialNumber = ?";
                    updateTire.Parameters.AddWithValue("@NumberSeats", data[4]);
                    updateTire.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updateTire.ExecuteNonQuery();
                }
                if (data[5].CompareTo("") != 0)
                {
                    updateTire.CommandText = "UPDATE Tire SET TireSize = ? WHERE SerialNumber = ?";
                    updateTire.Parameters.AddWithValue("@TireSize", data[5]);
                    updateTire.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updateTire.ExecuteNonQuery();
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
                throw new System.ArgumentException("Please Enter a Valid Serial Number", "Modify");
                return;
            }
            else
            {
                if (data[1].CompareTo("") != 0)
                {
                    updatePart.CommandText = "UPDATE Part SET VIN = ? WHERE SerialNumber = ?";
                    updatePart.Parameters.AddWithValue("@VIN", data[1]);
                    updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updatePart.ExecuteNonQuery();
                }
                if (data[2].CompareTo("") != 0)
                {
                    updatePart.CommandText = "UPDATE Part SET PartName = ? WHERE SerialNumber = ?";
                    updatePart.Parameters.AddWithValue("@PartName", data[2]);
                    updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updatePart.ExecuteNonQuery();
                }
                if (data[3].CompareTo("") != 0)
                {
                    updatePart.CommandText = "UPDATE Part SET Manufacturer = ? WHERE SerialNumber = ?";
                    updatePart.Parameters.AddWithValue("@Manufacturer", data[3]);
                    updatePart.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updatePart.ExecuteNonQuery();
                }
                if (data[4].CompareTo("") != 0)
                {
                    updateEngine.CommandText = "UPDATE Engine SET Cylinders = ? WHERE SerialNumber = ?";
                    updateEngine.Parameters.AddWithValue("@Cylinders", data[4]);
                    updateEngine.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updateEngine.ExecuteNonQuery();
                }
                if (data[5].CompareTo("") != 0)
                {
                    updateEngine.CommandText = "UPDATE Engine SET HorsePower = ? WHERE SerialNumber = ?";
                    updateEngine.Parameters.AddWithValue("@HorsePower", data[5]);
                    updateEngine.Parameters.AddWithValue("@SerialNumber", data[0]);

                    updateEngine.ExecuteNonQuery();
                }
            }
        }
    }
}
