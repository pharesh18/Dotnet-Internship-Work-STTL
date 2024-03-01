using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWindowForm.DataClass
{
    public class Employee
    {
        public int EMP_ID { get; set; }
        public string EMP_NAME { get; set; }
        public string EMP_EMAIL { get; set; }
        public long EMP_PHONE { get; set; }
        public string EMP_DEPT { get; set; }
        public string EMP_INTEREST { get; set; }
        public string EMP_GENDER { get; set; }
        public DateTime EMP_DOB { get; set; }
        public double EMP_SALARY { get; set; }
        public string EMP_STATE { get; set; }
        public string EMP_CITY { get; set; }
        public string EMP_ADDRESS { get; set; }

        public static string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        public static DataTable loadData()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(conStr))
                {

                    string query = "SELECT EMP_ID, EMP_NAME, EMP_EMAIL, EMP_PHONE, EMP_DEPT, EMP_INTEREST, EMP_GENDER, EMP_DOB, EMP_SALARY, EMP_STATE, EMP_CITY, EMP_ADDRESS FROM Employee";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dataTable;
        }

        public static bool insertEmployee(Employee emp)
        {
            try
            {
                string query = "INSERT INTO Employee(EMP_NAME, EMP_EMAIL, EMP_PHONE, EMP_DEPT, EMP_INTEREST, EMP_GENDER, EMP_DOB, EMP_SALARY, EMP_STATE, EMP_CITY, EMP_ADDRESS) VALUES(@EMP_NAME, @EMP_EMAIL, @EMP_PHONE, @EMP_DEPT, @EMP_INTEREST, @EMP_GENDER, @EMP_DOB, @EMP_SALARY, @EMP_STATE, @EMP_CITY, @EMP_ADDRESS)";
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@EMP_NAME", emp.EMP_NAME);
                        cmd.Parameters.AddWithValue("@EMP_EMAIL", emp.EMP_EMAIL);
                        cmd.Parameters.AddWithValue("@EMP_PHONE", emp.EMP_PHONE);
                        cmd.Parameters.AddWithValue("@EMP_DEPT", emp.EMP_DEPT);
                        cmd.Parameters.AddWithValue("@EMP_INTEREST", emp.EMP_INTEREST);
                        cmd.Parameters.AddWithValue("@EMP_GENDER", emp.EMP_GENDER);
                        cmd.Parameters.AddWithValue("@EMP_DOB", emp.EMP_DOB);
                        cmd.Parameters.AddWithValue("@EMP_SALARY", emp.EMP_SALARY);
                        cmd.Parameters.AddWithValue("@EMP_STATE", emp.EMP_STATE);
                        cmd.Parameters.AddWithValue("@EMP_CITY", emp.EMP_CITY);
                        cmd.Parameters.AddWithValue("@EMP_ADDRESS", emp.EMP_ADDRESS);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
                return false;
            }
        }

        public static void deleteData(Employee emp)
        {
            try
            {
                string query = "DELETE FROM Employee WHERE EMP_ID=@EMP_ID";

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@EMP_ID", emp.EMP_ID);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Record Deleted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        public static bool updateEmployee(Employee emp)
        {
            try
            {
                string query = "UPDATE Employee SET EMP_NAME=@EMP_NAME, EMP_EMAIL=@EMP_EMAIL, EMP_PHONE=@EMP_PHONE, EMP_DEPT=@EMP_DEPT, EMP_INTEREST=@EMP_INTEREST, EMP_GENDER=@EMP_GENDER, EMP_DOB=@EMP_DOB, EMP_SALARY=@EMP_SALARY, EMP_STATE=@EMP_STATE, EMP_CITY=@EMP_CITY, EMP_ADDRESS=@EMP_ADDRESS WHERE EMP_ID=@EMP_ID";
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@EMP_ID", emp.EMP_ID);
                        cmd.Parameters.AddWithValue("@EMP_NAME", emp.EMP_NAME);
                        cmd.Parameters.AddWithValue("@EMP_EMAIL", emp.EMP_EMAIL);
                        cmd.Parameters.AddWithValue("@EMP_PHONE", emp.EMP_PHONE);
                        cmd.Parameters.AddWithValue("@EMP_DEPT", emp.EMP_DEPT);
                        cmd.Parameters.AddWithValue("@EMP_INTEREST", emp.EMP_INTEREST);
                        cmd.Parameters.AddWithValue("@EMP_GENDER", emp.EMP_GENDER);
                        cmd.Parameters.AddWithValue("@EMP_DOB", emp.EMP_DOB);
                        cmd.Parameters.AddWithValue("@EMP_SALARY", emp.EMP_SALARY);
                        cmd.Parameters.AddWithValue("@EMP_STATE", emp.EMP_STATE);
                        cmd.Parameters.AddWithValue("@EMP_CITY", emp.EMP_CITY);
                        cmd.Parameters.AddWithValue("@EMP_ADDRESS", emp.EMP_ADDRESS);

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
                return false;
            }
        }
    }
}
