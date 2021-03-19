using BusinessLayer.Models;
using BusinessLayer.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class Customer_SKU_weekly_orderController : Controller
    {
        // GET: Customer_SKU_weekly_order
        public ActionResult Customer_SKUwise_weekly_order()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetBillingNo(string SapOrderNoSunday)
        {
            string CustomerCode = Session["Customer"].ToString();
            weekWiseBusiness repository = new weekWiseBusiness();
            List<Billing> list = repository.GetBillingNo(CustomerCode, SapOrderNoSunday);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult gridView(string day, string BillingNo)
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Stock Receiving View by Dist.", "GettingCustomerReceivingStock", "GettingCustomerReceivingStock", "GettingCustomerReceivingStock", "", (int)Session["User_ID"]);
            string CustomerCode = Session["Customer"].ToString();
            weekWiseBusiness weekWiseBusiness = new weekWiseBusiness();
            List<WeekWiseOrder> List = weekWiseBusiness.getRecordToGrid(day, CustomerCode, BillingNo).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult claimComments()
        {
            weekWiseBusiness weekWiseBusiness = new weekWiseBusiness();

            List<claimCommentsModel> List = weekWiseBusiness.GetDropDownClaimsComments.ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddPendingOrders()
        {
            List<pendingQuantities> dataToPost = JsonConvert.DeserializeObject<List<pendingQuantities>>(Request["dataToPost"]);
            string CustomerCode = Session["Customer"].ToString();
            //  int Position =Convert.ToInt32(Session["Position"]);

            weekWiseBusiness weekWiseBusiness = new weekWiseBusiness();
            string message = weekWiseBusiness.AddPendingOrderRecord(dataToPost, CustomerCode);
            //string Message = "";
            if (dataToPost.Count() > 0)
            {
                var refno = dataToPost.FirstOrDefault().Order_Ref;
                var billingID = dataToPost.FirstOrDefault().BillingId;
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
                            string Absolutefname = Path.Combine(Server.MapPath("~/Upload/ApprovedFiles/"), fname);
                            file.SaveAs(Absolutefname);
                        }
                        RelativefName = Path.Combine("/Upload/ApprovedFiles/", fname);
                        weekWiseBusiness.AddPendingOrderRecordFile(refno, filesave, RelativefName, day, billingID);

                        RoleController RC = new RoleController();
                        RC.InsertAuditingLog("Uploading Stock Receiving File by Dist.", "UploadingStockReceivingFile", "UploadingStockReceivingFile", "UploadingStockReceivingFile", "", (int)Session["User_ID"]);

                    }
                    catch (Exception ex)
                    {
                        RoleController rc = new RoleController();
                        rc.InsertAuditingLog("Error Uploading Stock Receiving File by Dist.", "ErrorUploadingStockReceivingFile", "ErrorUploadingStockReceivingFile", "ErrorUploadingStockReceivingFile", ex.Message, (int)Session["User_ID"]);
                        return Json("Error occurred. Error details: " + ex.Message);
                    }
                }
                else {
                    weekWiseBusiness.AddPendingOrderRecordFile(refno, filesave, RelativefName, day, billingID);

                    RoleController RC = new RoleController();
                    RC.InsertAuditingLog("Stock Receiving Without File by Dist.", "StockReceivingWithoutFiles", "StockReceivingWithoutFiles", "StockReceivingWithoutFiles", "", (int)Session["User_ID"]);

                }

            }
            return Json(message);

        }
    }
}