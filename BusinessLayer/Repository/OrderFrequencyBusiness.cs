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
  public  class OrderFrequencyBusiness
    {
        
        private SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter ad;
        //public IEnumerable<CustomerModel> GetAllCustomerRecords
        //{
        //    get
        //    {
        //        Connection con = new Connection();
        //        List<CustomerModel> rolelist = new List<CustomerModel>();
        //        using (SqlConnection sqlcon = con.GetDataBaseConnection())
        //        {
        //            SqlCommand cmd = new SqlCommand("SP_GetAllCustomers", sqlcon);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            SqlDataReader sdr = cmd.ExecuteReader();
        //            while (sdr.Read())
        //            {
        //                CustomerModel customer = new CustomerModel();
        //                customer.Customer_Code = Convert.ToInt32(sdr["Customer_Code"]);
        //                customer.Customer_Name = sdr["Customer_Name"].ToString();
        //                customer.Customer_PostalAddress = sdr["Customer_PostalAddress"].ToString();
        //                customer.Region = sdr["Region"].ToString();
        //                customer.City = sdr["City"].ToString();
        //                customer.Customer_category = sdr["Customer_category"].ToString();
        //                customer.Contact_PersonCell = sdr["Contact_PersonCell"].ToString();
        //                rolelist.Add(customer);
        //            }
        //        }
        //        return rolelist;
        //    }
        //}

        //private string Message = string.Empty;
        Connection con = new Connection();
        List<CustomerModel> rolelist = new List<CustomerModel>();
        public DataTable MaterialInsertUpdate(DataTable rolelist)
        {
            con = new Connection();
            dt = new DataTable();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {

                SqlCommand cmd = new SqlCommand("SP_Day_Frequency_insert", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter tvparam = cmd.Parameters.AddWithValue("@tbl_Day_Frequency", rolelist);
                tvparam.SqlDbType = SqlDbType.Structured;
                cmd.ExecuteNonQuery();

                //ad = new SqlDataAdapter("SP_Day_Frequency_insert", sqlcon);
                //ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                //ad.SelectCommand.Parameters.AddWithValue("@tbl_Day_Frequency", rolelist);
                //ad.Fill(dt);
            };
            return dt;
        }
    }
}
