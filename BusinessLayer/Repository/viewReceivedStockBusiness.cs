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
   public class viewReceivedStockBusiness
    {
        public IEnumerable<CustomerModel> getAllCustomer(string areaCode, string regionCode, string townCode, string territoryCode)
        {


            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<CustomerModel> List = new List<CustomerModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("GetCustomerForAcceptedOrders", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AreaCode", areaCode);
                cmd.Parameters.AddWithValue("@regionCode", regionCode);
                cmd.Parameters.AddWithValue("@TownCode", townCode);
                cmd.Parameters.AddWithValue("@TerritoryCode", territoryCode);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel CustomerModel = new CustomerModel();
                    CustomerModel.Customer = Convert.ToInt32(sdr["Customer"]);
                    CustomerModel.Name1 = sdr["Name1"].ToString();
                    List.Add(CustomerModel);
                }
                sqlcon.Close();
            }
            return List;
        }
        public IEnumerable<customerOrderAcceptanceModel> Summary()
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<customerOrderAcceptanceModel> List = new List<customerOrderAcceptanceModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("SP_GetChangeOrderSummary", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    customerOrderAcceptanceModel CustomerModel = new customerOrderAcceptanceModel();
                    CustomerModel.CustomerName = sdr["CustomerName"].ToString();
                    CustomerModel.TotalPayable = Convert.ToDouble(sdr["TotalPayable"]);
                    CustomerModel.UnitPrice = Convert.ToInt32(sdr["UnitPrice"]);
                    CustomerModel.WeeklyQuantity = Convert.ToInt32(sdr["SuggestedQuantity"]);
                    CustomerModel.FirmOrder = Convert.ToInt32(sdr["FirmOrder"]);
                    CustomerModel.SpecialQuanity = sdr["specialQuanity"].ToString() == "" ? 0 : Convert.ToDouble(sdr["specialQuanity"]);
                    CustomerModel.WeeklyQuantityAmount = Convert.ToInt32(sdr["SuggestedQuantityAmount"]);
                    CustomerModel.FirmOrderAmount = Convert.ToInt32(sdr["FirmOrderAmount"]);
                    CustomerModel.SpecialQuanityAmount = sdr["specialQuanityAmount"].ToString() == "" ? 0 : Convert.ToDouble(sdr["specialQuanityAmount"]);
                    List.Add(CustomerModel);
                }
                sqlcon.Close();
            }
            return List;
        }

        public IEnumerable<WeekWiseOrder> getAllReceivedStock(int Customer, string UserID, string StartDate = null, string EndDate = null)
        {


            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<WeekWiseOrder> PendingOrderRef = new List<WeekWiseOrder>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_Received_Stock", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer", Customer);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read()) 
                {
                    WeekWiseOrder WeekWiseOrderModel = new WeekWiseOrder();
                    WeekWiseOrderModel.BillingNo = sdr["BillingNo"].ToString();
                    WeekWiseOrderModel.refrence = sdr["Order_Ref"].ToString();
                    WeekWiseOrderModel.Material = Convert.ToInt32(sdr["materialCode"]);
                    WeekWiseOrderModel.Description = sdr["materialDescription"].ToString();
                    //WeekWiseOrderModel.day = Convert.ToInt32(sdr["day"]);
                    //WeekWiseOrderModel.unitPrice = sdr["unitPrice"].ToString() == "" ? 0 : Convert.ToDouble(sdr["UnitPrice"]);
                    WeekWiseOrderModel.orderQty = Convert.ToInt32(sdr["orderQuantity"]);
                    WeekWiseOrderModel.recievedQty = Convert.ToInt32(sdr["recievedQuantity"]);
                    WeekWiseOrderModel.damagedQty = Convert.ToInt32(sdr["Damaged"]);
                    WeekWiseOrderModel.expiredQty = Convert.ToInt32(sdr["Expired"]);
                    WeekWiseOrderModel.shortQty = Convert.ToInt32(sdr["Short"]);
                    WeekWiseOrderModel.title = sdr["title"].ToString() == "" ? null : sdr["title"].ToString(); 
                    WeekWiseOrderModel.filepath = sdr["filepath"].ToString() == "" ? null : sdr["filepath"].ToString();
                    WeekWiseOrderModel.receivingdate = sdr["ReceivingDate"].ToString();
                    WeekWiseOrderModel.ReceivingComments = sdr["ReceivingComments"].ToString();
                    PendingOrderRef.Add(WeekWiseOrderModel);
                    
                }
            }

            return PendingOrderRef;
        }


        public IEnumerable<AuditingLogModel> Audit(string LogType = null, string LogScreen = null, string Logname = null, string StartDate = null, string EndDate = null)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<AuditingLogModel> List = new List<AuditingLogModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAuditSummary", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LogType", LogType);
                cmd.Parameters.AddWithValue("@LogScreen", LogScreen);
                cmd.Parameters.AddWithValue("@Logname", Logname);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    AuditingLogModel CustomerModel = new AuditingLogModel();
                    CustomerModel.LogId = Convert.ToInt32(sdr["LogId"]);
                    CustomerModel.LogType = sdr["LogType"].ToString();
                    CustomerModel.LogName = sdr["LogName"].ToString();
                    CustomerModel.LogScreen = sdr["LogScreen"].ToString();
                    CustomerModel.ActionPerformed = sdr["ActionPerformed"].ToString();
                    CustomerModel.CreatedByName = sdr["CreatedByName"].ToString();
                    CustomerModel.CreatedDateString = Convert.ToDateTime(sdr["CreatedDate"]).ToString("dd-MMM-yyyy");
                    CustomerModel.Misc = sdr["Misc"].ToString();
                    CustomerModel.IPAddress = sdr["IPAddress"].ToString();
                    List.Add(CustomerModel);
                }
                sqlcon.Close();
            }
            return List;
        }


        public List<AuditingLogDropModel> GetLogDropdown(int index)
        {
            List<AuditingLogDropModel> response = new List<AuditingLogDropModel>();
            try
            {

                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetLogDropdown", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Index", index);
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        AuditingLogDropModel Sub = new AuditingLogDropModel();
                        Sub.ID = sdr["title"].ToString();
                        Sub.Title = sdr["title"].ToString();
                        response.Add(Sub);
                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                return response;
            }
        }
    }
}