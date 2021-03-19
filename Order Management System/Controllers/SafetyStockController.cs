using BusinessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Repository;
using System.Data.SqlClient;

namespace Order_Management_System.Controllers
{
    public class SafetyStockController : Controller
    {
        // GET: SafetyStock
        public ActionResult SafetyStock()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImportData(List<SafetyStockModel> SafetyStockModel)
        {
            //List<SafetyStockModel> dataToPost = JsonConvert.DeserializeObject<List<SafetyStockModel>>(Request["SafetyStockModel"]);
            //SaveToPhysicalLocation();
            UploadFiles();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Importing Safety Stock", "Importing Safety Stock", "ImportingSafetyStock", "ImportingSafetyStock", "", (int)Session["User_ID"]);

            return Json(true, JsonRequestBehavior.AllowGet);

        }

        //[HttpPost]
        //public ActionResult ImportData(List<SafetyStockModel> studentList)
        //{
        //   //SaveToPhysicalLocation();
        //    UploadFiles();
        //    return Json(studentList, JsonRequestBehavior.AllowGet);

        //}
        private string SaveToPhysicalLocation(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string CrntDate = DateTime.Now.ToString("dd-MM-yyyyhh-mm-ss");
                var fileName = Path.GetFileName(CrntDate + file.FileName);
                var path = Path.Combine(Server.MapPath("~/Upload/"), fileName);
                file.SaveAs(path);
                return fileName;
            }
            return string.Empty;
        }

        [HttpPost]
        public JsonResult UploadFiles()
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

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
                        fname = Path.Combine(Server.MapPath("~/Upload/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            try
            {


                string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //Excel 97-03.
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //Excel 07 and above.
                            conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                            break;
                    }

                    DataTable dt = new DataTable();
                    conString = string.Format(conString, filePath);

                    using (OleDbConnection connExcel = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmdExcel = new OleDbCommand())
                        {
                            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                            {
                                cmdExcel.Connection = connExcel;

                                //Get the name of First Sheet.
                                connExcel.Open();
                                DataTable dtExcelSchema;
                                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                connExcel.Close();

                                //Read Data from First Sheet.
                                connExcel.Open();
                                cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                                odaExcel.SelectCommand = cmdExcel;
                                odaExcel.Fill(dt);
                                connExcel.Close();
                            }
                        }
                    }

                    conString = ConfigurationManager.ConnectionStrings["OMSContext"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        con.Open();
                        string var = "Truncate Table dbo.tbl_customer_stock;";
                        SqlCommand truncate = new SqlCommand(var, con);
                        truncate.ExecuteNonQuery();


                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {

                            //Set the database table name.
                            sqlBulkCopy.DestinationTableName = "dbo.tbl_Customer_Stock";

                            //[OPTIONAL]: Map the Excel columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add("customer", "customer");
                            sqlBulkCopy.ColumnMappings.Add("material", "material");
                            sqlBulkCopy.ColumnMappings.Add("division", "division");

                            sqlBulkCopy.ColumnMappings.Add("salesOrg", "salesOrg");
                            sqlBulkCopy.ColumnMappings.Add("distr_chan", "distr_chan");
                            sqlBulkCopy.ColumnMappings.Add("region", "region");

                            sqlBulkCopy.ColumnMappings.Add("area", "area");
                            sqlBulkCopy.ColumnMappings.Add("territory", "territory");
                            sqlBulkCopy.ColumnMappings.Add("town", "town");
                            sqlBulkCopy.ColumnMappings.Add("quantity", "quantity");
                            //con.Open();
                            sqlBulkCopy.WriteToServer(dt);
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            //TempData["Message"] = "Safety Stock Inserted Successfully";
            string msg = "Safety Stock Inserted Successfully";
            ViewBag.Message = msg;

            return RedirectToAction("SafetyStock", "SafetyStock", ViewBag);
            
        }


        public JsonResult gridView()
        {
         
            SafetyStockBusiness DB = new SafetyStockBusiness();
            List<SafetyStockModel> d = DB.GetAllCustomerSafetyStock.ToList();
            return new JsonResult() { Data = d, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
         
        }


        [HttpPost]
        public ActionResult updateStock(string customer, string quantity, string salesOrg, string distr_chan, string material)
        {
            SafetyStockBusiness SSB = new SafetyStockBusiness();
            SafetyStockModel stock = new SafetyStockModel()
            {
                customer = customer,
                quantity = quantity,
                salesOrg = salesOrg,
                distr_chan = distr_chan,
                material = material
            };
           
            string message = SSB.updateStock(stock);
            return Json(message);
        }


    }
}



