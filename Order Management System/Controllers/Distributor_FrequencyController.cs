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
    public class Distributor_FrequencyController : Controller
    {
        // GET: OrderGeneratednew
        public ActionResult Distributor_Frequency()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetAllGeneratedOrders()
        {


            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Generated Order For Frequency", "GettingGeneratedOrderForFrequency", "GettingGeneratedOrderForFrequency", "GettingGeneratedOrderForFrequency", "", (int)Session["User_ID"]);

            string AreaCode = Session["AreaCode"].ToString();
            string TerritoryCode = Session["TerritoryCode"].ToString();
            string TownCode = Session["TownCode"].ToString();
            string RegionCode = Session["RegionCode"].ToString();
            
            DistributorFrequency DistributorFrequency = new DistributorFrequency();
            List<CustomerModel> List = DistributorFrequency.GetAllCustomer(AreaCode, TerritoryCode, TownCode,RegionCode).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);

         
        }

        [HttpPost]
        public string InsertFrequency(List<distributorFrequencyModel> DistributorList)
        {
            DataTable dt = new DataTable();
            DistributorFrequency DistributorFrequency = new DistributorFrequency();
            dt.Columns.Add("Monday");
            dt.Columns.Add("Tuesday");
            dt.Columns.Add("Wednesday");
            dt.Columns.Add("Thursday");
            dt.Columns.Add("Friday");
            dt.Columns.Add("Saturday");
            dt.Columns.Add("Sunday");
            dt.Columns.Add("Customer");
            dt.Columns.Add("Name1");
            dt.Columns.Add("Division");
            dt.Columns.Add("RegionDescription");
            dt.Columns.Add("SalesOrganization");

            foreach (var items in DistributorList)
            {
                dt.Rows.Add(items.Monday, 
                    items.Tuesday, 
                    items.Wednesday, 
                    items.Thursday, 
                    items.Friday, 
                    items.Saturday, 
                    items.Sunday,
                    items.Customer, 
                    items.Name1, 
                    items.Division, 
                    items.RegionDescription, 
                    items.SalesOrganization);
            }

            string Message = DistributorFrequency.addDistributorFrequency(dt).ToString();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Adding Day Frequency", "AddingDayFrequency", "AddingDayFrequency", "AddingDayFrequency", "", (int)Session["User_ID"]);
            return Message;
        }
    }
}