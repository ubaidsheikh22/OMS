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
   public class ClaimPortalBusiness
    {
        private Connection conn;
        private SqlCommand cmd;

        private string Message = string.Empty;
        public IEnumerable<WeekWiseOrder> GetDropDownClaimsOrderRef(string customerCode)
         {

            Connection con = new Connection();
            List<WeekWiseOrder> PendingOrderRef = new List<WeekWiseOrder>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("pendingorderRefrence", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerCode", customerCode);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    WeekWiseOrder WeekWiseOrderModel = new WeekWiseOrder();
                    WeekWiseOrderModel.refrence = sdr["Order_Ref"].ToString();
                    PendingOrderRef.Add(WeekWiseOrderModel);
                }
            }
            return PendingOrderRef;

        }
        public List<Billing> GetBillingNoForClaim(string CustomerCode, string SalesOrg)
        {
            conn = new Connection();
            List<Billing> lstBilling = new List<Billing>();
            using (SqlConnection sqlcon = conn.GetDataBaseConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetBillingNo_ForClaim", sqlcon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Customer", CustomerCode);
                da.SelectCommand.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    Billing bill = new Billing();
                    bill.BillingId = Convert.ToInt32(dr["BillingId"]);
                    bill.BillingNo = dr["BillingNo"].ToString();
                    lstBilling.Add(bill);
                }
                return lstBilling;
            }
        }
        public List<WeekWiseOrder> GetAllPendingOrder_ForClaim(string BillingId, string SalesOrg)
        {
            conn = new Connection();
            List<WeekWiseOrder> PendingOrderRef = new List<WeekWiseOrder>();
            using (SqlConnection sqlcon = conn.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllPendingOrder_ForClaim", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BillingId", BillingId);
                cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    WeekWiseOrder WeekWiseOrderModel = new WeekWiseOrder();
                    WeekWiseOrderModel.refrence = sdr["Order_Ref"].ToString();
                    WeekWiseOrderModel.Material = Convert.ToInt32(sdr["materialCode"]);
                    WeekWiseOrderModel.Description = sdr["materialDescription"].ToString();
                    WeekWiseOrderModel.unitPrice = sdr["unitPrice"].ToString() == "" ? 0 : Convert.ToDouble(sdr["UnitPrice"]);
                    WeekWiseOrderModel.orderQty = Convert.ToInt32(sdr["orderQuantity"]);
                    WeekWiseOrderModel.recievedQty = Convert.ToInt32(sdr["recievedQuantity"]);
                    WeekWiseOrderModel.damagedQty = Convert.ToInt32(sdr["Damaged"]);
                    WeekWiseOrderModel.expiredQty = Convert.ToInt32(sdr["Expired"]);
                    WeekWiseOrderModel.shortQty = Convert.ToInt32(sdr["Short"]);
                    WeekWiseOrderModel.TotalClaimed = Convert.ToInt32(sdr["TotalClaimed"]);
                    // WeekWiseOrderModel.comments = sdr["commentID"].ToString();
                    WeekWiseOrderModel.ClaimDay = sdr["day"].ToString();
                    WeekWiseOrderModel.BillingId = sdr["BillingId"].ToString();
                    WeekWiseOrderModel.ReceivingComments = sdr["ReceivingComments"].ToString();
                    PendingOrderRef.Add(WeekWiseOrderModel);
                }
            }
            return PendingOrderRef;

        }
        public IEnumerable<WeekWiseOrder> GetALLorderRefrenceRecord(string Refrecne)
        {

            Connection con = new Connection();
            List<WeekWiseOrder> PendingOrderRef = new List<WeekWiseOrder>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("pendingorderRefrenceAllRecord", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderRefrenceNum", Refrecne);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    WeekWiseOrder WeekWiseOrderModel = new WeekWiseOrder();
                    WeekWiseOrderModel.refrence = sdr["Order_Ref"].ToString();
                    WeekWiseOrderModel.Material = Convert.ToInt32(sdr["materialCode"]);
                    WeekWiseOrderModel.Description = sdr["materialDescription"].ToString();
                    WeekWiseOrderModel.unitPrice = sdr["unitPrice"].ToString() == "" ? 0 : Convert.ToDouble(sdr["UnitPrice"]);
                    WeekWiseOrderModel.orderQty = Convert.ToInt32(sdr["orderQuantity"]);
                    WeekWiseOrderModel.recievedQty = Convert.ToInt32(sdr["recievedQuantity"]);
                   // WeekWiseOrderModel.comments = sdr["commentID"].ToString();
                    WeekWiseOrderModel.ClaimDay = sdr["day"].ToString();

                    PendingOrderRef.Add(WeekWiseOrderModel);
                }
            }
            return PendingOrderRef;

        }

        public List<string> CreateClaims(List<pendingQuantities> claim, int customerCode)
        {
            //var tm = DateTime.Now.ToString();
            List<string> response = new List<string>();
            string Approve = "0";
            string reference = "";
            conn = new Connection();
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("materialCode");
                dt.Columns.Add("materialDescription");
                
                dt.Columns.Add("orderQuantity");
                dt.Columns.Add("recievedQuantity");
                dt.Columns.Add("unitPrice");
                dt.Columns.Add("ClaimComment");
                dt.Columns.Add("Order_Ref");

                foreach (var a in claim)
                {
                    dt.Rows.Add(a.materialCode,a.materialDescription,a.orderQuantity,a.recievedQuantity,a.unitPrice, a.ClaimComment,a.Order_Ref);
                    reference += a.Order_Ref;
                }
                pendingQuantities clm = new pendingQuantities();
                foreach (var item in claim)
                {
                    clm.Order_Ref = item.Order_Ref;
                    clm.Aproved = item.Aproved;
                    clm.day = item.day;
                    clm.ClaimComment = item.ClaimComment;
                    clm.BillingId = item.BillingId;
                }
                using (SqlConnection sqlcon = conn.GetDataBaseConnection())
                {
                    SqlCommand insertCommand = new SqlCommand("SP_Claim_Order_Insert", sqlcon);
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@Order_Ref_Claim", clm.Order_Ref);
                    insertCommand.Parameters.AddWithValue("@Customer",customerCode);
                    insertCommand.Parameters.AddWithValue("@Aproved", Approve);
                    insertCommand.Parameters.AddWithValue("@Comment", clm.ClaimComment);
                    insertCommand.Parameters.AddWithValue("@Day", clm.day);
                    insertCommand.Parameters.AddWithValue("@BillingId", clm.BillingId);
                    //SqlParameter typeParam = insertCommand.Parameters.AddWithValue("@tbl_SP_Order", sp);
                    //typeParam.SqlDbType = SqlDbType.Structured;
                    insertCommand.Parameters.AddWithValue("@tbl_Claim_Type", dt);
                    //typeParam.SqlDbType = SqlDbType.Structured;
                    insertCommand.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                    insertCommand.Parameters["@Message"].Direction = ParameterDirection.Output;
                    insertCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 100);
                    insertCommand.Parameters["@FirstName"].Direction = ParameterDirection.Output;
                    insertCommand.Parameters.Add("@Email", SqlDbType.VarChar, 200);
                    insertCommand.Parameters["@Email"].Direction = ParameterDirection.Output;
                    insertCommand.ExecuteNonQuery();
                    response.Add((string)insertCommand.Parameters["@Message"].Value);
                    response.Add((string)insertCommand.Parameters["@FirstName"].Value);
                    response.Add((string)insertCommand.Parameters["@Email"].Value);
                    response.Add(reference);
                    // Execute the command.  
                    //  Message = insertCommand.ExecuteNonQuery().ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }

        public IEnumerable<pendingQuantities> GetClaimsOrderRef(string customerCode, string SalesOrg, string Division)
        {

            Connection con = new Connection();
            List<pendingQuantities> PendingOrderRef = new List<pendingQuantities>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetClaimOrderRef", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerCode", customerCode);
                cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                cmd.Parameters.AddWithValue("@Division", Division);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    pendingQuantities claimModel = new pendingQuantities();
                    claimModel.BillingId = Convert.ToInt32(sdr["BillingId"]);
                    claimModel.BillingNo = sdr["BillingNo"].ToString();
                    PendingOrderRef.Add(claimModel);
                }
            return PendingOrderRef;

            }
        }

        public IEnumerable<pendingQuantities> GetAllClaimWithApproval(string Refrecne, string ClaimRefNum)
        {

            Connection con = new Connection();
            List<pendingQuantities> ClaimOrderRefRecord = new List<pendingQuantities>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_Claim_With_Aproval", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SP_Order_Claim_Ref", Refrecne);
                cmd.Parameters.AddWithValue("@ClaimRefNum", ClaimRefNum);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    pendingQuantities ClaimOrderModel = new pendingQuantities();
                    //WeekWiseOrderModel.refrence = sdr["Order_Ref"].ToString();
                    ClaimOrderModel.materialCode = sdr["materialcode"].ToString();
                    ClaimOrderModel.materialDescription = sdr["materialDescription"].ToString();
                    ClaimOrderModel.unitPrice = sdr["unitPrice"].ToString() == "" ? 0 : Convert.ToDecimal(sdr["UnitPrice"]);
                    ClaimOrderModel.ClaimValue = sdr["ClaimValue"].ToString() == "" ? 0 : Convert.ToDecimal(sdr["ClaimValue"]);
                    ClaimOrderModel.orderQuantity = Convert.ToInt32(sdr["orderQuantity"]);
                    ClaimOrderModel.recievedQuantity = Convert.ToInt32(sdr["recievedQuantity"]);
                    ClaimOrderModel.Damaged = Convert.ToInt32(sdr["Damaged"]);
                    ClaimOrderModel.Expired = Convert.ToInt32(sdr["Expired"]);
                    ClaimOrderModel.Short = Convert.ToInt32(sdr["Short"]);
                    ClaimOrderModel.TotalClaimed = Convert.ToInt32(sdr["TotalClaimed"]);
                    ClaimOrderModel.ClaimComment = sdr["comment"].ToString();
                    ClaimOrderModel.day = sdr["day"].ToString();
                    ClaimOrderModel.title = sdr["title"].ToString();
                    ClaimOrderModel.filepath = sdr["filepath"].ToString();
                    ClaimOrderModel.newApproved = int.Parse(sdr["Aproved"].ToString());
                    ClaimOrderModel.Status = sdr["Status"].ToString();
                    ClaimOrderRefRecord.Add(ClaimOrderModel);
                }
            }
            return ClaimOrderRefRecord;

        }


    }
}
