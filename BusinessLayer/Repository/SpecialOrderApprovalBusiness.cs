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
    public class SpecialOrderApprovalBusiness
    {
        private Connection conn;
        private SqlCommand cmd;

        private string Message = string.Empty;
        public IEnumerable<Special_Orders_Approval> GetAllSpecialOrderRecords
        {
            get
            {
                Connection con = new Connection();
                List<Special_Orders_Approval> AllAprovalRecords = new List<Special_Orders_Approval>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("Get_AllSpecialOrdersApproval", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Special_Orders_Approval AllApprovalRecord = new Special_Orders_Approval();
                        AllAprovalRecords.Add(AllApprovalRecord);
                    }
                }
                return AllAprovalRecords;
            }
        }


        public IEnumerable<Special_Orders_Approval> GetAllSpecialOrderRecords2(string orderID)
        {
            Connection con = new Connection();
            List<Special_Orders_Approval> AllAprovalRecords = new List<Special_Orders_Approval>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_SpecialOrder_details", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SP_Order_ID", orderID);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Special_Orders_Approval AllForApprovalRecord = new Special_Orders_Approval();
                    AllForApprovalRecord.Material = Convert.ToInt32(sdr["Material"]);
                    AllForApprovalRecord.Description = sdr["Description"].ToString();
                    AllForApprovalRecord.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                    AllForApprovalRecord.Quantity = Convert.ToInt32(sdr["Quantity"]);
                    AllForApprovalRecord.Aproved = sdr["Aproved"].ToString();
                    AllForApprovalRecord.UnitPrice = Convert.ToInt32(sdr["UnitPrice"].ToString());
                    AllForApprovalRecord.Value = Convert.ToInt32(sdr["Value"].ToString());
                    AllForApprovalRecord.Status = sdr["Status"].ToString();
                    AllAprovalRecords.Add(AllForApprovalRecord);
                }
            }
            return AllAprovalRecords;

        }
        //,string Areacode,string Terriotorycode,string Towncode
        public IEnumerable<CustomerModel> getAllCustomerForSpecialOrder(string regionCode, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<CustomerModel> CustomerList = new List<CustomerModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_Specialorderscustomers", sqlcon);
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

        public IEnumerable<specialOrderModel> getAllRefrenceCode(string customerCode, string SalesOrganization = null, string Division = null, string StartDate = null, string EndDate = null)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<specialOrderModel> CustomerList = new List<specialOrderModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_SPORDERNUMBER", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerCode", customerCode);
                cmd.Parameters.AddWithValue("@SalesOrganization", SalesOrganization);
                cmd.Parameters.AddWithValue("@Division", Division);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    specialOrderModel CM = new specialOrderModel();
                    CM.SP_Order_ID = sdr["SP_Order_ID"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }

        public IEnumerable<specialOrderModel> getAllRefrenceCode_Approval(string customerCode, string UserID, string SalesOrg)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<specialOrderModel> CustomerList = new List<specialOrderModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_SPORDERNUMBER_Approved", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerCode", customerCode);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    specialOrderModel CM = new specialOrderModel();
                    CM.SP_Order_ID = sdr["SP_Order_ID"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }


        public string addSpecialOrderApproval(string RefrenceCode, int Approve, string UserID)
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
                    SqlCommand insertCommand = new SqlCommand("sp_ApprovalBYRoles", sqlcon);
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@SP_Order_ID", RefrenceCode);
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
                    SqlCommand cmd = new SqlCommand("GET_SPECIALORDER_EMAILS", con);
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
            catch(Exception ex)
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
