using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer.Repository
{
    public class LoginBusiness
    {
        private Connection conn;
        private SqlCommand cmd;
        DataSet dt = new DataSet();
        private string Message = string.Empty;
       
        public DataTable CheckUserExists(string UserName)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<Login> LoginList = new List<Login>();
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_CheckUserNameExists", sqlcon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@UserName", UserName);
                da.Fill(dt);
                return dt;
            }
        }
        public List<Login> EditUser(string Login_ID)
        {
            DataTable dt = new DataTable();
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<Login> LoginList = new List<Login>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_EditUser", sqlcon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Loginid", Login_ID);
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    Login CM = new Login();
                    
                    CM.User_ID = int.Parse(dr["User_ID"].ToString());
                    CM.UserName = dr["UserName"].ToString();
                    CM.UserEmail = dr["UserEmail"].ToString();
                    CM.Pass = dr["Pass"].ToString();
                    CM.Role_ID = int.Parse(dr["Role_ID"].ToString());
                    CM.Distributor_ID = dr["Distributor_ID"].ToString();
                    CM.RegionCode = dr["RegionCode"].ToString();
                    CM.AreaCode = dr["AreaCode"].ToString();
                    CM.TerritoryCode = dr["TerritoryCode"].ToString();
                    CM.TownCode = dr["TownCode"].ToString();
                    CM.UserFirstName = dr["UserFirstName"].ToString();
                    CM.UserLastName = dr["UserLastName"].ToString();
                    CM.Division = dr["Division"].ToString();
                    CM.SalesOrg = dr["SaleOrg"].ToString();
                    CM.Position = dr["Designation_ID"].ToString();
                    CM.Active = dr["IsActive"].ToString() == "True";
                    LoginList.Add(CM);
                }

            }
            return LoginList;
        }
        public IEnumerable<Login> adminLogin(Login model, out string Message)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<Login> LoginList = new List<Login>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllLogin", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", model.UserName);
                cmd.Parameters.AddWithValue("@Pass", model.Pass);
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 100);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                sqlcon.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                Message = (string)cmd.Parameters["@message"].Value;

                if (Message == null)
                    Message = sdr.HasRows ? "Success" : "";

                if (!Message.Contains("Success"))
                    return null;

                while (sdr.Read())
                {
                    Login CM = new Login();
                    CM.User_ID = Convert.ToInt32(sdr["User_ID"]);
                    CM.UserName = sdr["UserName"].ToString();
                    CM.UserEmail = sdr["UserEmail"].ToString();
                    CM.Role_ID = Convert.ToInt32(sdr["Role_ID"]);
                    CM.Distributor_ID = sdr["Distributor_ID"].ToString();
                    CM.RegionCode = sdr["RegionCode"].ToString();
                    CM.AreaCode = sdr["AreaCode"].ToString();
                    CM.TerritoryCode = sdr["TerritoryCode"].ToString();
                    CM.TownCode = sdr["TownCode"].ToString();
                    //CM.Package_ID = sdr["Package_ID"].ToString() == "" ? 0 : Convert.ToInt32(sdr["Package_ID"]);
                    CM.PackageName = sdr["PackageName"].ToString();
                    CM.Customer = sdr["Customer"].ToString();
                    CM.Position = sdr["Position"].ToString();
                    CM.SalesOrg = sdr["SalesOrg"].ToString();
                    CM.Division = sdr["Division"].ToString();

                    LoginList.Add(CM);
                }
                sqlcon.Close();
            }
            return LoginList;

        }


        public IEnumerable<Login> GetAllLogin
        {
            get
            {
                Connection con = new Connection();
                List<Login> LgList = new List<Login>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllLogin", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Login lg = new Login();
                        lg.User_ID = Convert.ToInt32(sdr["User_ID"]);
                        lg.UserName = sdr["UserName"].ToString();
                        lg.UserEmail = sdr["UserEmail"].ToString();
                        lg.Pass = sdr["Pass"].ToString();
                        lg.Role_ID = Convert.ToInt32(sdr["Role_ID"]);
                        lg.Distributor_ID = sdr["Distributor_ID"].ToString();
                        lg.RegionCode = sdr["RegionCode"].ToString();
                        lg.AreaCode = sdr["AreaCode"].ToString();
                        lg.TerritoryCode = sdr["TerritoryCode"].ToString();
                        lg.TownCode = sdr["TownCode"].ToString();
                        lg.Distributor_ID = sdr["Distributor_ID"].ToString();
                        lg.Position = sdr["Position"].ToString();
                        lg.Customer = sdr["Customer"].ToString();

                        LgList.Add(lg);
                    }
                }
                return LgList;
            }
        }
        public IEnumerable<Login> getAreaDetails(string customer)
        {

            Connection con = new Connection();
            List<Login> WeekWiselist = new List<Login>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("getcustomerregion", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer", customer);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Login WeekWiseOrderModel = new Login();
                    WeekWiseOrderModel.AreaCode = sdr["AreaCode"].ToString();
                    WeekWiseOrderModel.TownCode = sdr["TownCode"].ToString();
                    WeekWiseOrderModel.TerritoryCode = sdr["TerritoryCode"].ToString();
                    WeekWiseOrderModel.RegionCode = sdr["RegionCode"].ToString();
                    WeekWiselist.Add(WeekWiseOrderModel);
                }
            }
            return WeekWiselist;

        }

        public IEnumerable<Login> getRegionDetails()
        {

            Connection con = new Connection();
            List<Login> WeekWiselist = new List<Login>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_AllRegions", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@customer", customer);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Login WeekWiseOrderModel = new Login();
                    WeekWiseOrderModel.RegionCode = sdr["RegionCode"].ToString();
                    WeekWiseOrderModel.RegionDesc = sdr["RegionDescription"].ToString();
                    //WeekWiseOrderModel.TerritoryCode = sdr["TerritoryCode"].ToString();
                    //WeekWiseOrderModel.RegionCode = sdr["RegionCode"].ToString();
                    WeekWiselist.Add(WeekWiseOrderModel);
                }
            }
            return WeekWiselist;

        }


        public IEnumerable<Login> getAllArea(string Region)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<Login> packageList = new List<Login>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllAreaRegionWise", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@regionCode", Region);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Login Login = new Login();
                    Login.AreaCode = sdr["AreaCode"].ToString();
                    Login.AreaDesc = sdr["AreaDescription"].ToString();
                    packageList.Add(Login);
                }
                sqlcon.Close();
            }
            return packageList;

        }

        public IEnumerable<Login> getAllTerritory(string Region)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<Login> packageList = new List<Login>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllTerritoryAreaWise", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@areaCode", Region);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Login Login = new Login();
                    Login.TerritoryCode = sdr["TerritoryCode"].ToString();
                    Login.TerritoryDesc = sdr["TerritoryDescription"].ToString();
                    packageList.Add(Login);
                }
                sqlcon.Close();
            }
            return packageList;

        }

        public IEnumerable<Login> getAllTown(string Territory)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<Login> packageList = new List<Login>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllTownTerritoryWise", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@territory", Territory);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Login Login = new Login();
                    Login.TownCode = sdr["TownCode"].ToString();
                    Login.TownDesc = sdr["TownDescription"].ToString();
                    packageList.Add(Login);
                }
                sqlcon.Close();
            }
            return packageList;

        }


        public IEnumerable<Login> getAllADUsers(string UserName)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<Login> ADUsersList = new List<Login>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllADUsers", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@UserName", UserName);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Login Login = new Login();
                    Login.UserName = sdr["UserName"].ToString();
                    ADUsersList.Add(Login);
                }
                sqlcon.Close();
            }
            return ADUsersList;

        }


        //public IEnumerable<Login> getAllADEmails(string ADEmail)
        //{
        //    string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
        //    List<Login> ADUsersEmails = new List<Login>();
        //    using (SqlConnection sqlcon = new SqlConnection(Conn))
        //    {
        //        SqlCommand cmd = new SqlCommand("Get_AllADEmails", sqlcon);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        //cmd.Parameters.AddWithValue("@UserName", UserName);
        //        sqlcon.Open();
        //        SqlDataReader sdr = cmd.ExecuteReader();
        //        while (sdr.Read())
        //        {
        //            Login Login = new Login();
        //            Login.UserEmail = sdr["mail"].ToString();
        //            ADUsersEmails.Add(Login);
        //        }
        //        sqlcon.Close();
        //    }
        //    return ADUsersEmails;

        //}






        public IEnumerable<DistributorModel> GetAllDistributotRecords(string Region, string Area, string Territory, string Town)
        {

            Connection con = new Connection();
            List<DistributorModel> Distributorlist = new List<DistributorModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllDistributionHierarchy", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", Region);
                cmd.Parameters.AddWithValue("@Area", Area);
                cmd.Parameters.AddWithValue("@Territory", Territory);
                cmd.Parameters.AddWithValue("@Town", Town);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DistributorModel distri = new DistributorModel();
                    distri.Distributor_ID = Convert.ToInt32(sdr["Customer"]);
                    distri.Distributor_Name = sdr["Name1"].ToString();
                    //distri.Role_ID = Convert.ToInt32(sdr["Role_ID"]);
                    Distributorlist.Add(distri);
                }

                return Distributorlist;
            }
        }


        public IEnumerable<user> GetUserDrop()
        {

            Connection con = new Connection();
            List<user> userlist = new List<user>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetUserDrop", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    user user = new user();
                    user.User_ID = Convert.ToInt32(sdr["User_ID"]);
                    user.UserFirstName = sdr["UserFirstName"].ToString();
                    userlist.Add(user);
                }

                return userlist;
            }
        }
        public IEnumerable<user> GetUserDropMenu()
        {

            Connection con = new Connection();
            List<user> userlist = new List<user>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetUserDropMenu", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    user user = new user();
                    user.User_ID = Convert.ToInt32(sdr["User_ID"]);
                    user.UserFirstName = sdr["UserFirstName"].ToString();
                    userlist.Add(user);
                }

                return userlist;
            }
        }

        public string InsertUpdateUserMenu(UserMenuModel menu)
        {
            try
            {
                Connection con = new Connection();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_InsertUpdateUserMenu", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", menu.ID);
                    cmd.Parameters.AddWithValue("@UserId", menu.UserId);
                    cmd.Parameters.AddWithValue("@UserScreens", menu.Screens);
                    cmd.Parameters.AddWithValue("@Action", menu.Action);
                    cmd.Parameters.Add("@message", SqlDbType.VarChar, 100);
                    cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    Message = (string)cmd.Parameters["@message"].Value;
                    return Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public IEnumerable<UserMenuModel> GetUserMenuGrid()
        {

            Connection con = new Connection();
            List<UserMenuModel> userlist = new List<UserMenuModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetUserMenu", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    UserMenuModel user = new UserMenuModel();
                    user.ID = Convert.ToInt32(sdr["ID"]);
                    user.SetupForms = sdr["SetupScreen"].ToString();
                    user.MasterData = sdr["MasterScreen"].ToString();
                    user.ReviewOrders = sdr["ReviewScreen"].ToString();
                    user.Summary = sdr["SummaryScreen"].ToString();
                    user.Reports = sdr["Reports"].ToString();
                    user.TransactionForms = sdr["TransactionScreen"].ToString();
                    user.ClaimForms = sdr["ClaimScreen"].ToString();
                    user.UserName = sdr["UserName"].ToString();
                    user.Email = sdr["Email"].ToString();
                    if (user.SetupForms != "")
                        user.SetupForms = user.SetupForms.Remove(0, 1);
                    if (user.MasterData != "")
                        user.MasterData = user.MasterData.Remove(0, 1);
                    if (user.ReviewOrders != "")
                        user.ReviewOrders = user.ReviewOrders.Remove(0, 1);
                    if (user.Summary != "")
                        user.Summary = user.Summary.Remove(0, 1);
                    if (user.TransactionForms != "")
                        user.TransactionForms = user.TransactionForms.Remove(0, 1);
                    if (user.ClaimForms != "")
                        user.ClaimForms = user.ClaimForms.Remove(0, 1);
                    userlist.Add(user);
                }

                return userlist;
            }
        }

        public UserMenuModel GetUserMenuByID(int UserId)
        {

            Connection con = new Connection();
            UserMenuModel user = new UserMenuModel();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetUserMenuById", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", UserId);
                SqlDataReader sdr = cmd.ExecuteReader();

                //If no menus found, will return a error message - Adnan
                if (!sdr.HasRows)
                    return null;

                sdr.Read();
                {
                    user.Screens = sdr["UserScreens"].ToString();
                    //   user.MasterData = sdr["MasterScreen"].ToString();
                    //  user.ReviewOrders = sdr["ReviewScreen"].ToString();
                    // user.Summary = sdr["SummaryScreen"].ToString();
                    //  user.TransactionForms = sdr["TransactionScreen"].ToString();
                    //  user.ClaimForms = sdr["ClaimScreen"].ToString();
                }
                return user;
            }
        }

        public IEnumerable<UserMenuModel> getDropUserMenu(int type)
        {

            Connection con = new Connection();
            List<UserMenuModel> userlist = new List<UserMenuModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_getDropUserMenu", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", type);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    UserMenuModel user = new UserMenuModel();
                    user.ID = Convert.ToInt32(sdr["ID"]);
                    user.Screens = sdr["Name"].ToString();
                    userlist.Add(user);
                }

                return userlist;
            }
        }

        public UserMenuModel geteditUserMenubyID(int ID)
        {

            Connection con = new Connection();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_geteditUserMenubyID", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader sdr = cmd.ExecuteReader();
                UserMenuModel user = new UserMenuModel();
                while (sdr.Read())
                {
                    user.Screens = sdr["UserScreens"].ToString();
                }

                return user;
            }
        }

        public UserMenuModel geteditUserMenubyID(int ID, int? type)
        {
            Connection con = new Connection();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_geteditUserMenubyID", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@type", type);
                SqlDataReader sdr = cmd.ExecuteReader();
                UserMenuModel user = new UserMenuModel();
                while (sdr.Read())
                {
                    user.Screens = sdr["UserScreens"].ToString();
                    if (user.Screens != "")
                        user.Screens = user.Screens.Remove(0, 1);
                }

                return user;
            }
        }

    }
}
