using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Repository;
using BusinessLayer.Models;
using System.Data;
using System.Data.SqlClient;

namespace Order_Management_System.Controllers
{
    public class SaleOrderLogController : Controller
    {
        // GET: SaleOrderLog
        public ActionResult SaleOrderLog()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetCustName()
        {
                string name = Session["Distributor_ID"].ToString();

            CustomerBusiness customer = new CustomerBusiness();
            List<CustomerModel> cm = customer.GetCustomer(name).ToList();
            return Json(cm, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLogs(string Customer, DateTime date)
        {
            Customer = Session["Distributor_ID"].ToString();
            string SalesOrganization = Session["SalesOrg"].ToString();
            string Division = Session["Division"].ToString();
            SaleOrderLogBusiness SO = new SaleOrderLogBusiness();
            List<SaleOrderLogModel> logs = SO.GetSaleOrderLogs(Customer, SalesOrganization,Division, date).ToList();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Sales Order Log", "Getting Sales Order Log", "GettingSalesOrderLog", "GettingSalesOrderLog", "", (int)Session["User_ID"]);

            return Json(logs, JsonRequestBehavior.AllowGet);
        }

    }
}