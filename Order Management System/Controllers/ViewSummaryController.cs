using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class ViewSummaryController : Controller
    {
        // GET: ViewSummary
        public ActionResult ChangeOrderSummary()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Summary()
        {
            viewAcceptedOrderBusiness PFB = new viewAcceptedOrderBusiness();
            List<customerOrderAcceptanceModel> PR = PFB.Summary().ToList();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Order Change Summary", "Getting Order Change Summary", "GettingOrderChangeSummary", "GettingOrderChangeSummary", "", (int)Session["User_ID"]);

            return Json(PR, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AuditSummary()
        {
            //viewAcceptedOrderBusiness PFB = new viewAcceptedOrderBusiness();
            // List<AuditingLogModel> PR = PFB.Audit("General,Error", "", "", "", "").ToList();
            return View();
        }
        [HttpPost]
        public JsonResult Audit(string LogType = null, string LogScreen = null, string Logname = null, string StartDate = null, string EndDate = null)
        {
            viewAcceptedOrderBusiness PFB = new viewAcceptedOrderBusiness();
            List<AuditingLogModel> PR = PFB.Audit(LogType, LogScreen, Logname, StartDate, EndDate).ToList();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Audit Log", "Getting Audit Log", "GettingAuditLog", "GettingAuditLog", "", (int)Session["User_ID"]);

            return Json(PR, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLogDropdown(int index)
        {
            viewAcceptedOrderBusiness PFB = new viewAcceptedOrderBusiness();
            List<AuditingLogDropModel> PR = PFB.GetLogDropdown(index);
            return Json(PR, JsonRequestBehavior.AllowGet);
        }

    }
}