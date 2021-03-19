using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class UpdatePasswordController : Controller
    {
        // GET: UpdatePassword
        public ActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasswordUpdate(string txtOldPass, string txtNewPass)
        {
         
            UpdatePasswordBusiness UP = new UpdatePasswordBusiness();
            UpdatePassword PassUpdate = new UpdatePassword()
            {
                User_ID = Session["User_ID"].ToString(),
                Pass = txtOldPass,
                NewPass = txtNewPass,
               
            };
            string message = UP.UpdatePass(PassUpdate);
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Password Updated", "Password Updated", "PasswordUpdated", "PasswordUpdated", "", (int)Session["User_ID"]);

            return Json(message);
        }
    }
}