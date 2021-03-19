using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class viewAcceptedOrdersController : Controller
    {
        // GET: viewAcceptedOrders
        public ActionResult viewAcceptedOrders()
        {
            return View();
        }


        public JsonResult getAllCustomer()
        {
            string areaCode = Session["AreaCode"].ToString();
            string regionCode = Session["RegionCode"].ToString();
            string townCode = Session["TownCode"].ToString();
            string territoryCode = Session["TerritoryCode"].ToString();
            viewAcceptedOrderBusiness PFB = new viewAcceptedOrderBusiness();
            List<CustomerModel> PR = PFB.getAllCustomer(areaCode, regionCode, townCode, territoryCode).ToList();
            return Json(PR, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getAllAcceptedOrders(int customer, string StartDate = null, string EndDate = null)
        {
            string UserID = Session["User_ID"].ToString();

            viewAcceptedOrderBusiness PFB = new viewAcceptedOrderBusiness();
            List<customerOrderAcceptanceModel> PR = PFB.getAllAcceptedOrders(customer, UserID, StartDate, EndDate).ToList();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Accepted Order View", "Getting Accepted Order View", "AcceptedOrderView", "AcceptedOrderView", "", (int)Session["User_ID"]);

            return Json(PR, JsonRequestBehavior.AllowGet);
        }


    }
}