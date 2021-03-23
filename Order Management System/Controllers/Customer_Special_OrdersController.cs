using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class Customer_Special_OrdersController : Controller
    {

        // GET: Customer_Special_Orders
        public ActionResult Create_Customer_Special_Orders()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllMaterialRecords(string SalesOrganization, string Division, string Material)
        {
            string customerCode = Session["Customer"].ToString();
            SalesOrganization = string.IsNullOrEmpty(SalesOrganization) ? Session["SalesOrg"].ToString() : SalesOrganization;
            Division = string.IsNullOrEmpty(Division) ? Session["Division"].ToString() : Division;
            Material = string.IsNullOrEmpty(Material) ? Material : Material;

            CustomerSpecialOrdersBuesiness EML = new CustomerSpecialOrdersBuesiness();
            List<materialMasterModel> emp = EML.GetAllMaterials(customerCode, SalesOrganization, Division, Material).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllSpecialOrderRecords(string OrderID)
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Special Order Record", "GettingSpecialOrderRecord", "GettingSpecialOrderRecord", "GettingSpecialOrderRecord", "", (int)Session["User_ID"]);

            SpecialOrderApprovalBusiness EML = new SpecialOrderApprovalBusiness();

            List<Special_Orders_Approval> emp = EML.GetAllSpecialOrderRecords2(OrderID).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult addSpecialOrder(List<specialOrderModel> sp)
        {
            int packageID = Convert.ToInt32(Session["Package_ID"]);
            int customerCode = Convert.ToInt32(Session["Customer"]);
            string email = Session["UserEmail"].ToString();

            CustomerSpecialOrdersBuesiness db = new CustomerSpecialOrdersBuesiness();

            List<string> message = db.addSpecialOrder(sp, customerCode, packageID);

            string Recepient = email + "," + "syed.adnanahmed@live.com,bssit.11.6@gmail.com,usman.saleem@ebm.com.pk,ubaidsheikh.iu@gmail.com,";
            Recepient += (new SpecialOrderApprovalBusiness()).GetWorkFlowEmails("", "0", customerCode.ToString());

            if (Recepient[Recepient.Length - 1] == ',')
                Recepient = Recepient.Substring(0, Recepient.Length - 1);

            Recepient = Recepient.Replace(",,", ",");

            if (message != null)
            {
                //SendOrderEmail(Recepient, "A Special Order is waiting for your approval. </br> <b>Customer Code:</b> " + customerCode, message[1], sp[0].SP_Order_ID);
                emailSender es = new emailSender();
                string EmailBody = "New Special Order is waiting for your approval. </br></br> <b>Customer Code:</b> " + customerCode;
                es.SpecialOrderApproval(Recepient, EmailBody);
                RoleController RC = new RoleController();
                RC.InsertAuditingLog("Special Order Created", "SpecialOrderCreated", "SpecialOrderCreated", "SpecialOrderCreated", "", (int)Session["User_ID"]);
            }
            return Json(message[0]);
        }

        [HttpGet]
        public JsonResult getAllRefrenceCode(string StartDate = null, string EndDate = null)
        {
            string CustomerCode = Session["Customer"].ToString();
            string SalesOrganization = Session["SalesOrg"].ToString();
            string Division = Session["Division"].ToString();


            SpecialOrderApprovalBusiness DB = new SpecialOrderApprovalBusiness();
            List<specialOrderModel> ur = DB.getAllRefrenceCode(CustomerCode, SalesOrganization, Division, StartDate, EndDate).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        public bool SendOrderEmail(string receiver, string subject, string FirstName, string RefNo)
        {
            try
            {
                string Body = @"<table border=""0"" width=""100 %""><tbody><tr><td align=""center""><table style=""display: table; max-width:550px; min-width:550px; text-align:center"">
                                <tbody><tr><td align=""center"">< img src =""http://www.ebm.com.pk/wp-content/themes/ebm/images/logo.png"" ></td></tr><tr><td style=""color: #000000; font-family: Arial, sans-serif, 'Open Sans'; font-size: 16px; line-height: 18px; text-align: left"">
                                <br/><br/><b> Dear " + FirstName + " </ b ></td></tr><tr><td style=" + "color: #000000; font-family: Arial, sans-serif, 'Open Sans'; font-size: 16px; line-height: 24px; text-align: left" + ">Special order # <b><a href=" + "#" + " target=" + "_blank" + ">" + RefNo + "</a></b> is pending at your end for special order approval</td></tr></tbody></table></td></tr></tbody></table>";

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("email.ebmgroup.com.pk");
                mail.From = new MailAddress("oms.wf@ebm.com.pk");
                mail.To.Add(receiver);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = Body;
                SmtpServer.Port = 25;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Send(mail);
                RoleController RC = new RoleController();
                RC.InsertAuditingLog("Special Order Email", "SpecialOrderEmail", "SpecialOrderEmail", "SpecialOrderEmail", "", (int)Session["User_ID"]);
                return true;
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Some Error";
                return false;
            }
        }
        [HttpGet]
        public JsonResult getSALESORG(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {
            if (string.IsNullOrEmpty(sales) || sales == "null")
                sales = Session["SalesOrg"].ToString();

            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetSalesOrg(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getDivision(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {
            if (string.IsNullOrEmpty(Division) || Division == "null")
                Division = Session["Division"].ToString();

            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetDivision(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMaterials(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {
            if (string.IsNullOrEmpty(Division) || Division == "null")
                Division = Session["Division"].ToString();

            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetMaterials(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }

    }
}