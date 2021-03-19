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
    public class DistributorFrequency
    {
        string Message = string.Empty;
        public IEnumerable<CustomerModel> GetAllCustomer(string AreaCode, string TerritoryCode, string TownCode, string RegionCode)
        {
            Connection con = new Connection();
            List<CustomerModel> CustomerList = new List<CustomerModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("GetCustomerForFrequency", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@User_ID", UserID);     
                cmd.Parameters.AddWithValue("@AreaCode", AreaCode);
                cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode);
                cmd.Parameters.AddWithValue("@TownCode", TownCode);
                cmd.Parameters.AddWithValue("@RegionCode", RegionCode);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel CustomerModel = new CustomerModel();
                    CustomerModel.Customer = Convert.ToInt32(sdr["Customer"]);
                    CustomerModel.Name1 = sdr["Name1"].ToString();
                    CustomerModel.Division = sdr["Division"].ToString();
                    CustomerModel.RegionDescription = sdr["RegionDescription"].ToString();
                    CustomerModel.SalesOrganization = sdr["SalesOrganization"].ToString();
                    CustomerList.Add(CustomerModel);
                }
            }
            return CustomerList;
        }


        public string addDistributorFrequency(DataTable dt)
        {
            //var tm = DateTime.Now.ToString();
            Connection conn = new Connection();


            using (SqlConnection sqlcon = conn.GetDataBaseConnection())
            {
                // Create a DataTable with the modified rows.  
                //DataTable addedCategories = CategoriesDataTable.GetChanges(DataRowState.Added);

                // Configure the SqlCommand and SqlParameter.  
                SqlCommand insertCommand = new SqlCommand("SP_Day_Frequency_insert", sqlcon);
                insertCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter typeParam = insertCommand.Parameters.AddWithValue("@tbl_Day_Frequency", dt);
                insertCommand.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                insertCommand.Parameters["@Message"].Direction = ParameterDirection.Output;
                typeParam.SqlDbType = SqlDbType.Structured;

                // Execute the command.  
                insertCommand.ExecuteNonQuery();
                Message = (string)insertCommand.Parameters["@Message"].Value;

            }

            return Message;
        }


    }
}
