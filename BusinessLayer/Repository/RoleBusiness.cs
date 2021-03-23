using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer.Repository
{
    public class RoleBusiness
    {
        public IEnumerable<RoleModel> GetAllRoles
        {
            get
            {
                Connection con = new Connection();
                List<RoleModel> rolelist = new List<RoleModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllRoles", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        RoleModel role = new RoleModel();
                        role.Role_ID = Convert.ToInt32(sdr["Role_ID"]);
                        role.Rele_Desc = sdr["Rele_Desc"].ToString();
                        role.UserName = sdr["UserName"].ToString();
                        rolelist.Add(role);
                    }
                }
                return rolelist;
            }
        }

        private Connection conn;
        private SqlCommand cmd;
        private string Message = string.Empty;
        public string addRole(RoleModel r, string status)
        {
            conn = new Connection();
            using (SqlConnection sqlcon = conn.GetDataBaseConnection())
            {
                cmd = new SqlCommand("SP_Role_Insert_Update_Delete", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Role_ID", r.Role_ID);
                cmd.Parameters.AddWithValue("@Rele_Desc", r.Rele_Desc);
                cmd.Parameters.AddWithValue("@User_ID", r.User_ID);
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Message = (string)cmd.Parameters["@Message"].Value;
            }
            return Message;
        }



        public IEnumerable<DistributorModel> GetAllDistributotRecords
        {
            get
            {
                Connection con = new Connection();
                List<DistributorModel> Distributorlist = new List<DistributorModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllDistribution", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        DistributorModel distri = new DistributorModel();
                        distri.Distributor_ID = Convert.ToInt32(sdr["Customer"]);
                        distri.Distributor_Name = sdr["Name1"].ToString();
                        //distri.Role_ID = Convert.ToInt32(sdr["Role_ID"]);
                        Distributorlist.Add(distri);
                    }
                }
                return Distributorlist;
            }
        }

        public int CreateUpdateSubstitute(SubstituteModel model)
        {
            try
            {

                int response = 0;
                Connection con = new Connection();
                SubstituteModel Substitue = new SubstituteModel();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_Tbl_Substitute", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AssignedTo", model.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedFrom", model.AssignedFrom);
                    cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
                    cmd.Parameters.AddWithValue("@Reason", model.Reason);
                    cmd.Parameters.AddWithValue("@StartDate", model.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", model.EndDate);
                    cmd.Parameters.AddWithValue("@index", model.Index);
                    cmd.Parameters.Add("@Message", SqlDbType.Int);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    response = Convert.ToInt32(cmd.Parameters["@Message"].Value);

                    return response;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int SetSubstitute_ForceStop(int id)
        {
            try
            {
                Connection con = new Connection();
                List<SubstituteModel> Substitutelist = new List<SubstituteModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_SETSUBSTITUTE_FORCESTORE", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.Add("@Message", SqlDbType.Int);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(cmd.Parameters["@Message"].Value);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<SubstituteModel> GetAllSubstitute(int index, int UserId = 0)
        {
            Connection con = new Connection();
            List<SubstituteModel> Substitutelist = new List<SubstituteModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_Substitute", sqlcon);
                cmd.Parameters.AddWithValue("@Id", UserId);
                cmd.Parameters.AddWithValue("@index", index);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubstituteModel Sub = new SubstituteModel();
                    Sub.Id = Convert.ToInt32(sdr["Id"]);
                    Sub.AssignedTo = Convert.ToInt32(sdr["AssignedTo"]);
                    Sub.AssignedFrom = Convert.ToInt32(sdr["AssignedFrom"]);
                    Sub.AssignedToName = sdr["AssignedToName"].ToString();
                    Sub.AssignedFromName = sdr["AssignedFromName"].ToString();
                    Sub.Reason = sdr["Reason"].ToString();
                    Sub.FromDate = Convert.ToDateTime(sdr["StartDate"]).ToString("dd-MMM-yyyy");
                    Sub.ToDate = Convert.ToDateTime(sdr["EndDate"]).ToString("dd-MMM-yyyy");
                    Sub.CreatedDate = Convert.ToDateTime(sdr["CreatedDate"]).ToString("dd-MMM-yyyy");
                    Substitutelist.Add(Sub);
                }
                return Substitutelist;
            }
        }

        public IEnumerable<SubstituteModel> GetAllUsers
        {
            get
            {
                Connection con = new Connection();
                List<SubstituteModel> Substitutelist = new List<SubstituteModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllUsers", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        SubstituteModel Substitute = new SubstituteModel();
                        Substitute.User_ID = Convert.ToInt32(sdr["User_ID"]);
                        Substitute.User_Name = sdr["User_Name"].ToString();
                        Substitutelist.Add(Substitute);
                    }
                }
                return Substitutelist;
            }
        }

        public int InsertAuditingLog(AuditingLogModel model)
        {
            try
            {

                int response = 0;
                Connection con = new Connection();
                string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
                string IPAddress = "";// Dns.GetHostEntry(hostName).AddressList[4].ToString();
                                      //string IPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                                      //if (IPAddress == "" || IPAddress == null)
                IPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_AuditingLog", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LogType", model.LogType);
                    cmd.Parameters.AddWithValue("@LogName", model.LogName);
                    cmd.Parameters.AddWithValue("@LogScreen", model.LogScreen);
                    cmd.Parameters.AddWithValue("@Reference", model.Reference);
                    cmd.Parameters.AddWithValue("@ActionPerformed", model.ActionPerformed);
                    cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                    cmd.Parameters.AddWithValue("@Misc", model.Misc);
                    cmd.Parameters.AddWithValue("@IPAddress", IPAddress);
                    cmd.Parameters.Add("@Message", SqlDbType.Int);
                    cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    response = Convert.ToInt32(cmd.Parameters["@Message"].Value);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
