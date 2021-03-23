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
   public class ManualBusiness
    {
        private Connection con;
        private SqlCommand cmd;
        private string Messages = string.Empty;
        public string AddManualClaim(pendingQuantities DatatoPost, string Customer)
        {
            try
            {
                con = new Connection();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    cmd = new SqlCommand("SP_Claim_Manual_Insert", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Order_Ref_Claim", DatatoPost.Order_Ref);

               
                    cmd.Parameters.AddWithValue("@Customer", Customer);
                    cmd.Parameters.AddWithValue("@Aproved", DatatoPost.Aproved);
                    cmd.Parameters.AddWithValue("@Comment", DatatoPost.ClaimComment);
                    cmd.Parameters.AddWithValue("@materialCode", DatatoPost.materialCode);
                    cmd.Parameters.AddWithValue("@ManualClaimedQty", DatatoPost.ManualClaimedQty);
                    cmd.Parameters.AddWithValue("@ManualBatchNo", DatatoPost.ManualBatchNo);
                   
                    cmd.Parameters.AddWithValue("@salesOrganization", DatatoPost.salesOrganization);
                    cmd.Parameters.AddWithValue("@division", DatatoPost.division);
                    cmd.Parameters.AddWithValue("@unitPrice", DatatoPost.unitPrice);
                    cmd.Parameters.AddWithValue("@claimValue", DatatoPost.ClaimValue);
                   
                   
                    cmd.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    Messages = (string)cmd.Parameters["@Message"].Value;
                }
            }
            catch (Exception ex)
            {

                 throw;
            }
          
            return Messages;
        }

        public void AddManualClaimFile(string refno, string filesave, string fname, string day, int billingno)
        {
            try
            {
                Connection conn;
                conn = new Connection();
                
                using (SqlConnection sqlcon = conn.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_Manual_Claim_Insert_File", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@billingno", billingno);
                    cmd.Parameters.AddWithValue("@refno", refno == null || refno == "null" ? "" : refno);
                    cmd.Parameters.AddWithValue("@title", filesave == null || filesave == "null" ? "null" : filesave);
                    cmd.Parameters.AddWithValue("@path", fname == null || fname == "null" ? "null" : fname);
                    cmd.Parameters.AddWithValue("@day", day == null || day == "null" ? "null" : day);
                  
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }







        public IEnumerable<pendingQuantities> GetAllManualClaims (string customerCode)
        {
                Connection con = new Connection();
                List<pendingQuantities> ManualClaimList = new List<pendingQuantities>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("ManualClaimList", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerCode", customerCode);
                SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        pendingQuantities ClaimList = new pendingQuantities();
                        ClaimList.Order_Ref = sdr["Order_Ref_Claim"].ToString();
                        ClaimList.materialCode = sdr["materialCode"].ToString();
                        ClaimList.salesOrganization = sdr["SalesOrganization"].ToString();
                        ClaimList.division = sdr["division"].ToString();
                        ClaimList.day = sdr["day"].ToString();
                        ClaimList.orderQuantity =Convert.ToInt32(sdr["orderQuantity"].ToString());
                        ClaimList.recievedQuantity = Convert.ToInt32(sdr["recievedQuantity"]);
                        ClaimList.Damaged = Convert.ToInt32(sdr["damaged"]);
                        ClaimList.Expired = Convert.ToInt32(sdr["expired"]);
                        ClaimList.Short = Convert.ToInt32(sdr["short"]);
                    ClaimList.ClaimComment =sdr["comment"].ToString();
                    ManualClaimList.Add(ClaimList);
                    }
                }
                return ManualClaimList;
            
        }


    }
}
