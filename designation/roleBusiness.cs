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
    public class roleBusiness
    {
        private Connection conn;
        private SqlCommand cmd;
        private string Message = string.Empty;
        public string addRole(role r, string status)
        {
            conn = new Connection();
            using (SqlConnection sqlcon = conn.GetDataBaseConnection())
            {
                cmd = new SqlCommand("SP_Role_Insert_Update_Delete", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Role_ID", r.role_ID);
                cmd.Parameters.AddWithValue("@Roel_Desc", r.roleDesc);               
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Message = (string)cmd.Parameters["@Message"].Value;
            }
            return Message;
        }


        public IEnumerable<role> gridViewRole
        {

            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<role> rr = new List<role>();
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllRoles", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        role r = new role();
                        r.role_ID = Convert.ToInt32(sdr["Role_ID"]);
                        r.roleDesc = sdr["Rele_Desc"].ToString();
                        r.userID = Convert.ToInt32(sdr["User_ID"]);
                        rr.Add(r);
                    }
                    sqlcon.Close();
                }
                return rr;
            }
        }

    }
}
