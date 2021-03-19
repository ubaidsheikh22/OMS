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
    public class SafetyStockBusiness
    {
        public IEnumerable<SafetyStockModel> GetAllCustomerSafetyStock
        {
            get
            {
                Connection con = new Connection();
                List<SafetyStockModel> Safelist = new List<SafetyStockModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_AllSafetyStock", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        SafetyStockModel safe = new SafetyStockModel();
                        safe.customer = sdr["customer"].ToString();
                        safe.material = sdr["material"].ToString();
                        safe.division = sdr["division"].ToString();
                        safe.salesOrg = sdr["salesOrg"].ToString();
                        safe.distr_chan = sdr["distr_chan"].ToString();
                        safe.region = sdr["region"].ToString();
                        safe.area = sdr["area"].ToString();
                        safe.territory = sdr["territory"].ToString();
                        safe.town = sdr["town"].ToString();
                        safe.quantity = sdr["quantity"].ToString();

                        Safelist.Add(safe);
                    }
                }
                return Safelist;
            }
        }


        private Connection conn;
        private SqlCommand cmd;
        private string Message = string.Empty;
        public string updateStock(SafetyStockModel r)
        {
            conn = new Connection();
            using (SqlConnection sqlcon = conn.GetDataBaseConnection())
            {
                cmd = new SqlCommand("SP_Stock_Update", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer", r.customer);
                cmd.Parameters.AddWithValue("@material", r.material);
                cmd.Parameters.AddWithValue("@salesOrg", r.salesOrg);
                cmd.Parameters.AddWithValue("@distr_chan", r.distr_chan);
                cmd.Parameters.AddWithValue("@quantity", r.quantity);

                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Message = (string)cmd.Parameters["@Message"].Value;
            }
            return Message;
        }


    }
}
