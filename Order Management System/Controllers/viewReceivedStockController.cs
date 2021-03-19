using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class viewReceivedStockController : Controller
    {
        // GET: viewReceivedStock
        public ActionResult viewReceivedStock()
        {
            return View();
        }

        public JsonResult getAllReceivedStock( string StartDate = null, string EndDate = null)
        {
            string UserID = Session["User_ID"].ToString(); 
            int customer = Convert.ToInt32(Session["Distributor_ID"]);
            viewReceivedStockBusiness PFB = new viewReceivedStockBusiness();
            List<WeekWiseOrder> PR = PFB.getAllReceivedStock(customer, UserID, StartDate, EndDate).ToList();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Receiving Stock View", "Getting Receiving Stock View", "GettingReceivingStockView", "GettingReceivingStockView", "", (int)Session["User_ID"]);

            return Json(PR, JsonRequestBehavior.AllowGet);
        }

    }
}