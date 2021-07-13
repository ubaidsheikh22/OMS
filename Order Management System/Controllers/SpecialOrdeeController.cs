using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Mvc;
using BusinessLayer.Models;
using BusinessLayer.Repository;
using Order_Management_System.Helpers;

namespace Order_Management_System.Controllers
{
    public class SpecialOrdeeController : Controller
    {
        int Error = -1;
        int Error2 = -2;
        int value = 2;
        int sifvalue = 0;
        int opcant = -3;
        // GET: SpecialOrdee
        public ActionResult Special_Order()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllSpecialOrderRecords(string OrderID)
        {
            SpecialOrderApprovalBusiness EML = new SpecialOrderApprovalBusiness();

            List<Special_Orders_Approval> emp = EML.GetAllSpecialOrderRecords2(OrderID).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public JsonResult getAllCustomer()
        {
            string RegionCode = Session["RegionCode"].ToString();

            string UserId = Session["User_ID"].ToString();
            SpecialOrderApprovalBusiness DB = new SpecialOrderApprovalBusiness();
            List<CustomerModel> ur = DB.getAllCustomerForSpecialOrder(RegionCode, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }
        //, Areacode, Terriotorycode, Towncode
        [HttpGet]
        public JsonResult getAllRefrenceCode(string customerCode)
        {
            //string RegionCode = Session["RegionCode"].ToString();
            customerCode = string.IsNullOrEmpty(customerCode) || customerCode == "null" ? Session["Distributor_ID"].ToString() : customerCode;
            SpecialOrderApprovalBusiness DB = new SpecialOrderApprovalBusiness();
            List<specialOrderModel> ur = DB.getAllRefrenceCode(customerCode).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getAllRefrenceCode_Approval(string customerCode)
        {
            //string RegionCode = Session["RegionCode"].ToString();
            customerCode = string.IsNullOrEmpty(customerCode) || customerCode == "null" ? Session["Distributor_ID"].ToString() : customerCode;
            string UserID = Session["User_ID"].ToString();
            string SalesOrg = Session["SalesOrg"].ToString();
            SpecialOrderApprovalBusiness DB = new SpecialOrderApprovalBusiness();
            List<specialOrderModel> ur = DB.getAllRefrenceCode_Approval(customerCode, UserID, SalesOrg).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddAppRoval(string refrenceCode, string CustomerCode)
        {
            var Approvalname = Convert.ToString(Session["sessionName"]);
            string UserID = Session["User_ID"].ToString();
            int Approve = Convert.ToInt32(Session["roleid"]);
         //   string logemail = Session["UserEmail"].ToString();
            SpecialOrderApprovalBusiness db = new SpecialOrderApprovalBusiness();
            string Message = db.addSpecialOrderApproval(refrenceCode, Approve,UserID);
            emailSender email = new emailSender();
            string Recepient = ConfigManager.EmailToMultipleRecepient;
            Recepient += (new SpecialOrderApprovalBusiness()).GetWorkFlowEmails(refrenceCode, Approve.ToString(), CustomerCode);

            if (Recepient[Recepient.Length - 1] == ',')
                Recepient = Recepient.Substring(0, Recepient.Length - 1);
            Recepient = Recepient.Replace(",,", ",");

            emailSender eSender = new emailSender();
            eSender.SpecialOrderApproval(Recepient, "A Special Order Approved. </br> <b>Order Reference:</b> " + refrenceCode.ToUpper());
            RoleController RC = new RoleController();
            RC.InsertAuditingLogWithRef("Special Order Approved", "Special Order Appoved", "SpecialOrderApproved", "SpecialOrderApproved", "", (int)Session["User_ID"], refrenceCode);

            //email.email(Recepient, "A Special Order is waiting for your approval. </br> <b>Order Reference:</b> " + refrenceCode.ToUpper(), "http://oms.ebmgroup.com.pk:1002/");
            return Json(Message);
        }

        [HttpPost]
        public JsonResult RejectAppRoval(string refrenceCode, string CustomerCode)
        {
            string Approvalname = Convert.ToString(Session["sessionName"]);
            int Approve = Convert.ToInt32(Session["roleid"]);
            string UserID = Session["User_ID"].ToString();
            //string logemail = Session["UserEmail"].ToString();
            SpecialOrderApprovalBusiness db = new SpecialOrderApprovalBusiness();
            string Message = db.addSpecialOrderApproval(refrenceCode, -1,UserID);
            //emailSender email = new emailSender();
            string Recepient = ConfigManager.EmailToMultipleRecepient;
            Recepient += (new SpecialOrderApprovalBusiness()).GetDownwardFlowEmails(refrenceCode, Approve.ToString(), CustomerCode);

            if (Recepient[Recepient.Length - 1] == ',')
                Recepient = Recepient.Substring(0, Recepient.Length - 1);
            Recepient = Recepient.Replace(",,", ",");

            emailSender eSender = new emailSender();
            eSender.SpecialOrderApproval(Recepient, "A Special Order Rejected. </br> <b>Order Reference:</b> " + refrenceCode.ToUpper());
            RoleController RC = new RoleController();
            RC.InsertAuditingLogWithRef("Special Order Rejected", "Special Order Rejected", "SpecialOrderRejected", "SpecialOrderRejected", "", (int)Session["User_ID"], refrenceCode);
            return Json(Message);
        }
    }
}