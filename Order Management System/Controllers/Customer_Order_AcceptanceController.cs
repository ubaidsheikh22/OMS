using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class Customer_Order_AcceptanceController : Controller
    {
        // GET: Customer_Order_Acceptance
        public ActionResult Customer_Order_Acceptance()
        {
            return View();
        }
        [HttpPost]
        public JsonResult gridView()
        {
            string UserID = Session["User_ID"].ToString();

            int CustomerCode = Convert.ToInt32(Session["Customer"]);
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Accepted Order View by Dist.", "GettingCustomerAcceptedOrder", "GettingCustomerAcceptedOrder", "GettingCustomerAcceptedOrder", "", (int)Session["User_ID"]);

            CustomerOrderAcceptanceBusiness CustomerOrderAcceptance = new CustomerOrderAcceptanceBusiness();
            List<customerOrderAcceptanceModel> List = CustomerOrderAcceptance.getRecordToGrid(CustomerCode, UserID).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public string Insert(List<customerOrderAcceptanceModel> customerOrderAcceptanceModel)
        {
            int CustomerCode = Convert.ToInt32(Session["Customer"]);
            CustomerOrderAcceptanceBusiness CAB = new CustomerOrderAcceptanceBusiness();
            DataTable dt = new DataTable();
            dt.Columns.Add("OrderRefrenceNumber");
            dt.Columns.Add("CALDAY");
            dt.Columns.Add("customer");
            dt.Columns.Add("Material");
            dt.Columns.Add("Description");
            dt.Columns.Add("UnitPrice");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("WeeklyQuantity");
            dt.Columns.Add("FirmOrder");
            dt.Columns.Add("Monday");
            dt.Columns.Add("Tuesday");
            dt.Columns.Add("Wednesday");
            dt.Columns.Add("Thursday");
            dt.Columns.Add("Friday");
            dt.Columns.Add("Saturday");
            dt.Columns.Add("Sunday");
            dt.Columns.Add("IsAccepted");
            dt.Columns.Add("SalesOrganization");
            dt.Columns.Add("DistributionChannel");
            dt.Columns.Add("Division");
            // int i = 0;
            foreach (var code in customerOrderAcceptanceModel)
            {

                dt.Rows.Add(code.OrderRefrenceNumber, code.CALDAY,CustomerCode, code.Material, code.Description, code.UnitPrice, code.Quantity, code.WeeklyQuantity,
                    code.FirmOrder, code.Monday, code.Tuesday, code.Wednesday, code.Thursday , code.Friday , code.Saturday , code.Sunday,code.IsAccepted,
                    code.SalesOrganization,code.DistributionChannel,code.Division);

            }
            string message = CAB.addAcceptedOrders(dt).ToString();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Order Accepted By Customer", "OrderAccepted", "OrderAccepted", "OrderAccepted", "", (int)Session["User_ID"]);

            return message;
        }

       


    }
}