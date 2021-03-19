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
  public  class DesginationBusiness
    {
        private Connection conn;
        private SqlCommand cmd;
        private string Message = string.Empty;

        public string addDesignation(DesignationModel d, string status)
        {
            //var tm = DateTime.Now.ToString();
            conn = new Connection();
            using (SqlConnection sqlcon = conn.GetDataBaseConnection())
            {
                cmd = new SqlCommand("SP_Designation_Insert_Update_Delete", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Designation_ID", d.Designation_ID);
                cmd.Parameters.AddWithValue("@DesigantionDesc", d.DesigantionDesc);
                cmd.Parameters.AddWithValue("@Position", d.Position);
                cmd.Parameters.AddWithValue("@User_ID", d.User_ID);
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Message = (string)cmd.Parameters["@Message"].Value;
            }
            return Message;
        }

        public IEnumerable<user> getAllUsers
        {
            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<user> userList = new List<user>();
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_User_dropdown", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        user ur = new user();
                        ur.User_ID = Convert.ToInt32(sdr["User_ID"]);
                        ur.UserFirstName = sdr["UserFirstName"].ToString();
                        userList.Add(ur);
                    }
                    sqlcon.Close();
                }
                return userList;
            }
        }


        public IEnumerable<DesignationModel> GetAllDesignationRecord
        {
            get
            {
                Connection con = new Connection();
                List<DesignationModel> DesginationList = new List<DesignationModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllDesignation", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        DesignationModel desig = new DesignationModel();
                        desig.Designation_ID = Convert.ToInt32(sdr["Designation_ID"]);
                        desig.DesigantionDesc = sdr["DesigantionDesc"].ToString();
                        DesginationList.Add(desig);
                    }
                }
                return DesginationList;
            }
        }


        public IEnumerable<DesignationModel> gridViewDesignation
        {

            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<DesignationModel> dd = new List<DesignationModel>();
                DateTime tm = DateTime.Now;
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllDesignation", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        DesignationModel d = new DesignationModel();
                        d.Designation_ID = Convert.ToInt32(sdr["Designation_ID"]);
                        d.DesigantionDesc = sdr["DesigantionDesc"].ToString();
                        d.User_ID = Convert.ToInt32(sdr["User_ID"]);
                        //opp.CreationDate = Convert.ToDateTime(sdr["CreationDate"]);
                        //opp.User_ID = Convert.ToInt32(sdr["User_ID"]);
                        //opp.Product_ID = Convert.ToInt32(sdr["Product_ID"]);
                        dd.Add(d);
                    }
                    sqlcon.Close();
                }
                return dd;
            }
        }

        public int DeleteUser(int id)
        {
            Connection con = new Connection();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteDesignation", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Designation_ID", id);
                cmd.ExecuteNonQuery();
                return 1;
            }
        }

    }
}
