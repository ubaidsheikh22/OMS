using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Models;
using BusinessLayer.Repository;
using System.IO;

namespace Order_Management_System.Controllers
{
    public class AddManualClaimsController : Controller
    {
        // GET: AddManualClaims
        public ActionResult AddManualClaim()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CreateClaim(pendingQuantities dataToPost)
        {
            string email = Session["UserEmail"].ToString();
            string CustomerCode = Session["Customer"].ToString();
            ManualBusiness mb = new ManualBusiness();
            string Message = mb.AddManualClaim(dataToPost, CustomerCode);
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
                RC.InsertAuditingLog("Manual Claim", "creating Manual claim", "ManualClaim", "CreateManualClaim", "", (int)Session["User_ID"]);
            }
            return Json(Message[0]);
        }
        public JsonResult GEtmanualClaimList()
        {
            string CustomerCode = Session["Customer"].ToString();
            ManualBusiness DB = new ManualBusiness();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("General", "Getting All Manual Claims", "GettingManualClaims", "GettingManualClaims", "", (int)Session["User_ID"]);
            List<pendingQuantities> d = DB.GetAllManualClaims(CustomerCode).ToList();
            return Json(d, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddManualFile()
        {
            string message = "";
            List<pendingQuantities> dataToPost = JsonConvert.DeserializeObject<List<pendingQuantities>>(Request["dataToPost"]);
            string CustomerCode = Session["Customer"].ToString();
         
            ManualBusiness weekWiseBusiness = new ManualBusiness();
          
            if (dataToPost.Count() > 0)
            {
              
                var refno = CustomerCode + dataToPost.FirstOrDefault().salesOrganization + dataToPost.FirstOrDefault().division + System.DateTime.Today.ToString("yyyy-mm-dd")+"/MCL";
                var billingno = 0;
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
                            string Absolutefname = Path.Combine(Server.MapPath("~/Upload/MCL/"), fname);
                            file.SaveAs(Absolutefname);
                        }
                        RelativefName = Path.Combine("/Upload/MCL/", fname);
                        weekWiseBusiness.AddManualClaimFile(refno, filesave, RelativefName, day, billingno);

                        RoleController RC = new RoleController();
                        RC.InsertAuditingLog("Manual Claim", "Adding Manual Claim Attachment", "AddManualClaimAttachment", "AddMAnualClaimAttachment", "", (int)Session["User_ID"]);

                    }
                    catch (Exception ex)
                    {
                        RoleController rc = new RoleController();
                        rc.InsertAuditingLog("Manual Claim Error", "Adding Manual Claim Attachment Error", "AddManualClaimAttachmentError", "AddMAnualClaimAttachmentError", ex.Message, (int)Session["User_ID"]);
                        return Json("Error occurred. Error details: " + ex.Message);
                    }
                }
                else
                {
                    RoleController RC = new RoleController();
                    RC.InsertAuditingLog("Manual Claim", "Adding Manual Claim Without File", "AddingManualClaimWithoutFile", "AddingManualClaimWithoutFile", "", (int)Session["User_ID"]);

                    weekWiseBusiness.AddManualClaimFile(refno, filesave, RelativefName, day, billingno);

                    
                }

            }
            return Json(message);

        }

        public JsonResult GetMaterials()
        {
            string SalesOrganization = Session["SalesOrg"].ToString();
            string Division = Session["Division"].ToString();
            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetMaterialsForManualClaim(null, SalesOrganization, null, null, null, null, null, null, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }

    }


}