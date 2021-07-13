using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class ErrorHandlerController : Controller
    {
        // GET: ErrorHandler
        public ActionResult ErrorHandler()
        {
            if (Session["user"] == null || string.IsNullOrEmpty(Convert.ToString(Session["user"])))
                return RedirectToAction("Login", "Login", new { area = "" });

            return View();
        }
    }
}