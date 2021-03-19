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
    public class weeklyOrderBusiness
    {
        public IEnumerable<weeklyOrderModel> gridViewMonday
        {
            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<weeklyOrderModel> dd = new List<weeklyOrderModel>();
                DateTime tm = DateTime.Now;
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllDesignation", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        weeklyOrderModel w = new weeklyOrderModel();
                        {
                            w.materialCode = Convert.ToInt32(sdr["materialCode"]);
                            w.materialDescription = sdr["materialDescription"].ToString();
                            w.unitPrice = Convert.ToDouble(sdr["unitPrice"]);
                            w.totalWeeklyOrder = Convert.ToInt32(sdr["totalWeeklyOrder"]);
                            w.orderQuantity = Convert.ToInt32(sdr["orderQuantity"]);
                            w.firmOrder = Convert.ToInt32(sdr["firmOrder"]);
                            w.comment = sdr["comment"].ToString();
                            w.recievedQuantity = Convert.ToInt32(sdr["recievedQuantity"]);
                            w.datetime = Convert.ToDateTime(sdr["datetime"]);
                        }
                        dd.Add(w);
                    }
                    sqlcon.Close();
                }
                return dd;
            }
        }
        public IEnumerable<weeklyOrderModel> gridViewTuesday
        {
            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<weeklyOrderModel> dd = new List<weeklyOrderModel>();
                DateTime tm = DateTime.Now;
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllDesignation", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        weeklyOrderModel w = new weeklyOrderModel();
                        {
                            w.materialCode = Convert.ToInt32(sdr["materialCode"]);
                            w.materialDescription = sdr["materialDescription"].ToString();
                            w.unitPrice = Convert.ToDouble(sdr["unitPrice"]);
                            w.totalWeeklyOrder = Convert.ToInt32(sdr["totalWeeklyOrder"]);
                            w.orderQuantity = Convert.ToInt32(sdr["orderQuantity"]);
                            w.firmOrder = Convert.ToInt32(sdr["firmOrder"]);
                            w.comment = sdr["comment"].ToString();
                            w.recievedQuantity = Convert.ToInt32(sdr["recievedQuantity"]);
                            w.datetime = Convert.ToDateTime(sdr["datetime"]);
                        }
                        dd.Add(w);
                    }
                    sqlcon.Close();
                }
                return dd;
            }
        }
        public IEnumerable<weeklyOrderModel> gridViewWednesday
        {
            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<weeklyOrderModel> dd = new List<weeklyOrderModel>();
                DateTime tm = DateTime.Now;
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllDesignation", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        weeklyOrderModel w = new weeklyOrderModel();
                        {
                            w.materialCode = Convert.ToInt32(sdr["materialCode"]);
                            w.materialDescription = sdr["materialDescription"].ToString();
                            w.unitPrice = Convert.ToDouble(sdr["unitPrice"]);
                            w.totalWeeklyOrder = Convert.ToInt32(sdr["totalWeeklyOrder"]);
                            w.orderQuantity = Convert.ToInt32(sdr["orderQuantity"]);
                            w.firmOrder = Convert.ToInt32(sdr["firmOrder"]);
                            w.comment = sdr["comment"].ToString();
                            w.recievedQuantity = Convert.ToInt32(sdr["recievedQuantity"]);
                            w.datetime = Convert.ToDateTime(sdr["datetime"]);
                        }
                        dd.Add(w);
                    }
                    sqlcon.Close();
                }
                return dd;
            }
        }
        public IEnumerable<weeklyOrderModel> gridViewThursday
        {
        get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<weeklyOrderModel> dd = new List<weeklyOrderModel>();
                DateTime tm = DateTime.Now;
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllDesignation", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        weeklyOrderModel w = new weeklyOrderModel();
                        {
                            w.materialCode = Convert.ToInt32(sdr["materialCode"]);
                            w.materialDescription = sdr["materialDescription"].ToString();
                            w.unitPrice = Convert.ToDouble(sdr["unitPrice"]);
                            w.totalWeeklyOrder = Convert.ToInt32(sdr["totalWeeklyOrder"]);
                            w.orderQuantity = Convert.ToInt32(sdr["orderQuantity"]);
                            w.firmOrder = Convert.ToInt32(sdr["firmOrder"]);
                            w.comment = sdr["comment"].ToString();
                            w.recievedQuantity = Convert.ToInt32(sdr["recievedQuantity"]);
                            w.datetime = Convert.ToDateTime(sdr["datetime"]);
                        }
                        dd.Add(w);
                    }
                    sqlcon.Close();
                }
                return dd;
            }
        }
        public IEnumerable<weeklyOrderModel> gridViewFriday
        {
            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<weeklyOrderModel> dd = new List<weeklyOrderModel>();
                DateTime tm = DateTime.Now;
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllDesignation", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        weeklyOrderModel w = new weeklyOrderModel();
                        {
                            w.materialCode = Convert.ToInt32(sdr["materialCode"]);
                            w.materialDescription = sdr["materialDescription"].ToString();
                            w.unitPrice = Convert.ToDouble(sdr["unitPrice"]);
                            w.totalWeeklyOrder = Convert.ToInt32(sdr["totalWeeklyOrder"]);
                            w.orderQuantity = Convert.ToInt32(sdr["orderQuantity"]);
                            w.firmOrder = Convert.ToInt32(sdr["firmOrder"]);
                            w.comment = sdr["comment"].ToString();
                            w.recievedQuantity = Convert.ToInt32(sdr["recievedQuantity"]);
                            w.datetime = Convert.ToDateTime(sdr["datetime"]);
                        }
                        dd.Add(w);
                    }
                    sqlcon.Close();
                }
                return dd;
            }
        }
        public IEnumerable<weeklyOrderModel> gridViewSaturday
        {

            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<weeklyOrderModel> dd = new List<weeklyOrderModel>();
                DateTime tm = DateTime.Now;
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllDesignation", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        weeklyOrderModel w = new weeklyOrderModel();
                        {
                            w.materialCode = Convert.ToInt32(sdr["materialCode"]);
                            w.materialDescription = sdr["materialDescription"].ToString();
                            w.unitPrice = Convert.ToDouble(sdr["unitPrice"]);
                            w.totalWeeklyOrder = Convert.ToInt32(sdr["totalWeeklyOrder"]);
                            w.orderQuantity = Convert.ToInt32(sdr["orderQuantity"]);
                            w.firmOrder = Convert.ToInt32(sdr["firmOrder"]);
                            w.comment = sdr["comment"].ToString();
                            w.recievedQuantity = Convert.ToInt32(sdr["recievedQuantity"]);
                            w.datetime = Convert.ToDateTime(sdr["datetime"]);
                        }
                        dd.Add(w);
                    }
                    sqlcon.Close();
                }
                return dd;
            }
        }
        public IEnumerable<weeklyOrderModel> gridViewSunday
        {

            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<weeklyOrderModel> dd = new List<weeklyOrderModel>();
                DateTime tm = DateTime.Now;
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllDesignation", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        weeklyOrderModel w = new weeklyOrderModel();
                        {
                            w.materialCode = Convert.ToInt32(sdr["materialCode"]);
                            w.materialDescription = sdr["materialDescription"].ToString();
                            w.unitPrice = Convert.ToDouble(sdr["unitPrice"]);
                            w.totalWeeklyOrder = Convert.ToInt32(sdr["totalWeeklyOrder"]);
                            w.orderQuantity = Convert.ToInt32(sdr["orderQuantity"]);
                            w.firmOrder = Convert.ToInt32(sdr["firmOrder"]);
                            w.comment = sdr["comment"].ToString();
                            w.recievedQuantity = Convert.ToInt32(sdr["recievedQuantity"]);
                            w.datetime = Convert.ToDateTime(sdr["datetime"]);
                        }
                        dd.Add(w);
                    }
                    sqlcon.Close();
                }
                return dd;
            }
        }

    }
}