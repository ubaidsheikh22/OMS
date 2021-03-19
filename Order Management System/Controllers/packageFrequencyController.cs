using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class packageFrequencyController : Controller
    {

        // GET: packageFrequency
        public ActionResult packageFrequency()
        {
            return View();
        }

        [HttpPost]
        public JsonResult addpackageFrequency(string packageName, string customerCode, string monday, string tuesday, string wednesday, string thursday, string friday, string saturday, string sunday)
        {
            packageFrequencyBusiness pfb = new packageFrequencyBusiness();
            DataTable dt = new DataTable();
            dt.Columns.Add("DayFrequency");
            dt.Columns.Add("customerCode");
            dt.Columns.Add("packageID");
            dt.Columns.Add("DateTime");
            dt.Columns.Add("monday");
            dt.Columns.Add("tuesday");
            dt.Columns.Add("wednesday");
            dt.Columns.Add("thursday");
            dt.Columns.Add("friday");
            dt.Columns.Add("saturday");
            dt.Columns.Add("sunday");
            var CustomerCode = customerCode.Split(',');
            //int i = 0;
            foreach (string code in CustomerCode)
            {
                // i++;
                dt.Rows.Add("", code, packageName, "", monday, tuesday, wednesday, thursday, friday, saturday, sunday);

            }

            //for (int i = 0; i <= fields.Length; i++)
            //{
            //    dt.Rows.Add("123", customerCode[i], packageID, "", monday, tuesday, wednesday, thursday, friday, saturday, sunday);

            //}
            string message = pfb.addPackageFrequency(dt);
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Add Package Frequency", "Add Package Frequency", "addpackageFrequency", "addpackageFrequency", "", (int)Session["User_ID"]);
            return Json(message);
        }


        [HttpPost]
        public JsonResult UpdatePackageFrequency(int PackageFrequencyID, string packageName, string customerCode, string monday, string tuesday, string wednesday, string thursday, string friday, string saturday, string sunday)
        {
            packageFrequencyBusiness pfb = new packageFrequencyBusiness();
            DataTable dt = new DataTable();
            dt.Columns.Add("PackageFrequencyID");
            dt.Columns.Add("packageID");
            dt.Columns.Add("customerCode");
            dt.Columns.Add("DateTime");
            dt.Columns.Add("monday");
            dt.Columns.Add("tuesday");  
            dt.Columns.Add("wednesday");
            dt.Columns.Add("thursday");
            dt.Columns.Add("friday");
            dt.Columns.Add("saturday");
            dt.Columns.Add("sunday");
            var CustomerCode = customerCode.Split(',');
            // int i = 0;
            foreach (string code in CustomerCode)
            {

                dt.Rows.Add("", code, packageName, "", monday, tuesday, wednesday, thursday, friday, saturday, sunday);

            }

            //for (int i = 0; i <= fields.Length; i++)
            //{
            //    dt.Rows.Add("123", customerCode[i], packageID, "", monday, tuesday, wednesday, thursday, friday, saturday, sunday);

            //}
            string message = pfb.addPackageFrequency(dt);
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Updating Package Frequency", "Updating Package Frequency", "UpdatePackageFrequency", "UpdatePackageFrequency", "", (int)Session["User_ID"]);
            return Json(message);
        }

        [HttpGet]
        public JsonResult getAllPackages()
        {
            packageFrequencyBusiness PFB = new packageFrequencyBusiness();
            List<PackageModel> PR = PFB.getAllPackages.ToList();
            return Json(PR, JsonRequestBehavior.AllowGet);
        }

        public JsonResult gridView()
        {
         
            packageFrequencyBusiness PF = new packageFrequencyBusiness();
            List<packageFrequencyModel> d = PF.gridViewPackageFrequency.ToList();
            return Json(d, JsonRequestBehavior.AllowGet);
          

        }

        [HttpGet]
        public JsonResult getAllCustomers()
        {
            packageFrequencyBusiness PFB = new packageFrequencyBusiness();
            List<CustomerModel> PR = PFB.getAllCustomer.ToList();
            return Json(PR, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getRegions()
        {

            LoginBusiness LoginBusiness = new LoginBusiness();
            List<Login> list = LoginBusiness.getRegionDetails().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getAllArea(string regionCode)
        {
            LoginBusiness db = new LoginBusiness();
            List<Login> PR = db.getAllArea(regionCode).ToList();

            return Json(PR, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getAllTerritory(string AreaCode)
        {
            LoginBusiness db = new LoginBusiness();
            List<Login> PR = db.getAllTerritory(AreaCode).ToList();

            return Json(PR, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getAllTown(string TerritoryCode)
        {
            LoginBusiness db = new LoginBusiness();
            List<Login> PR = db.getAllTown(TerritoryCode).ToList();

            return Json(PR, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPackage(string Customer)
        {
            packageFrequencyBusiness db = new packageFrequencyBusiness();
            List<Login> PR = db.getAllPackagesForCustomer(Customer).ToList();

            return Json(PR, JsonRequestBehavior.AllowGet);
        }

    }
}