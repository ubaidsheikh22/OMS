using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class SaleOrderLogBusiness
    {

        public IEnumerable<SaleOrderLogModel> GetSaleOrderLogs(string Customer, string SalesOrganization, string Division, DateTime LogDate)
        {
            Connection con = new Connection();
            List<SaleOrderLogModel> LogList = new List<SaleOrderLogModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_SaleOrderLogs", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer", Customer);
                cmd.Parameters.AddWithValue("@SalesOrganization", SalesOrganization);
                cmd.Parameters.AddWithValue("@Division", Division);
                cmd.Parameters.AddWithValue("@Date", LogDate);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SaleOrderLogModel Log = new SaleOrderLogModel();
                    Log.OrderReferenceNumber = sdr["OrderReferenceNumber"].ToString();
                    Log.Customer = sdr["Customer"].ToString();
                    Log.SalesOrganization = sdr["SalesOrganization"].ToString();
                    Log.Division = sdr["Division"].ToString();
                    Log.Type = sdr["Type"].ToString();
                    Log.ID = sdr["ID"].ToString();
                    Log.Number = sdr["Number"].ToString();
                    Log.Message = sdr["Message"].ToString();
                    Log.Message_V1 = sdr["Message_V1"].ToString();
                    Log.Message_V2 = sdr["Message_V2"].ToString();
                    Log.Message_V3 = sdr["Message_V3"].ToString();
                    Log.Message_V4 = sdr["Message_V4"].ToString();
                    Log.Parameter = sdr["Parameter"].ToString();
                    Log.Row = sdr["Row"].ToString();
                    Log.System = sdr["System"].ToString();
                    Log.LoggedAt = sdr["LoggedAt"].ToString();

                    LogList.Add(Log);
                }
            }
            return LogList;
        }
    }
}
