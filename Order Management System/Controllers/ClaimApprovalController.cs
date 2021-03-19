using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class ClaimApprovalController : Controller
    {
        int Error = -1;
        int Error2 = -2;
        int value = 2;
        int sifvalue = 0;
        int opcant = -3;
        // GET: ClaimApproval
        public ActionResult ClaimApproval()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getAllCustomer()
        {
            string RegionCode = Session["RegionCode"].ToString();
            string Areacode = Session["AreaCode"].ToString();
            string Terriotorycode = Session["TerritoryCode"].ToString();
            string Towncode = Session["TownCode"].ToString();
            string UserId = Session["User_ID"].ToString();
            ClaimApprovalBusiness DB = new ClaimApprovalBusiness();
            List<CustomerModel> ur = DB.getAllCustomerForClaim(RegionCode, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getAllClaimRefrenceCode(string customerCode)
        {
            string SalesOrg = Session["SalesOrg"].ToString();
            string UserID = Session["User_ID"].ToString();
            ClaimApprovalBusiness DB = new ClaimApprovalBusiness();
            List<WeekWiseOrder> ur = DB.getAllRefrenceCode(customerCode, UserID,SalesOrg).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAllClaimRecords(string ClaimID, string ClaimRef)
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("View Claim Records For Approval", "Getting Claim Records For Approval", "GettingClaimRecordsForApproval", "GettingClaimRecordsForApproval", "", (int)Session["User_ID"]);
            ClaimApprovalBusiness EML = new ClaimApprovalBusiness();
            List<WeekWiseOrder> emp = EML.GetALLClaimReRecord(ClaimID,ClaimRef).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult AddAppRoval(string refrenceCode, string CustomerCode,string refrenceToMCL)
        {
            int Approve = Convert.ToInt32(Session["roleid"]);
            string UserID = Session["User_ID"].ToString();
            string UserEmail = Session["UserEmail"].ToString();
            string Approvalname = Convert.ToString(Session["sessionName"]);
            ClaimApprovalBusiness db = new ClaimApprovalBusiness();
            string Message = db.AddClaimAprovalRefrence(refrenceCode, Approve, refrenceToMCL,UserID);
            emailSender email = new emailSender();
            string Recepient = "syed.adnanahmed@live.com,bssit.11.6@gmail.com,usman.saleem@ebm.com.pk,";
            Recepient += (new ClaimApprovalBusiness()).GetWorkFlowEmails(refrenceCode, Approve.ToString(), CustomerCode);

            if (Recepient[Recepient.Length - 1] == ',')
                Recepient = Recepient.Substring(0, Recepient.Length - 1);

            emailSender eSender = new emailSender();
            eSender.ClaimApproval(Recepient, "A Claim approval. </br> <b>Order Reference:</b> " + refrenceCode.ToUpper());

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Claim Approval", "Claim Approved", "ClaimApproved", "ClaimApproved", "", (int)Session["User_ID"]);
            //email.email(Recepient, "A Special Order is waiting for your approval. </br> <b>Order Reference:</b> " + refrenceCode.ToUpper(), "http://oms.ebmgroup.com.pk:1002/");
            return Json(Message);
        }

        [HttpPost]
        public JsonResult RejectAppRoval(string refrenceCode, string CustomerCode, string refrenceToMCL)
        {
            int Approve = Convert.ToInt32(Session["roleid"]);
            string UserID = Session["User_ID"].ToString();
            ClaimApprovalBusiness db = new ClaimApprovalBusiness();
                string Message = db.AddClaimAprovalRefrence(refrenceCode, -1, refrenceToMCL,UserID);
                emailSender email = new emailSender();
                string Recepient = "syed.adnanahmed@live.com,bssit.11.6@gmail.com,usman.saleem@ebm.com.pk,";
                Recepient += (new ClaimApprovalBusiness()).GetDownwardFlowEmails(refrenceCode, Approve.ToString(), CustomerCode);

                if (Recepient[Recepient.Length - 1] == ',')
                Recepient = Recepient.Substring(0, Recepient.Length - 1);

                emailSender eSender = new emailSender();
                eSender.ClaimApproval(Recepient, "A Rejection Email against. </br> <b>Order Reference:</b> " + refrenceCode.ToUpper());
                RoleController RC = new RoleController();
                RC.InsertAuditingLog("Claim Rejection", "Claim Rejected", "ClaimRejected", "ClaimRejected", "", (int)Session["User_ID"]);
                return Json(Message);

            }
            
        }
    }
