using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace BusinessLayer.Repository
{
    public class RegisterBusiness
    {
        private Connection con;
        private SqlCommand cmd;
        private string Messages = string.Empty;
        public string RegiserAdd(Registraion_LoginVM VM, string status)
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            // var im = DateTime.Now.ToString();
            con = new Connection();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                if(VM.Login.Role_ID == 3)
                {
                    VM.Login.UserName = VM.User.UserFirstName;
                }
                cmd = new SqlCommand("SP_User_Insert_Update_Delete", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@UserFirstName", VM.User.UserFirstName);
                cmd.Parameters.AddWithValue("@UserLastName", VM.User.UserLastName);
                cmd.Parameters.AddWithValue("@UserName", VM.Login.UserName);
                cmd.Parameters.AddWithValue("@UserEmail", VM.Login.UserEmail == null || VM.Login.UserEmail == "null" ? "" : VM.Login.UserEmail);
                cmd.Parameters.AddWithValue("@password", VM.Login.Pass);
                
                cmd.Parameters.AddWithValue("@Role_ID", VM.Login.Role_ID);
                cmd.Parameters.AddWithValue("@User_ID", VM.User.User_ID);
                cmd.Parameters.AddWithValue("@Distributor_ID", VM.Login.Distributor_ID);
                cmd.Parameters.AddWithValue("@IPAddress", myIP);
                cmd.Parameters.AddWithValue("@Designation_ID", VM.User.Designation_ID);
                cmd.Parameters.AddWithValue("@RegionCode", VM.Login.RegionCode);
                cmd.Parameters.AddWithValue("@TerritoryCode", VM.Login.TerritoryCode);
                cmd.Parameters.AddWithValue("@TownCode", VM.Login.TownCode);
                cmd.Parameters.AddWithValue("@AreaCode", VM.Login.AreaCode);
                cmd.Parameters.AddWithValue("@SalesOrg", VM.Login.SalesOrg);
                cmd.Parameters.AddWithValue("@Division", VM.Login.Division);
                cmd.Parameters.AddWithValue("@Active", VM.Login.Active);
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@Message"] != null)
                    Messages = (string)cmd.Parameters["@Message"].Value;
                else
                    Messages = "User registration failed... Please try again!";
            }
            return Messages;
        }
        public string DeleteUser(string LoginId)
        {
            Connection con = new Connection();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginId", LoginId);
                if (cmd.ExecuteNonQuery() > 0)
                    return "1";
                else
                    return "0";
            }
        }
        public IEnumerable<JsonLoginRegistration> GetAllRegisrRecords
        {
            get
            {
                Connection con = new Connection();
                List<JsonLoginRegistration> rolelist = new List<JsonLoginRegistration>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("Get_AllUsers", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        try
                        {
                            JsonLoginRegistration register = new JsonLoginRegistration();
                            
                            register.Login_ID = Convert.ToInt32(sdr["Login_ID"]);
                            register.UserFirstName = sdr["UserFirstName"].ToString() == "" ? "-" : sdr["UserFirstName"].ToString();
                            register.UserLastName = sdr["UserLastName"].ToString();
                            register.UserName = sdr["UserName"].ToString() == "" ? "-" : sdr["UserName"].ToString();
                            register.UserEmail = sdr["UserEmail"].ToString() == "" ? "-" : sdr["UserEmail"].ToString();
                            register.Pass = sdr["Pass"].ToString() == "" ? "-" : sdr["Pass"].ToString();
                            register.Role_ID = Convert.ToInt32(sdr["Role_ID"]);
                            register.Rele_Desc = sdr["Rele_Desc"].ToString() == "" ? "-" : sdr["Rele_Desc"].ToString();
                            register.Designation_ID = Convert.ToInt32(sdr["Designation_ID"]);
                            register.Distributor_ID = sdr["Distributor_ID"].ToString();
                            register.User_ID = Convert.ToInt32(sdr["User_ID"]);
                            register.RegionCode = sdr["RegionDescription"].ToString() == "" ? "-" : sdr["RegionDescription"].ToString();
                            register.TerritoryCode = sdr["TerritoryDescription"].ToString() == "" ? "-" : sdr["TerritoryDescription"].ToString();
                            register.TownCode = sdr["TownDescription"].ToString() == "" ? "-" : sdr["TownDescription"].ToString();
                            register.AreaCode = sdr["AreaDescription"].ToString() == "" ? "-" : sdr["AreaDescription"].ToString();
                            register.Organization = sdr["SalesOrg"].ToString() == "" ? "-" : sdr["SalesOrg"].ToString();
                            register.Division = sdr["Division"].ToString() == "" ? "-" : sdr["Division"].ToString();
                            register.Active = sdr["Active"].ToString();
                            rolelist.Add(register);
                        }
                        catch (Exception ex)
                        {
                           string msg= ex.ToString();
                        }
                        
                    }
                }
                return rolelist;
            }
        }


    }
}
