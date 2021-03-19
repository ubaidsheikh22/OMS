using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Order_Management_System.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult UserLogin(Login Login)
        {
            string domainName = "vm101.ebmgroup.com.pk";
            string Message = null;
            bool IsValid = false;
            bool ActiveDirectory_ConnectionStatus = false;

            //if (ConfigurationManager.AppSettings["ADCheck"] != "true")
            //{
            //    IsValid = true;
            //    ActiveDirectory_ConnectionStatus = true;
            //}
            //else
            //{
                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
                    IsValid = ctx.ValidateCredentials(Login.UserName, Login.Pass);
                    ActiveDirectory_ConnectionStatus = true;
                }
                catch (System.DirectoryServices.AccountManagement.PrincipalServerDownException ex)
                {
                    ActiveDirectory_ConnectionStatus = false;

                    if(ConfigurationManager.AppSettings["enforceLDAP"].ToLower() == "n")
                    {
                        IsValid = true;
                        ActiveDirectory_ConnectionStatus = true;
                    }
                }
            //}

            LoginBusiness lg = new LoginBusiness();
            var UserData = lg.adminLogin(Login, out Message);

            List<Login> ur = UserData != null ? UserData.ToList() : null;

            int Role = ur != null && ur.Count > 0 ? ur[0].Role_ID : 0;

            if (!Message.Contains("Success"))
            {
                return Json(new
                {
                    redirectUrl = Url.Action("Login", "Login", Message),
                    isRedirect = false,
                    LoginError = Message
                });
            }

            //When AD Connection fails and user is neither Admin nor Distributor
            else if (!ActiveDirectory_ConnectionStatus && Login.UserName.ToLower() != "admin" && Role != 3)
            {
                return Json(new
                {
                    redirectUrl = Url.Action("Login", "Login", -3),
                    isRedirect = false,
                    LoginError = "Connection to EBM Server failed..."
                });
            }
            //When AD Connected but user Auth returns false and User is neither admin nor distributor
            else if (ActiveDirectory_ConnectionStatus && !IsValid && Login.UserName.ToLower() != "admin" && Role != 3)
            {
                return Json(new
                {
                    redirectUrl = Url.Action("Login", "Login", -1),
                    isRedirect = false,
                    LoginError = "The entered user name or password is invalid! Please try again..."
                });
            }

            FormsAuthentication.SetAuthCookie(Login.UserName, false);

            var item = ur[0];
            Login.UserName = item.UserName;
            Login.UserEmail = item.UserEmail;
            Login.Distributor_ID = item.Distributor_ID;
            Login.Role_ID = item.Role_ID;
            Login.User_ID = item.User_ID;
            Login.RegionCode = item.RegionCode;
            Login.AreaCode = item.AreaCode;
            Login.TerritoryCode = item.TerritoryCode;
            Login.TownCode = item.TownCode;
            Login.Customer = item.Customer;
            Login.Position = item.Position == "" ? "0" : item.Position;
            Login.SalesOrg = item.SalesOrg;
          
            Login.Division = item.Division;

            Session["user"] = item.UserName;
            Session["Distributor_ID"] = item.Distributor_ID;
           
            Session["UserEmail"] = item.UserEmail;
            Session["pas"] = item.Pass;
            Session["roleid"] = item.Role_ID;
            Session["User_ID"] = item.User_ID;
            Session["RegionCode"] = item.RegionCode;
            Session["AreaCode"] = item.AreaCode;
            Session["TerritoryCode"] = item.TerritoryCode;
            Session["TownCode"] = item.TownCode;
            Session["Customer"] = item.Distributor_ID;
            Session["Position"] = item.Position;
            Session["SalesOrg"] = item.SalesOrg;
            Session["Division"] = item.Division;
            GetUserMenuByID(item.User_ID);

            RoleController rc = new RoleController();
            rc.InsertAuditingLog("Login", "Login success", "Login", "UserLogin", "Authentication", (int)Session["User_ID"]);
            //return 
            return Json(new
            {
                //message
                redirectUrl = Url.Action("Dashboard", "Dashboard"),
                isRedirect = true,
                Login.Role_ID,
                Login.UserName,
                Login.UserEmail,
                Login.RegionCode,
                Login.Distribution,
                Login.AreaCode,
                Login.TerritoryCode,
                Login.TownCode,
                LoginError = "Success"

            });
        }
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public JsonResult RegisterAdd(Registraion_LoginVM VM)
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("New User Registered", "User Registered", "UserRegistered", "UserRegistered", "", (int)Session["User_ID"]);

            RegisterBusiness RB = new RegisterBusiness();
            string message = RB.RegiserAdd(VM, "Add");
            return Json(message);
        }
        [HttpPost]
        public JsonResult EditUser(string LoginId)
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("User Editing Process Run", "User Editing Process Run", "UserEditingProceed", "UserEditingProceed", "", (int)Session["User_ID"]);

            LoginBusiness lb = new LoginBusiness();
            List<Login> list = lb.EditUser(LoginId).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateRegister(Registraion_LoginVM up)
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("User Updated", "User Updated", "UserUpdated", "UserUpdated", "", (int)Session["User_ID"]);

            RegisterBusiness rb = new RegisterBusiness();
            string Message = rb.RegiserAdd(up, "Update");
            return Json(Message);
        }

        [HttpPost]
        public JsonResult GetAllRegistraitonRecord()
        {
            RegisterBusiness EML = new RegisterBusiness();

            List<JsonLoginRegistration> emp = EML.GetAllRegisrRecords.ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteUser(string LoginId)
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("User Deletion Processed", "User Deletion Processed", "UserDeletionProcessed", "UserDeletionProcessed", "", (int)Session["User_ID"]);

            RegisterBusiness business = new RegisterBusiness();
            string m = business.DeleteUser(LoginId);

            return m == "1" ? Json("Delete Successfully", JsonRequestBehavior.AllowGet) : Json("This user has performed transactions in the system and cannot be deleted!", JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public void Logout()
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("User Logout Processed", "User Logout Processed", "UserLogoutProcessed", "UserLogoutProcessed", "", (int)Session["User_ID"]);

            Response.AddHeader("Cache-Control", "no-cache, no-store,must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
            Response.AddHeader("Expires", "0");
            Session.Abandon();
            Session.Clear();
            Response.Cookies.Clear();
            Session.RemoveAll();

            Session["user"] = null;
            Session["pas"] = null;
            Session["UserEmail"] = null;
            Session["dis"] = null;
            Session["roleid"] = null;
            Session["Package_ID"] = null;
            Session["User_ID"] = null;
            Session["RegionCode"] = null;
            Session["AreaCode"] = null;
            Session["TerritoryCode"] = null;
            Session["TownCode"] = null;
            Response.Redirect("~/Login");

        }

        [AllowAnonymous]
        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public JsonResult getArea(string customer)
        {

            LoginBusiness LoginBusiness = new LoginBusiness();
            //customer = Session["customer"].ToString();
            List<Login> list = LoginBusiness.getAreaDetails(customer).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getRegions()
        {

            LoginBusiness LoginBusiness = new LoginBusiness();
            List<Login> list = LoginBusiness.getRegionDetails().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getAllArea(string regionCode)
        {
            LoginBusiness db = new LoginBusiness();
            //regionCode = Session["RegionCode"].ToString();
            List<Login> PR = db.getAllArea(regionCode).ToList();

            return Json(PR, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getAllTerritory(string AreaCode)
        {
            LoginBusiness db = new LoginBusiness();
            //AreaCode = Session["AreaCode"].ToString();
            List<Login> PR = db.getAllTerritory(AreaCode).ToList();

            return Json(PR, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getAllTown(string TerritoryCode)
        {
            LoginBusiness db = new LoginBusiness();
            //TerritoryCode = Session["TerritoryCode"].ToString();
            List<Login> PR = db.getAllTown(TerritoryCode).ToList();

            return Json(PR, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetDistrict(string Region, string Area, string Territory, string Town)
        {
            LoginBusiness RBb = new LoginBusiness();
            //Region = Session["RegionCode"].ToString();
            //Area = Session["AreaCode"].ToString();
            //Territory = Session["TerritortyCode"].ToString();
            //Town = Session["TownCode"].ToString();
            List<DistributorModel> r = RBb.GetAllDistributotRecords(Region, Area, Territory, Town).ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetUserDrop(string UserName)
        {
            LoginBusiness db = new LoginBusiness();
            List<Login> PR = db.getAllADUsers(UserName).ToList();

            return Json(PR, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult GetEmail(string ADEmail)
        //{
        //    LoginBusiness db = new LoginBusiness();
        //    List<Login> PR = db.getAllADEmails(ADEmail).ToList();

        //    return Json(PR, JsonRequestBehavior.AllowGet);
        //}




        [HttpPost]
        public ActionResult GetUserDropEdit()
        {
            string domainName = "vm101.ebmgroup.com.pk";
            DataTable dt = new DataTable();
            DataTable dbUserdt = new DataTable();
            dt.Columns.Add("SamAccountName");
            dt.Columns.Add("DisplayName");
            dt.Columns.Add("userPrincipalName");
            dt.Columns.Add("mail");
            dt.Columns.Add("Department");
            List<user> userlist = new List<user>();
            LoginBusiness business = new LoginBusiness();

            string DomainAuth_u = System.Web.Configuration.WebConfigurationManager.AppSettings["DomainAuth_u"];
            string DomainAuth_p = System.Web.Configuration.WebConfigurationManager.AppSettings["DomainAuth_p"];

            using (var context = new PrincipalContext(ContextType.Domain, domainName, DomainAuth_u, DomainAuth_p))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        string Department = string.Empty;
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        if (de.Properties.Contains("department"))
                        {
                            Department = de.Properties["department"].Value.ToString();
                            if (Department == "Information Technology" || Department == "Sales" || Department == "Logistics and Warehouse" || Department == "IT")
                            {


                                dt.Rows.Add(Convert.ToString(de.Properties["samAccountName"].Value), Convert.ToString(de.Properties["DisplayName"].Value),
                                Convert.ToString(de.Properties["userPrincipalName"].Value), Convert.ToString(de.Properties["mail"].Value), Department);
                                user user = new user();

                                user.UserFirstName = Convert.ToString(de.Properties["samAccountName"].Value);
                                userlist.Add(user);

                            }

                        }

                    }

                }
            }

            return Json(userlist.OrderBy(o => o.UserFirstName).ToList(), JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult SetupUserMenu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetUserDropMenu()
        {
            LoginBusiness RBb = new LoginBusiness();
            List<user> r = RBb.GetUserDropMenu().ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult InsertUpdateUserMenu(UserMenuModel menu)
        {
            LoginBusiness RBb = new LoginBusiness();
            RoleController rc = new RoleController();
            menu.UserId = (int)Session["User_ID"];
            string r = RBb.InsertUpdateUserMenu(menu);
            if (r == "Success")
            {
                rc.InsertAuditingLog("User Menu Iserted Or Updated", "User Menu Inserted or Updated", "UserMenuInsertedorUpdated", "UserMenuInsertedorUpdated", "", (int)Session["User_ID"]);
                return Json(r, JsonRequestBehavior.AllowGet);
            }
            else
            {
                rc.InsertAuditingLog("Error User Menu Iserted Or Updated", "Error User Menu Inserted or Updated", "ErrorUserMenuInsertedorUpdated", "ErrorUserMenuInsertedorUpdated", "", (int)Session["User_ID"]);
                return Json(r, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetUserMenuGrid()
        {
            LoginBusiness RBb = new LoginBusiness();
            List<UserMenuModel> r = RBb.GetUserMenuGrid().ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public int GetUserMenuByID(int User_ID)
        {
            LoginBusiness db = new LoginBusiness();
            UserMenuModel PR = db.GetUserMenuByID(User_ID);

            if (PR != null)
            {
                Session["Screens"] = PR.Screens;
                return 1;
            }
            else
            {
                Session.Remove("Screens");
                return -2;
            }
        }
        [HttpPost]
        public ActionResult getDropUserMenu(int type)
        {
            LoginBusiness RBb = new LoginBusiness();
            List<UserMenuModel> r = RBb.getDropUserMenu(type).ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult geteditUserMenubyID(int ID, int? type)
        {
            LoginBusiness RBb = new LoginBusiness();
            if (type == 0 || type == null)
            {
                UserMenuModel r = RBb.geteditUserMenubyID(ID);
                return Json(r, JsonRequestBehavior.AllowGet);
            }
            else
            {

                UserMenuModel r = RBb.geteditUserMenubyID(ID, type);
                return Json(r, JsonRequestBehavior.AllowGet);

            }

        }

    }
}