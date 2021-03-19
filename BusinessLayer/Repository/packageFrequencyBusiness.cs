using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class packageFrequencyBusiness
    {
        private Connection conn;
        private SqlCommand cmd;
        private string Message = string.Empty;
        public string addPackageFrequency(DataTable dt)
        {
            //var tm = DateTime.Now.ToString();
            conn = new Connection();
            try
            {

                using (SqlConnection sqlcon = conn.GetDataBaseConnection())
                {
                    // Create a DataTable with the modified rows.  
                    //DataTable addedCategories = CategoriesDataTable.GetChanges(DataRowState.Added);

                    // Configure the SqlCommand and SqlParameter.  
                    SqlCommand insertCommand = new SqlCommand("SP_Day_Frequency_insert", sqlcon);
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter typeParam = insertCommand.Parameters.AddWithValue("@tbl_Day_Frequency", dt);


                    insertCommand.Parameters.Add("@message", SqlDbType.VarChar, 100);
                    insertCommand.Parameters["@message"].Direction = ParameterDirection.Output;
                    // Execute the command.  
                    insertCommand.ExecuteNonQuery();
                    Message = (string)insertCommand.Parameters["@message"].Value;

                }

                return Message;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public IEnumerable<PackageModel> getAllPackages
        {
            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<PackageModel> packageList = new List<PackageModel>();
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_package_dropdown", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        PackageModel PackageModel = new PackageModel();
                        PackageModel.Package_ID = Convert.ToInt32(sdr["Package_ID"]);
                        PackageModel.PackageName = sdr["PackageName"].ToString();
                        packageList.Add(PackageModel);
                    }
                    sqlcon.Close();
                }
                return packageList;
            }
        }

        public IEnumerable<packageFrequencyModel> gridViewPackageFrequency
        {

            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<packageFrequencyModel> pf = new List<packageFrequencyModel>();
                DateTime tm = DateTime.Now;
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllDaysFrequency", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        packageFrequencyModel pfm = new packageFrequencyModel();

                        //string[] values = pfm.Customer_Code.Split(',').Select(sValue => sValue.Trim()).ToArray();


                        pfm.Day_frequency_ID = Convert.ToInt32(sdr["Day_frequency_ID"]);
                        pfm.Customer_Code = sdr["Customer_Code"].ToString();
                        pfm.Name1 = sdr["Name1"].ToString();
                        //pfm.Package_ID = Convert.ToInt32(sdr["Package_ID"]);
                        pfm.PackageName = sdr["PackageName"].ToString();
                        pfm.Date = Convert.ToDateTime(sdr["Date"]);
                        pfm.Monday = sdr["Monday"].ToString();
                        pfm.Tuesday = sdr["Tuesday"].ToString();
                        pfm.Wednesday = sdr["Wednesday"].ToString();
                        pfm.Thursday = sdr["Thursday"].ToString();
                        pfm.Friday = sdr["Friday"].ToString();
                        pfm.Saturday = sdr["Saturday"].ToString();
                        pfm.Sunday = sdr["Sunday"].ToString();
                        pf.Add(pfm);



                    }
                    sqlcon.Close();
                }
                return pf;
            }
        }

        public IEnumerable<Login> getAllPackagesForCustomer(string customerCode)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<Login> packageList = new List<Login>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("GetPackageForCustomer", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer", customerCode);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Login Login = new Login();
                    //Login.AreaCode = sdr["AreaCode"].ToString();
                    Login.PackageName = sdr["packageName"].ToString();
                    packageList.Add(Login);
                }
                sqlcon.Close();
            }
            return packageList;

        }

        public IEnumerable<CustomerModel> getAllCustomer
        {
            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<CustomerModel> CustomerList = new List<CustomerModel>();
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("Get_AllCustomersForPackage", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        CustomerModel CustomerModel = new CustomerModel();
                        CustomerModel.Customer = Convert.ToInt32(sdr["Customer"]);
                        CustomerModel.Name1 = sdr["Name1"].ToString();
                        CustomerList.Add(CustomerModel);
                    }
                    sqlcon.Close();
                }
                return CustomerList;
            }
        }
    }
}