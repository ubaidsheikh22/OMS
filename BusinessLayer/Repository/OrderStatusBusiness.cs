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
    public class OrderStatusBusiness
    {
        public IEnumerable<OrderStatus> GetOrdersStatus(string Customer, string SalesOrganization, string Division)
        {
            Connection con = new Connection();
            List<OrderStatus> OrdersStatusList = new List<OrderStatus>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_OrdersStatus", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer", Customer);
                cmd.Parameters.AddWithValue("@SalesOrganization", SalesOrganization);
                cmd.Parameters.AddWithValue("@Division", Division);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    OrderStatus PushedStatus = new OrderStatus();
                    PushedStatus.OrderRefrenceNumber = sdr["OrderRefrenceNumber"].ToString();
                    PushedStatus.Customer = sdr["Customer"].ToString();
                    PushedStatus.SalesOrganization = sdr["SalesOrganization"].ToString();
                    PushedStatus.division = sdr["Division"].ToString();
                    PushedStatus.FirmOrder = sdr["FirmOrder"].ToString();
                    PushedStatus.Calday = sdr["Calday"].ToString();
                  
                    PushedStatus.IsPushed = sdr["IsPushed"].ToString() == "True" ? "Pushed" : "Pending";



                    OrdersStatusList.Add(PushedStatus);
                }
            }
            return OrdersStatusList;
        }
    }
}
