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
   public class ClaimApprovalBusiness
    {
        private Connection conn;
        private SqlCommand cmd;

        private string Message = string.Empty;
        public IEnumerable<CustomerModel> getAllCustomerForClaim(string regionCode, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<CustomerModel> CustomerList = new List<CustomerModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllClaimCustomer", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                //cmd.Parameters.AddWithValue("@AreaCode", Areacode);
                //cmd.Parameters.AddWithValue("@TerriotoryCode", Terriotorycode);
                //cmd.Parameters.AddWithValue("@TownCode", Towncode);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel CM = new CustomerModel();
                    CM.Customer = Convert.ToInt32(sdr["Customer"]);
                    CM.Name1 = sdr["Name1"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }

        public IEnumerable<WeekWiseOrder> getAllRefrenceCode(string customerCode, string UserID, string SalesOrg)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<WeekWiseOrder> CustomerList = new List<WeekWiseOrder>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_ClaimOrderRefNumber", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerCode", customerCode);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    WeekWiseOrder CM = new WeekWiseOrder();
                    CM.BillingId = sdr["BillingId"].ToString();
                    CM.BillingNo = sdr["BillingNo"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }

        public IEnumerable<WeekWiseOrder> GetALLClaimReRecord(string Refrecne, string ClaimRef)
        {

            Connection con = new Connection();
            List<WeekWiseOrder> PendingOrderRef = new List<WeekWiseOrder>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_Claim_details", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Order_Ref_Claim", Refrecne);
                cmd.Parameters.AddWithValue("@ClaimRef", ClaimRef);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    WeekWiseOrder WeekWiseOrderModel = new WeekWiseOrder();
                    WeekWiseOrderModel.Material = Convert.ToInt32(sdr["Material"]);
                    WeekWiseOrderModel.Description = sdr["Description"].ToString();
                    WeekWiseOrderModel.unitPrice = sdr["unitPrice"].ToString() == "" ? 0 : Convert.ToDouble(sdr["UnitPrice"]);
                    WeekWiseOrderModel.orderQty = Convert.ToInt32(sdr["orderQuantity"]);
                    WeekWiseOrderModel.recievedQty = Convert.ToInt32(sdr["recievedQuantity"]);
                    WeekWiseOrderModel.damagedQty = Convert.ToInt32(sdr["Damaged"]);
                    WeekWiseOrderModel.expiredQty = Convert.ToInt32(sdr["Expired"]);
                    WeekWiseOrderModel.shortQty = Convert.ToInt32(sdr["Short"]);
                    WeekWiseOrderModel.TotalClaimed = Convert.ToInt32(sdr["TotalClaim"]);
                    WeekWiseOrderModel.comments = sdr["comment"].ToString();
                    WeekWiseOrderModel.ClaimValue = sdr["ClaimValue"].ToString() == "" ? 0 : Convert.ToDouble(sdr["ClaimValue"]);
                    WeekWiseOrderModel.title = sdr["title"].ToString();
                    WeekWiseOrderModel.filepath = sdr["filepath"].ToString();
                    WeekWiseOrderModel.ClaimDay = sdr["day"].ToString();
                    WeekWiseOrderModel.approved = int.Parse(sdr["Aproved"].ToString());
                    WeekWiseOrderModel.Status = sdr["Status"].ToString();
                    PendingOrderRef.Add(WeekWiseOrderModel);
                }
            }
            return PendingOrderRef;

        }

        public string AddClaimAprovalRefrence(string RefrenceCode, int Approve, string refrenceToMCL, string UserID)
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
                    SqlCommand insertCommand = new SqlCommand("sp_ClaimApproval", sqlcon);
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@Order_Ref_Claim", RefrenceCode);
                    insertCommand.Parameters.AddWithValue("@refrenceToMCL", refrenceToMCL);
                    insertCommand.Parameters.AddWithValue("@ApprovedBy", Approve);
                    insertCommand.Parameters.AddWithValue("@UserID", UserID);
                    insertCommand.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                    insertCommand.Parameters["@Message"].Direction = ParameterDirection.Output;
                    insertCommand.ExecuteNonQuery();
                    Message = (string)insertCommand.Parameters["@Message"].Value;
                    //Message = insertCommand.ExecuteNonQuery().ToString();

                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return Message;
        }

        public string GetWorkFlowEmails(string OrderReference, string ApprovalStatus, string CustomerCode)
        {
            try
            {
                conn = new Connection();

                using (SqlConnection con = conn.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("GET_Claim_EMAILS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderReference", OrderReference);
                    cmd.Parameters.AddWithValue("@APPROVALSTATUS", ApprovalStatus);
                    cmd.Parameters.AddWithValue("@CustomerCode", CustomerCode);

                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);

                    if (dt.Rows.Count > 0)
                        Message = dt.Rows[0][0].ToString();
                    if (dt.Rows.Count > 1)
                        Message = Message + dt.Rows[1][0].ToString();
                    if(dt.Rows.Count > 2)
                        Message = Message + dt.Rows[2][0].ToString();
                    if (dt.Rows.Count > 3)
                        Message = Message + dt.Rows[3][0].ToString();

                    if (string.IsNullOrEmpty(Message))
                        return null;

                    return Message;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetDownwardFlowEmails(string OrderReference, string ApprovalStatus, string CustomerCode)
        {
            try
            {
                conn = new Connection();

                using (SqlConnection con = conn.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("GET_REJECTIONSPECIALORDER_EMAILS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderReference", OrderReference);
                    cmd.Parameters.AddWithValue("@APPROVALSTATUS", ApprovalStatus);
                    cmd.Parameters.AddWithValue("@CustomerCode", CustomerCode);

                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);

                    if (dt.Rows.Count > 0)
                        Message = dt.Rows[0][0].ToString();
                    if (dt.Rows.Count > 1)
                        Message = Message + dt.Rows[1][0].ToString();
                    if (dt.Rows.Count > 2)
                        Message = Message + dt.Rows[2][0].ToString();
                    if (dt.Rows.Count > 3)
                        Message = Message + dt.Rows[3][0].ToString();

                    if (string.IsNullOrEmpty(Message))
                        return null;

                    return Message;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}
