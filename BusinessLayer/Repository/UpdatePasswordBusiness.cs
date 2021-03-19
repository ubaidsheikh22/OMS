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
  public class UpdatePasswordBusiness
    {
        private Connection conn;
        private SqlCommand cmd;
        private string Message = string.Empty;
        public string UpdatePass(UpdatePassword Upwrd)
        {
            //var tm = DateTime.Now.ToString();
            conn = new Connection();
            using (SqlConnection sqlcon = conn.GetDataBaseConnection())
            {
                cmd = new SqlCommand("SP_UpdatePassword", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
           
                cmd.Parameters.AddWithValue("@oldpass", Upwrd.Pass);
                cmd.Parameters.AddWithValue("@newpass", Upwrd.NewPass);
                cmd.Parameters.AddWithValue("@User_ID", Upwrd.User_ID);
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Message = (string)cmd.Parameters["@Message"].Value;
            }
            return Message;
        }
    }
}
