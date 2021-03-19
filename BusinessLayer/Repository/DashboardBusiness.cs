using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLayer.Repository
{
    public class DashboardBusiness
    {

        public IEnumerable<DashboardModel> GetAllDashboardRecords(string RegionCode)
        {
            Connection con = new Connection();
            List<DashboardModel> DashboardRecord = new List<DashboardModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetSugeestedOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer", RegionCode);
                //cmd.Parameters.AddWithValue("@AreaCode", AreaCode);
                //cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode);
                //cmd.Parameters.AddWithValue("@TownCode", TownCode);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DashboardModel dashboard = new DashboardModel();
                    dashboard.SuggestedOrder = sdr["SuggestedOrder"].ToString();
                    dashboard.TotalQuantity = sdr["SuggestedOrderValue"].ToString();
                    //dashboard.TotalQuantity = sdr["OrderTotalQuanity"].ToString();
                    //dashboard.TotalFirmOrder = sdr["FirmOrder"].ToString();

                    DashboardRecord.Add(dashboard);
                }
            }
            return DashboardRecord;

        }

        public IEnumerable<DashboardModel> GetAcceptedOrders(string RegionCode)
        {
            Connection con = new Connection();
            List<DashboardModel> DashboardRecord = new List<DashboardModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetAcceptedOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer", RegionCode);
                //cmd.Parameters.AddWithValue("@AreaCode", AreaCode);
                //cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode);
                //cmd.Parameters.AddWithValue("@TownCode", TownCode);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DashboardModel dashboard = new DashboardModel();
                    dashboard.TotalFirmOrder = sdr["FirmOrder"].ToString();
                    dashboard.FirOrderValue = sdr["FirOrderValue"].ToString();
                    //dashboard.TotalQuantity = sdr["OrderTotalQuanity"].ToString();
                    //dashboard.TotalFirmOrder = sdr["FirmOrder"].ToString();

                    DashboardRecord.Add(dashboard);
                }
            }
            return DashboardRecord;

        }
        public IEnumerable<DashboardModel> GetSpecialOrder(string RegionCode)
        {
            Connection con = new Connection();
            List<DashboardModel> DashboardRecord = new List<DashboardModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_GetSpecialOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer", RegionCode);
                //cmd.Parameters.AddWithValue("@AreaCode", AreaCode);
                //cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode);
                //cmd.Parameters.AddWithValue("@TownCode", TownCode);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DashboardModel dashboard = new DashboardModel();
                    dashboard.SpeacialQty = sdr["SpeacialQty"].ToString();
                    dashboard.SpeacialValue = sdr["SpeacialValue"].ToString();
                    //dashboard.TotalQuantity = sdr["OrderTotalQuanity"].ToString();
                    //dashboard.TotalFirmOrder = sdr["FirmOrder"].ToString();

                    DashboardRecord.Add(dashboard);
                }
            }
            return DashboardRecord;

        }
        public IEnumerable<DashboardModel> Allregiontotal(string RegionCode)
        {
            Connection con = new Connection();
            List<DashboardModel> DashboardRecord = new List<DashboardModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_DashboardRegionWiseOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer", RegionCode);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DashboardModel dashboard = new DashboardModel();
                    dashboard.RegionDescription = sdr["RegionDescription"].ToString();
                    dashboard.NoOfOrders = Convert.ToInt32(sdr["NoofOrders"]);
                    dashboard.OrderValues = Convert.ToInt64(sdr["OrderValue"]);
                    DashboardRecord.Add(dashboard);
                }
            }
            return DashboardRecord;

        }

        public IEnumerable<DashboardModel> AllSalesOrg(string RegionCode)
        {
            Connection con = new Connection();
            List<DashboardModel> DashboardRecord = new List<DashboardModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_DashboardDivisionWiseOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer", RegionCode);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DashboardModel dashboard = new DashboardModel();
                    dashboard.Division = sdr["Division"].ToString();
                    dashboard.NoOfOrders = Convert.ToInt32(sdr["NoofOrders"]);
                    dashboard.OrderValues = Convert.ToInt64(sdr["OrderValue"]);
                    DashboardRecord.Add(dashboard);
                }
            }
            return DashboardRecord;

        }

        public IEnumerable<DashboardModel> AllProductType(string RegionCode)
        {
            Connection con = new Connection();
            List<DashboardModel> DashboardRecord = new List<DashboardModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_DashboardSaleOrgWiseOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer", RegionCode);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DashboardModel dashboard = new DashboardModel();
                    dashboard.Salesorg = sdr["SalesOrganization"].ToString();
                    dashboard.NoOfOrders = Convert.ToInt32(sdr["NoofOrders"]);
                    dashboard.OrderValues = Convert.ToInt64(sdr["OrderValue"]);
                    DashboardRecord.Add(dashboard);
                }
            }
            return DashboardRecord;

        }

        public IEnumerable<DashboardModel> AllDashboardRecord(string RegionCode)
        {
            Connection con = new Connection();
            List<DashboardModel> DashboardRecord = new List<DashboardModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_AllDashboardRecordForCso", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Customer", RegionCode);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DashboardModel dashboard = new DashboardModel();
                    dashboard.SuggestedOrder = sdr["SugQTy"].ToString();
                    dashboard.suggestedValue = Convert.ToDouble(sdr["SugQtyValue"].ToString());
                    dashboard.TotalFirmOrder = sdr["FirmQty"].ToString();

                    dashboard.FirOrderValue = sdr["FirmQtyValue"].ToString();
                    dashboard.InTransactionQty = Convert.ToInt32(sdr["InTranQty"]);
                    dashboard.InTransactionQtyValue = Convert.ToInt32(sdr["InTransValue"]);

                    dashboard.PendingQty = Convert.ToDouble(sdr["PendQty"]);
                    dashboard.PendingQtyValue = Convert.ToInt32(sdr["PendValue"]);
                    dashboard.SpeacialQty = sdr["SpQty"].ToString();
                    dashboard.SpeacialValue = sdr["SpValue"].ToString();

                    //dashboard.RegionDescription = sdr["SugOrders"].ToString();
                    //dashboard.NoOfOrders = Convert.ToInt32(sdr["SpOrders"]);
                    //dashboard.OrderValues = Convert.ToInt32(sdr["FOrders"]);
                    //dashboard.OrderValues = Convert.ToInt32(sdr["POrders"]);
                    //dashboard.OrderValues = Convert.ToInt32(sdr["InTransOrders"]);
                    DashboardRecord.Add(dashboard);
                }
            }
            return DashboardRecord;

        }

        public IEnumerable<DashboardModel> AllDashboardRecordQTYOrder(string RegionCode)
        {
            Connection con = new Connection();
            List<DashboardModel> DashboardRecord = new List<DashboardModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_DashboardFOrCSO", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Customer", RegionCode);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DashboardModel dashboard = new DashboardModel();
                    dashboard.OrderDescription = sdr["OrderDetails"].ToString();
                    dashboard.SuggestedOrder = sdr["SugQTy"].ToString();
                    //dashboard.suggestedValue = Convert.ToDouble(sdr["SugQtyValue"].ToString());
                    dashboard.TotalFirmOrder = sdr["FirmQty"].ToString();

                    //dashboard.FirOrderValue = sdr["FirmQtyValue"].ToString();
                    dashboard.InTransactionQty = sdr["InTranQty"].ToString() == "" ? 0 : Convert.ToInt32(sdr["InTranQty"]);
                    //dashboard.InTransactionQtyValue = Convert.ToInt32(sdr["InTransValue"]);

                    dashboard.PendingQty = sdr["PendQty"].ToString() == "" ? 0 : Convert.ToDouble(sdr["PendQty"]);
                    //dashboard.PendingQtyValue = Convert.ToInt32(sdr["PendValue"]);
                    dashboard.SpeacialQty = sdr["SpQty"].ToString() == "" ? "0" : sdr["SpQty"].ToString();
                    //dashboard.SpeacialValue = sdr["SpValue"].ToString();

                    //dashboard.RegionDescription = sdr["SugOrders"].ToString();
                    //dashboard.NoOfOrders = Convert.ToInt32(sdr["SpOrders"]);
                    //dashboard.OrderValues = Convert.ToInt32(sdr["FOrders"]);
                    //dashboard.OrderValues = Convert.ToInt32(sdr["POrders"]);
                    //dashboard.OrderValues = Convert.ToInt32(sdr["InTransOrders"]);
                    DashboardRecord.Add(dashboard);
                }
            }
            return DashboardRecord;

        }



    }
}
