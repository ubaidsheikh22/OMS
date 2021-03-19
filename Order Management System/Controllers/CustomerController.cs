using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Repository;
using BusinessLayer.Models;
using System.Data;
using System.Data.SqlClient;

namespace Order_Management_System.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Customer()
        {
            return View();
        }

        public JsonResult GetAllCustomer()
        {
            CustomerBusiness customer = new CustomerBusiness();
            List<CustomerModel> cm = customer.GetAllCustomer.ToList();
            return Json(cm, JsonRequestBehavior.AllowGet);
        }

  
        [HttpPost]

        public JsonResult GetAllCustomerRecords(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Customer Record", "GettingCustomer", "GettingCustomer", "GettingCustomer", "", (int)Session["User_ID"]);

            if (string.IsNullOrEmpty(sales) || sales == "null")
                sales = Session["SalesOrg"].ToString();

            if (string.IsNullOrEmpty(div) || div == "null")
                div = Session["Division"].ToString();

            if (string.IsNullOrEmpty(name) || name == "null")
                name = Session["Distributor_ID"].ToString();

            string Name = string.Empty;
            CustomerBusiness EML = new CustomerBusiness();
            List<CustomerModel> emp = EML.GetAllCustomerRecords2(name, sales, div, category, region, area, territory, town, plant).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetCustomerName(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            if (string.IsNullOrEmpty(sales) || sales == "null")
                sales = Session["SalesOrg"].ToString();

            if (string.IsNullOrEmpty(div) || div == "null")
                div = Session["Division"].ToString();

            if (string.IsNullOrEmpty(name) || name == "null")
                name = Session["Distributor_ID"].ToString();

            CustomerBusiness EML = new CustomerBusiness();
            
            List<CustomerModel> emp = EML.GetCustomer(name, sales, div, category, region, area, territory, town, plant).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetSalesOrg(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            if (string.IsNullOrEmpty(sales) || sales == "null")
                sales = Session["SalesOrg"].ToString();

            CustomerBusiness EML = new CustomerBusiness();

            List<CustomerModel> emp = EML.GetSalesOrg(name, sales, div, category, region, area, territory, town, plant).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetDivision(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            if (string.IsNullOrEmpty(div) || div == "null")
                div = Session["Division"].ToString();

            CustomerBusiness EML = new CustomerBusiness();
            List<CustomerModel> emp = EML.GetDivision(name, sales, div, category, region, area, territory, town, plant).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult GetCategory(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {

            CustomerBusiness EML = new CustomerBusiness();
            List<CustomerModel> emp = EML.GetCategory(name, sales, div, category, region, area, territory, town, plant).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetRegion(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            if (string.IsNullOrEmpty(region) || region == "null")
                region = Session["RegionCode"].ToString();

            if (string.IsNullOrEmpty(name) || name == "null")
                name = Session["Distributor_ID"].ToString();

            CustomerBusiness EML = new CustomerBusiness();

            List<CustomerModel> emp = EML.GetRegion(name, sales, div, category, region, area, territory, town, plant).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetArea(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            if (string.IsNullOrEmpty(area) || area == "null")
                area = Session["AreaCode"].ToString();

                CustomerBusiness EML = new CustomerBusiness();
            List<CustomerModel> emp = EML.GetArea(name, sales, div, category, region, area, territory, town, plant).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult GetTerritory(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            if (string.IsNullOrEmpty(area) || territory == "null")
                territory = Session["TerritoryCode"].ToString();

            CustomerBusiness EML = new CustomerBusiness();

            List<CustomerModel> emp = EML.GetTerritory(name, sales, div, category, region, area, territory, town, plant).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult GetTown(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            if (string.IsNullOrEmpty(town) || town == "null")
                town = Session["TownCode"].ToString();
            
            CustomerBusiness EML = new CustomerBusiness();
            List<CustomerModel> emp = EML.GetTown(name, sales, div, category, region, area, territory, town, plant).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetPlant(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {

            CustomerBusiness EML = new CustomerBusiness();
            List<CustomerModel> emp = EML.GetPlant(name, sales, div, category, region, area, territory, town, plant).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }
    }
}