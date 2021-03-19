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
    public class weekWiseBusiness
    {
        string Message = string.Empty;
        public IEnumerable<WeekWiseOrder> getRecordToGrid(string Day, string customerCode, string BillingNo)
        {

            Connection con = new Connection();
            List<WeekWiseOrder> WeekWiselist = new List<WeekWiseOrder>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_DayWiseAccptedOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dayName", Day);
                cmd.Parameters.AddWithValue("@CustomerCode", customerCode);
                cmd.Parameters.AddWithValue("@BillingId", BillingNo);

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    WeekWiseOrder WeekWiseOrderModel = new WeekWiseOrder();
                    //WeekWiseOrderModel.refrence = sdr["OrderRefrenceNumber"].ToString();
                    WeekWiseOrderModel.Material = Convert.ToInt32(sdr["Material"]);
                    WeekWiseOrderModel.Description = sdr["Description"].ToString();
                    WeekWiseOrderModel.unitPrice = sdr["UnitPrice"].ToString() == "" ? 0 : Convert.ToDouble(sdr["UnitPrice"]);
                    WeekWiseOrderModel.refrence = sdr["OrderReferenceNumber"].ToString();
                    WeekWiseOrderModel.day = Convert.ToInt32(sdr[Day]);
                    WeekWiselist.Add(WeekWiseOrderModel);
                }
            }
            return WeekWiselist;

        }
        public List<Billing> GetBillingNo(string CustomerCode,string SapDayOrderNo)
        {
            Connection con = new Connection();
            List<Billing> lstBilling = new List<Billing>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_GetBillingNo", sqlcon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Customer", CustomerCode);
                da.SelectCommand.Parameters.AddWithValue("@SapDayOrderNo", SapDayOrderNo);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    Billing bill = new Billing();
                    bill.BillingId = Convert.ToInt32(dr["BillingId"]);
                    bill.SapOrderNo = dr["SapOrderNo"].ToString();
                    bill.CALDAY = dr["CALDAY"].ToString();
                    bill.BillingNo = dr["BillingNo"].ToString();
                    lstBilling.Add(bill);
                }
            }
                return lstBilling;
        }
        public IEnumerable<claimCommentsModel> GetDropDownClaimsComments
        {
            get
            {
                Connection con = new Connection();
                List<claimCommentsModel> claimCommentsModelList = new List<claimCommentsModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("Get_AllClaimComments", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        claimCommentsModel claimCommentsModel = new claimCommentsModel();
                        claimCommentsModel.commentID = Convert.ToInt32(sdr["commentID"]);
                        claimCommentsModel.comment = sdr["comment"].ToString();

                        claimCommentsModelList.Add(claimCommentsModel);
                    }
                }
                return claimCommentsModelList;
            }
        }


        public string AddPendingOrderRecord(List<pendingQuantities> dataToPost, string CustomerCode)
        {
            pendingQuantities pendingQuantities = new pendingQuantities();
            DataTable dtEmail = new DataTable();
            dtEmail.Columns.Add("Invoice Number");
            dtEmail.Columns.Add("Product Code");
            dtEmail.Columns.Add("Sent Quantity");
            dtEmail.Columns.Add("Recieved Quantity");
            dtEmail.Columns.Add("Damaged");
            dtEmail.Columns.Add("Shortage");
            dtEmail.Columns.Add("Expired");
            dtEmail.Columns.Add("Distributor ID");
            dtEmail.Columns.Add("EPOD Document Date");
            dtEmail.Columns.Add("Comments");


            DataTable dt = new DataTable();
            dt.Columns.Add("materialCode");
            dt.Columns.Add("materialDescription");
            dt.Columns.Add("unitPrice");
            dt.Columns.Add("orderQuantity");
            dt.Columns.Add("recievedQuantity");
            //dt.Columns.Add("commentID");
            dt.Columns.Add("day");
            dt.Columns.Add("Refrence");
            dt.Columns.Add("CustomerCode");

            dt.Columns.Add("Damaged");
            dt.Columns.Add("Expired");
            dt.Columns.Add("Short");
            dt.Columns.Add("Execss");
            dt.Columns.Add("wrong_SKU");
            dt.Columns.Add("BillingId");
            dt.Columns.Add("ReceivingComments");
            foreach (var a in dataToPost)
            {
                dt.Rows.Add(a.materialCode, a.materialDescription, a.unitPrice, a.orderQuantity, a.recievedQuantity, a.day, a.Order_Ref, CustomerCode,a.Damaged,a.Expired,a.Short,a.Execss,a.wrong_SKU,a.BillingId, a.ReceivingComments);
                dtEmail.Rows.Add(a.BillingNo, a.materialCode, a.orderQuantity, a.recievedQuantity, a.Damaged, a.Short, a.Expired, CustomerCode,DateTime.Now,a.ReceivingComments);
            }
          
            Connection conn = new Connection();
            using (SqlConnection sqlcon = conn.GetDataBaseConnection())
            {
                // Create a DataTable with the modified rows.  
                //DataTable addedCategories = CategoriesDataTable.GetChanges(DataRowState.Added);

                // Configure the SqlCommand and SqlParameter.  
                SqlCommand insertCommand = new SqlCommand("SP_Pending_Order_Insert", sqlcon);
                insertCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter typeParam = insertCommand.Parameters.AddWithValue("@tbl_PendingOrder_Type", dt);
                insertCommand.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                insertCommand.Parameters["@Message"].Direction = ParameterDirection.Output;
                typeParam.SqlDbType = SqlDbType.Structured;

                // Execute the command.  
                insertCommand.ExecuteNonQuery();
                Message = (string)insertCommand.Parameters["@Message"].Value;
                if(Message == "1")
                {
                    emailSender email = new emailSender();
                    email.emailPOD(dtEmail);
                }
            }
            
            return Message;
        }

        public void AddPendingOrderRecordFile(string refno, string filesave, string fname, string day, int billingID)
        {
            try
            {
                Connection conn;
                conn = new Connection();
                using (SqlConnection sqlcon = conn.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_Pending_Order_Insert_File", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@refno", refno == null || refno == "null" ? "" : refno);
                    cmd.Parameters.AddWithValue("@title", filesave == null || filesave == "null" ? "null" : filesave);
                    cmd.Parameters.AddWithValue("@path", fname == null || fname == "null" ? "null" : fname);
                    cmd.Parameters.AddWithValue("@day", day == null || day == "null" ? "null" : day);
                    cmd.Parameters.AddWithValue("@billingID", billingID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}