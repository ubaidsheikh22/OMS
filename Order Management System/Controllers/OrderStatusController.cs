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
    public class OrderStatusController : Controller
    {
        // GET: OrderStatus
        public ActionResult OrderStatus()
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


        public JsonResult GetOrdersStatus(string Customer)
        {
            if (Customer == "-1")
                Customer = Session["Distributor_ID"].ToString();
            string SalesOrganization = Session["SalesOrg"].ToString();
            string Division = Session["Division"].ToString();
            OrderStatusBusiness OS = new OrderStatusBusiness();
            List<OrderStatus> OrderStatusList = OS.GetOrdersStatus(Customer, SalesOrganization, Division).ToList();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Order Status", "Getting Order Status", "GettingOrderStatus", "GettingOrderStatus", "", (int)Session["User_ID"]);

            return Json(OrderStatusList, JsonRequestBehavior.AllowGet);
        }



    }
}