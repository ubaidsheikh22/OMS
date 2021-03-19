using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Models;
using BusinessLayer.Repository;

namespace Order_Management_System.Controllers
{
    public class dashboardController : Controller
    {
        // GET: dashboard
        public ActionResult dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllDashboardRecord()
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Dashboard Record", "GettingDashboardRecord", "GettingDashboardRecord", "GettingDashboardRecord", "", (int)Session["User_ID"]);

            string AreaCode = Session["AreaCode"].ToString();
            string TerritoryCode = Session["TerritoryCode"].ToString();
            string TownCode = Session["TownCode"].ToString();
            string RegionCode = Session["RegionCode"].ToString();
            string CustomerCode = Session["Customer"].ToString();
            string Role = Session["roleid"].ToString();
            if (Role == "5")
            {
                Role = "";
                DashboardBusiness desh = new DashboardBusiness();
                List<DashboardModel> DashboardRecord = desh.GetAllDashboardRecords("").ToList();
                DashboardBusiness desh1 = new DashboardBusiness();
                List<DashboardModel> DashboardRecord1 = desh.GetAcceptedOrders("").ToList();
                DashboardBusiness desh2 = new DashboardBusiness();
                List<DashboardModel> DashboardRecord2 = desh.GetSpecialOrder("").ToList();
                return Json(new { Suggested = DashboardRecord, Accepted = DashboardRecord1, Special = DashboardRecord2 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                DashboardBusiness desh = new DashboardBusiness();
                List<DashboardModel> DashboardRecord = desh.GetAllDashboardRecords(CustomerCode).ToList();
                DashboardBusiness desh1 = new DashboardBusiness();
                List<DashboardModel> DashboardRecord1 = desh.GetAcceptedOrders(CustomerCode).ToList();
                DashboardBusiness desh2 = new DashboardBusiness();
                List<DashboardModel> DashboardRecord2 = desh.GetSpecialOrder(CustomerCode).ToList();
                return Json(new { Suggested = DashboardRecord, Accepted = DashboardRecord1, Special = DashboardRecord2 }, JsonRequestBehavior.AllowGet);
            }


        }
        [HttpGet]
        public JsonResult TotalRegion()
        {
            string CustomerCode = Session["Customer"].ToString();
            string RegionCode = Session["RegionCode"].ToString();
            string Role = Session["roleid"].ToString();
            if (Role == "5")
            {
                Role = "";
                DashboardBusiness deshboad = new DashboardBusiness();
                List<DashboardModel> DashboardRecord2 = deshboad.Allregiontotal(Role).ToList();
                return Json(DashboardRecord2, JsonRequestBehavior.AllowGet);
            }
            else
            {
                DashboardBusiness desh = new DashboardBusiness();
                List<DashboardModel> DashboardRecord = desh.Allregiontotal(CustomerCode).ToList();
                return Json(DashboardRecord, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public JsonResult TotalOrdersalesorg()
        {
            string CustomerCode = Session["Customer"].ToString();
            string RegionCode = Session["RegionCode"].ToString();
            string Role = Session["roleid"].ToString();
            if (Role == "5")
            {
                Role = "";
                DashboardBusiness deshboad = new DashboardBusiness();
                List<DashboardModel> DashboardRecord2 = deshboad.AllSalesOrg(Role).ToList();
                return Json(DashboardRecord2, JsonRequestBehavior.AllowGet);
            }
            else
            {
                DashboardBusiness desh = new DashboardBusiness();
                List<DashboardModel> DashboardRecord = desh.AllSalesOrg(CustomerCode).ToList();
                return Json(DashboardRecord, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public JsonResult TotalOrderProductType()
        {
            string CustomerCode = Session["Customer"].ToString();
            string RegionCode = Session["RegionCode"].ToString();
            string Role = Session["roleid"].ToString();
            if (Role == "5")
            {
                Role = "";
                DashboardBusiness deshboad = new DashboardBusiness();
                List<DashboardModel> DashboardRecord2 = deshboad.AllProductType(Role).ToList();
                return Json(DashboardRecord2, JsonRequestBehavior.AllowGet);
            }
            else
            {
                DashboardBusiness desh = new DashboardBusiness();
                List<DashboardModel> DashboardRecord = desh.AllProductType(CustomerCode).ToList();
                return Json(DashboardRecord, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult GetDashboardforView()
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Redirecting To Dashboard", "GettingDashboard", "GettingDashboard", "GettingDashboard", "", (int)Session["User_ID"]);


            string AreaCode = Session["AreaCode"].ToString();
            string TerritoryCode = Session["TerritoryCode"].ToString();
            string TownCode = Session["TownCode"].ToString();
            string RegionCode = Session["RegionCode"].ToString();
            string CustomerCode = Session["Customer"].ToString();
            string Role = Session["roleid"].ToString();
            if (Role == "5")
            {
                DashboardBusiness desh2 = new DashboardBusiness();
                List<DashboardModel> DashboardRecord2 = desh2.AllDashboardRecord("").ToList();
                return Json(DashboardRecord2, JsonRequestBehavior.AllowGet);
            }
            
            return Json(true, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult GetDashboardOrderQTY()
        {
            string AreaCode = Session["AreaCode"].ToString();
            string TerritoryCode = Session["TerritoryCode"].ToString();
            string TownCode = Session["TownCode"].ToString();
            string RegionCode = Session["RegionCode"].ToString();
            string CustomerCode = Session["Customer"].ToString();
            string Role = Session["roleid"].ToString();
            if (Role == "5")
            {
                DashboardBusiness desh2 = new DashboardBusiness();
                List<DashboardModel> DashboardRecord2 = desh2.AllDashboardRecordQTYOrder("").ToList();
                return Json(DashboardRecord2, JsonRequestBehavior.AllowGet);
            }
            
            return Json(true, JsonRequestBehavior.AllowGet);

        }

    }
}