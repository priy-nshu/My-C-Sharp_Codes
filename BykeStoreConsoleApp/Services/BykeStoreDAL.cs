using BykeStoreConsoleApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BykeStoreConsoleApp.Services
{
    internal class BykeStoreDAL
    {
        //ALl properties required for working with SQL Server DB


        public SqlConnection _Con;
        public SqlCommand _Command;
        public SqlDataReader _DataReader;
        public string _ConStr;
        public Staff staff;

        public BykeStoreDAL(string str)
        {
            _Con = null;
            _Command = null;
            _DataReader = null;
            _ConStr = str;
            staff = null;
        }

        //All methods for working with Staff table - CRUD

        public void DisplayStaff()
        {
            List<Staff> staffs = new List<Staff>();
            //step 1
            _Con = new SqlConnection(_ConStr);
            //step 2
            _Command = new SqlCommand("Select * from sales.Staffs", _Con);
            try
            {
                if (_Con.State == ConnectionState.Closed)
                {   //Step 3
                    _Con.Open();
                }
                //step 4 execute the command
                _DataReader = _Command.ExecuteReader();
                //step 5 -travserse through to read all the records
                while (_DataReader.Read())
                {
                    Console.WriteLine(_DataReader["staff_id"] + "," + _DataReader["first_name"] + ","
                        + _DataReader["last_name"] + "," + _DataReader["email"] + "\n");
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Something went wrong: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            finally
            {
                if (_Con.State == ConnectionState.Open)
                {
                    _Con.Close();
                }
            }
        }

        public void DisplayCustomerAndStaff()
        {
            List<Staff> staff = new List<Staff>();
            //step 1
            _Con = new SqlConnection(_ConStr);
            //step 2
            _Command = new SqlCommand("Select * from sales.staffs ; Select * from sales.Customers Where City='San Jose'", _Con);
            try
            {
                if (_Con.State == ConnectionState.Closed)
                {   //Step 3
                    _Con.Open();
                }
                //step 4 execute the command
                _DataReader = _Command.ExecuteReader();
                //step 5 -travserse through to read all the records
               
                    while (_DataReader.Read())
                    {
                        Console.WriteLine(_DataReader["staff_id"] + "," + _DataReader["first_name"] + ","
                            + _DataReader["last_name"] + "," + _DataReader["email"] + "\n");
                    }
                if (_DataReader.NextResult())
                {
                    while (_DataReader.Read())
                    {
                        Console.WriteLine(_DataReader["customer_id"] + "," + _DataReader["first_name"] + ","
                            + _DataReader["last_name"] + "," + _DataReader["phone"] + "\n");
                    }
                }
            
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Something went wrong: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.ToString());
            }
            finally
            {
                if (_Con.State == ConnectionState.Open)
                {
                    _Con.Close();
                }
            }
        }

        public void DisplayCustomerPhone(int custid)
        {
            List<Staff> staff = new List<Staff>();
            //step 1
            _Con = new SqlConnection(_ConStr);
            //step 2
            _Command = new SqlCommand("select phone from sales.customers where customer_id ="+ custid,_Con);
            try
            {
                if (_Con.State == ConnectionState.Closed)
                {   //Step 3
                    _Con.Open();
                }
                //step 4 execute the command
                string PhNum = _Command.ExecuteScalar().ToString();
                //step 5 -travserse through to read all the records
                Console.WriteLine($"Phone of Customer: {custid} is {PhNum}");
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Something went wrong: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.ToString());
            }
            finally
            {
                if (_Con.State == ConnectionState.Open)
                {
                    _Con.Close();
                }
            }
        }

        
        public int InsertCustomer()
        {
            _Con = new SqlConnection(_ConStr);
            Console.Write("Enter First Name: ");
            string firstname = Console.ReadLine();
            Console.Write("\nEnter Last name: ");
            string lastname = Console.ReadLine();
            Console.Write("\nEnter Email: ");
            string email = Console.ReadLine();
            Console.Write("\nEnter City: ");
            string city = Console.ReadLine();
            Console.Write("\nEnter 2 char State name: ");
            string state = Console.ReadLine().ToUpper();

            int i = 0;
            try
            {
                if (_Con.State == ConnectionState.Closed)
                {
                    _Con.Open();
                    string CmdStr = "Insert into " +
                        "Sales.Customers(first_name,last_name,email,city,state)" +
                        "Values(@Fname , @Lname, @Email, @City, @State)";
                    using (SqlCommand _Command = new SqlCommand(CmdStr, _Con))
                    {
                        _Command.CommandType = CommandType.Text;
                        _Command.Parameters.AddWithValue("@Fname", firstname);
                        _Command.Parameters.AddWithValue("@Lname", lastname);
                        _Command.Parameters.AddWithValue("@Email", email);
                        _Command.Parameters.AddWithValue("@City", city);
                        _Command.Parameters.AddWithValue("@State", state);

                        i = _Command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { _Con.Close(); }

            return i;
        }

        public int UpdateCustomerPhone()
        {
            _Con = new SqlConnection(_ConStr);
            Console.Write("Enter Phone number as (XXX) XXX-XXXX: ");
            string phone = Console.ReadLine();
            Console.Write("\nEnter Customer Id: ");
            string CustId = Console.ReadLine();
            int i = 0;
            try
            {
                if (_Con.State == ConnectionState.Closed)
                {
                    _Con.Open();
                    string CmdStr = "UpdateCustomerPhone";
                    using (SqlCommand _Command = new SqlCommand(CmdStr, _Con))
                    {
                        _Command.CommandType = CommandType.StoredProcedure;
                        _Command.Parameters.AddWithValue("@Phone", phone);
                        _Command.Parameters.AddWithValue("@CustId", CustId);

                        i = _Command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { _Con.Close(); }

            return i;
        }

        public int DeleteCustomerID()
        {
            _Con = new SqlConnection(_ConStr);
            Console.Write("Enter Customer ID to be deleted: ");
            string CustId = Console.ReadLine();

            int i = 0;
            try
            {
                if (_Con.State == ConnectionState.Closed)
                {
                    _Con.Open();
                    string CmdStr = "DELETE FROM sales.customers WHERE customer_id = @CustId";
                    using (SqlCommand _Command = new SqlCommand(CmdStr, _Con))
                    {
                        _Command.CommandType = CommandType.Text;
                        _Command.Parameters.AddWithValue("@CustId", CustId);

                        i = _Command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEX)
            {
                Console.WriteLine(sqlEX.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { _Con.Close(); }

            return i;
        }

        public List<Staff> GetStaff()
        {
            List<Staff> staffs = new List<Staff>();
            Staff staff = new Staff();
            //step 1
            _Con = new SqlConnection(_ConStr);
            //step 2
            _Command = new SqlCommand("Select * from sales.Staffs", _Con);
            try
            {
                if (_Con.State == ConnectionState.Closed)
                {   //Step 3
                    _Con.Open();
                }
                //step 4 execute the command
                _DataReader = _Command.ExecuteReader();
                //step 5 -travserse through to read all the records
                while (_DataReader.Read())
                {
                    //Console.WriteLine(_DataReader["staff_id"] + "," + _DataReader["first_name"] + ","
                    //    + _DataReader["last_name"] + "," + _DataReader["email"] + "\n");
                    staff.staff_id = Convert.ToInt32(_DataReader["Staff_id"]);
                    staff.first_name = _DataReader["first_Name"].ToString();
                    staff.last_name = _DataReader["last_name"].ToString();
                    staff.phone = _DataReader["phone"].ToString();
                    staffs.Add(staff);
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Something went wrong: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.ToString());
            }
            finally
            {
                if (_Con.State == ConnectionState.Open)
                {
                    _Con.Close();
                }
            }
            return staffs;
        }
    }
}
