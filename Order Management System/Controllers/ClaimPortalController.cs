using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Models;
using Newtonsoft.Json;
using BusinessLayer.Repository;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace Order_Management_System.Controllers
{
    public class ClaimPortalController : Controller
    {
        string fname;
        // GET: ClaimPortal
        public ActionResult Claim()
        {
            return View();
        }
        [HttpPost] //List<pendingQuantities> ClaimOrders
        public JsonResult CreateClaim(List<pendingQuantities> ClaimOrders)
        {
            string email = Session["UserEmail"].ToString();
            int CustomerCode =Convert.ToInt32(Session["Customer"]);
            ClaimPortalBusiness cpb = new ClaimPortalBusiness();
            List<string> Message = cpb.CreateClaims(ClaimOrders, CustomerCode);
            string Recepient = email + "," + "syed.adnanahmed@live.com,bssit.11.6@gmail.com,usman.saleem@ebm.com.pk,";
            Recepient += (new ClaimApprovalBusiness()).GetWorkFlowEmails("", "0", CustomerCode.ToString());


            if (Recepient[Recepient.Length - 1] == ',')
                Recepient = Recepient.Substring(0, Recepient.Length - 1);

            if (Message != null)
            {
                //SendOrderEmail(Recepient, "A Special Order is waiting for your approval. </br> <b>Customer Code:</b> " + customerCode, message[1], sp[0].SP_Order_ID);
                emailSender es = new emailSender();
                string EmailBody = "Claim is generated </br></br> <b>Customer Code:</b> " + CustomerCode;
                es.ClaimApproval(Recepient, EmailBody);
                RoleController RC = new RoleController();
                RC.InsertAuditingLogWithRef("Generating Claim Against Bill Number", "GeneratingClaimAgainstBillNumber", "GeneratingClaimAgainstBillNumber", "GeneratingClaimAgainstBillNumber", "", (int)Session["User_ID"], Message[3]);
            }
            return Json(Message[0]);
        }
       
        [HttpGet]
        public JsonResult GetAllpendingByBillingNo()
        {
            string CustomerCode = Session["Customer"].ToString();
            string SalesOrg = Session["SalesOrg"].ToString();

            ClaimPortalBusiness claimorderrefnum = new ClaimPortalBusiness();
            List<Billing> List = claimorderrefnum.GetBillingNoForClaim(CustomerCode, SalesOrg).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetAllpendingRecord(string refrence)
        {
            string SalesOrg = Session["SalesOrg"].ToString();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Pending Claim Records Against Bill Number", "GettingPendingClaimsRecords", "GettingPendingClaimsRecords", "GettingPendingClaimsRecords", "", (int)Session["User_ID"]);

            ClaimPortalBusiness claimorderrefnum = new ClaimPortalBusiness();
            List<WeekWiseOrder> list = claimorderrefnum.GetAllPendingOrder_ForClaim(refrence, SalesOrg).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddManualFile()
        {
            string message = "";
            List<pendingQuantities> dataToPost = JsonConvert.DeserializeObject<List<pendingQuantities>>(Request["dataToPost"]);
            string CustomerCode = Session["Customer"].ToString();

            ManualBusiness weekWiseBusiness = new ManualBusiness();

            if (dataToPost.Count() > 0)
            {

                var refno = dataToPost.FirstOrDefault().Order_Ref;
                var billingno = dataToPost.FirstOrDefault().BillingId;


                var day = dataToPost.FirstOrDefault().day;
                var filesave = "";
                string RelativefName = "";
                string fname = "";
                if (Request.Files.Count > 0)
                {
                    try
                    {
                        //  Get all files from Request object  
                        HttpFileCollectionBase files = Request.Files;
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase file = files[i];


                            // Checking for Internet Explorer  
                            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                            {
                                string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                fname = testfiles[testfiles.Length - 1];
                            }
                            else
                            {
                                fname = file.FileName;
                            }

                            // Get the complete folder path and store the file inside it. 
                            fname = refno.Replace('/', '_') + "_" + fname;
                            filesave = fname;
                            string Absolutefname = Path.Combine(Server.MapPath("~/Upload/CL/"), fname);
                            file.SaveAs(Absolutefname);
                        }
                        RelativefName = Path.Combine("/Upload/CL/", fname);
                        weekWiseBusiness.AddManualClaimFile(refno, filesave, RelativefName, day, billingno);

                        RoleController RC = new RoleController();
                        RC.InsertAuditingLog("Attach File against Claim with Refrence to Bill", "FileAttachAgainstClaimReferenceToBill", "FileAttachAgainstClaimReferenceToBill", "FileAttachAgainstClaimReferenceToBill", "", (int)Session["User_ID"]);

                    }
                    catch (Exception ex)
                    {
                        RoleController rc = new RoleController();
                        rc.InsertAuditingLog("Error In File Attachmnet Against Bill", "ErrorFileAttachAgainstClaimReferenceToBill", "ErrorFileAttachAgainstClaimReferenceToBill", "ErrorFileAttachAgainstClaimReferenceToBill", ex.Message, (int)Session["User_ID"]);
                        return Json("Error occurred. Error details: " + ex.Message);
                    }
                }
                else
                {
                    weekWiseBusiness.AddManualClaimFile(refno, filesave, RelativefName, day, billingno);

                    RoleController RC = new RoleController();
                    RC.InsertAuditingLog("Claim Against Bill without File", "ClaimAgainstBIllWithoutFile", "ClaimAgainstBIllWithoutFile", "ClaimAgainstBIllWithoutFile", "", (int)Session["User_ID"]);

                }

            }
            return Json(message);

        }

        public ActionResult ViewAllClaims()
        {
            return View();
        }

        public JsonResult GetAllClaimRefRecord()
        {
            string CustomerCode = Session["Customer"].ToString();
            string SalesOrg = Session["SalesOrg"].ToString();
            string Division = Session["Division"].ToString();
            ClaimPortalBusiness claimorderrefnum = new ClaimPortalBusiness();
            List<pendingQuantities> List = claimorderrefnum.GetClaimsOrderRef(CustomerCode, SalesOrg, Division).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetAllClaimRecord(string refrence, string ClaimRefNum)
        {
            ClaimPortalBusiness claimorderrefnum = new ClaimPortalBusiness();
            List<pendingQuantities> list = claimorderrefnum.GetAllClaimWithApproval(refrence, ClaimRefNum).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        
        public bool SendClaimEmail(string receiver, string subject, string FirstName, string RefNo)
        {
            try
            {
                string Body = @"<table border=""0"" width=""100 %""><tbody><tr><td align=""center""><table style=""display: table; max-width:550px; min-width:550px; text-align:center"">
                                <tbody><tr><td align=""center"">< img src =""http://www.ebm.com.pk/wp-content/themes/ebm/images/logo.png"" ></td></tr><tr><td style=""color: #000000; font-family: Arial, sans-serif, 'Open Sans'; font-size: 16px; line-height: 18px; text-align: left"">
                                <br/><br/><b> Dear " + FirstName + " </ b ></td></tr><tr><td style="+"color: #000000; font-family: Arial, sans-serif, 'Open Sans'; font-size: 16px; line-height: 24px; text-align: left"+">Claim reference # <b><a href="+"#"+" target="+"_blank"+">" + RefNo + "</a></b> is pending at your end for claim approval</td></tr></tbody></table></td></tr></tbody></table>";

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
                RC.InsertAuditingLog("Email", "File Uploading", "UploadFiles", "UploadFiles", "", (int)Session["User_ID"]);
                return true;
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Some Error";
                return false;
            }
        }
    }
}