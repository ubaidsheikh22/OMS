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
    public class weeklyUpliftBusiness
    {
        private Connection conn;
        private SqlCommand cmd;

        private string Message = string.Empty;
        public IEnumerable<WeeklyUpliftsModel> GetAllMaterials(string customer)


        {
            Connection con = new Connection();
            List<WeeklyUpliftsModel> WeeklyUpliftsModelList = new List<WeeklyUpliftsModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("OrderMaterial", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer", customer);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    WeeklyUpliftsModel WeeklyUpliftsModel = new WeeklyUpliftsModel();
                    WeeklyUpliftsModel.Material = Convert.ToInt32(sdr["Material"]);
                    //WeeklyUpliftsModel.SalesOrganization = Convert.ToInt32(sdr["salesorganization"]);
                    //WeeklyUpliftsModel.Quantity = sdr["quantity"].ToString() == "" ? 0 : Convert.ToInt32(sdr["quantity"]);
                    WeeklyUpliftsModel.Description = sdr["Description"].ToString();
                    //materialMasterModel.Division = Convert.ToInt32(sdr["Division"]) == null ? 0 : Convert.ToInt32(sdr["Division"]);                        

                    WeeklyUpliftsModelList.Add(WeeklyUpliftsModel);
                }
            }
            return WeeklyUpliftsModelList;

        }

        public string AddWeeklyUpliftRecord(List<WeeklyUpliftsModel> dataToPost)
        {
            WeeklyUpliftsModel wom = new WeeklyUpliftsModel();

            foreach (var a in dataToPost)
            {
                wom.Material = a.Material;
                wom.SalesOrganization = a.SalesOrganization;
                //wom.DistributionChannel = a.DistributionChannel;
                wom.Percentage = a.Percentage;
                wom.Region = a.Region;
                wom.Customer = a.Customer;
                //wom.Region = a.Region;


                conn = new Connection();
                try
                {
                    //  DataTable dt = new DataTable();              
                    using (SqlConnection sqlcon = conn.GetDataBaseConnection())
                    {
                        cmd = new SqlCommand("UpdateOrderPercentage", sqlcon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        // cmd.Parameters.AddWithValue("@Customer", wom.Customer);
                        // cmd.Parameters.AddWithValue("@Region", wom.Region);
                        cmd.Parameters.AddWithValue("@Material", wom.Material);
                        cmd.Parameters.AddWithValue("@customer", wom.Customer);
                        cmd.Parameters.AddWithValue("@Region", wom.Region);
                        //cmd.Parameters.AddWithValue("@Salesorganization", wom.SalesOrganization);
                        cmd.Parameters.AddWithValue("@Percentage", wom.Percentage);
                        cmd.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();


                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            //var tm = DateTime.Now.ToString();


            Message = (string)cmd.Parameters["@Message"].Value;
            return Message;
        }

        public IEnumerable<CustomerModel> getAllPackages(int Region, string customer)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<CustomerModel> packageList = new List<CustomerModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("sp_CustomerRegionWise", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@region", Region);
                cmd.Parameters.AddWithValue("@customer", customer);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel PackageModel = new CustomerModel();
                    PackageModel.Customer = Convert.ToInt32(sdr["Customer"]);
                    PackageModel.Name1 = sdr["Name1"].ToString();
                    packageList.Add(PackageModel);
                }
                sqlcon.Close();
            }
            return packageList;

        }

    }
}