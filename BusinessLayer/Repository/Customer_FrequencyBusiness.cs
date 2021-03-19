using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
  public  class Customer_FrequencyBusiness
    {
        public IEnumerable<CustomerModel> GetAllCustomerRecords
        {
            get
            {
                Connection con = new Connection();
                List<CustomerModel> rolelist = new List<CustomerModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("Get_AllCustomers", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        CustomerModel customer = new CustomerModel();
                        customer.Customer =Convert.ToInt32( sdr["Customer"]);
                        customer.Name1 = sdr["Name1"].ToString();
                        customer.RegionCode = sdr["RegionCode"].ToString();
                        rolelist.Add(customer);
                    }
                }
                return rolelist;
            }
        }


        public IEnumerable<Customer_FrequencyModel> GetAllpackagesRecord
        {
            get
            {
                Connection con = new Connection();
                 List<Customer_FrequencyModel> CustomList = new List<Customer_FrequencyModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllPackagesRecord", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Customer_FrequencyModel cusmt = new Customer_FrequencyModel();
                        cusmt.Package_ID = Convert.ToInt32(sdr["Package_ID"]);
                        cusmt.PackageName = sdr["PackageName"].ToString();
                        CustomList.Add(cusmt);
                    }
                }
                return CustomList;
            }
        }


        public IEnumerable<PackageModel> GetAllpackagesFrequency
        {
            get
            {
                Connection con = new Connection();
                List<PackageModel> CustomList = new List<PackageModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllPackagesRecord", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        PackageModel cusmt = new PackageModel();
                        cusmt.Package_ID = Convert.ToInt32(sdr["Package_ID"]);
                        cusmt.PackageName = sdr["PackageName"].ToString();
                        CustomList.Add(cusmt);
                    }
                }
                return CustomList;
            }
        }


        private Connection conn;
        private SqlCommand cmd;
        private string Message = string.Empty;
        public string addallcustomerfree(DataTable dt)
        {
            conn = new Connection();
            using (SqlConnection sqlcon = conn.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_Day_Frequency_insert", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter tvparam = cmd.Parameters.AddWithValue("@tbl_Day_Frequency", dt);
                tvparam.SqlDbType = SqlDbType.Structured;
                cmd.ExecuteNonQuery();
            }
            return Message;
        }
    }
}
