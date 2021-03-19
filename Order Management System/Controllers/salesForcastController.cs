using BusinessLayer.Models;
using BusinessLayer.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Order_Management_System.Controllers
{
    public class salesForcastController : Controller
    {
        // GET: salesForcast
        public ActionResult salesForcast()
        {
            Experoment();
            return View();
        }

        [HttpGet]
        public JsonResult CustomerSales()
        {
              salesForcastBusiness SFB = new salesForcastBusiness();

            List<salesForcastModel> r = SFB.GetDropDownCustomer.ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult Experoment(int Customer=100000)
        {

            return Json(true, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GetRSF(int Role_ID)
        {
            RoleBusiness RBb = new RoleBusiness();
          

            List<DistributorModel> r = RBb.GetAllDistributotRecords.ToList();
            var distributorName = (from N in r
                                   where N.Role_ID.Equals(Role_ID)
                                   select new { N.Distributor_ID, N.Distributor_Name });
      

            return Json(distributorName, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult gridView(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)

        {
            if (string.IsNullOrEmpty(customer) || customer == "null")
                customer = Session["Distributor_ID"].ToString();

            if (string.IsNullOrEmpty(sales) || sales == "null")
                sales = Session["SalesOrg"].ToString();

            if (string.IsNullOrEmpty(div) || div == "null")
                div = Session["Division"].ToString();
            salesForcastBusiness SFB = new salesForcastBusiness();
            List<salesForcastModel> salesForcastModel = SFB.gridViewsalesForcast(CALDAY, company, sales, distr, div, plant, customer, material, ZDOC_CATG, ZBPCACC, ZBPCVERS, qty).ToList();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting SalesForcast Master View", "Getting SalesForcast Master View", "GettingSalesForcastMasterView", "GettingSalesForcastMasterView", "", (int)Session["User_ID"]);

            var json = Json(salesForcastModel, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;

        
        }

        [HttpGet]
        public JsonResult GetCalDay(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {

            salesForcastBusiness SFB = new salesForcastBusiness();

            List<salesForcastModel> r = SFB.getCalday(CALDAY, company, sales, distr, div, plant, customer, material, ZDOC_CATG, ZBPCACC, ZBPCVERS, qty).ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSales(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            sales = string.IsNullOrEmpty(sales) || sales == "null" ? Session["SalesOrg"].ToString() : sales;
            salesForcastBusiness SFB = new salesForcastBusiness();

            List<salesForcastModel> r = SFB.getSalesOrg(CALDAY, company, sales, distr, div, plant, customer, material, ZDOC_CATG, ZBPCACC, ZBPCVERS, qty).ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetComp(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            company = string.IsNullOrEmpty(company) || company == "null" ? Session["SalesOrg"].ToString() : company;
            salesForcastBusiness SFB = new salesForcastBusiness();

            List<salesForcastModel> r = SFB.getCompCode(CALDAY, company, sales, distr, div, plant, customer, material, ZDOC_CATG, ZBPCACC, ZBPCVERS, qty).ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getDistr(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            company = string.IsNullOrEmpty(company) || company == "null" ? Session["SalesOrg"].ToString() : company;
            customer = string.IsNullOrEmpty(customer) || customer == "null" ? "0000" + Session["Distributor_ID"].ToString() : "0000" + customer;
            salesForcastBusiness SFB = new salesForcastBusiness();
            List<salesForcastModel> r = SFB.getDistr(CALDAY, company, sales, distr, div, plant, customer, material, ZDOC_CATG, ZBPCACC, ZBPCVERS, qty).ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getDivision(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            div = string.IsNullOrEmpty(div) || div == "null" ? Session["Division"].ToString() : div;
            salesForcastBusiness SFB = new salesForcastBusiness();
            List<salesForcastModel> r = SFB.getDivision(CALDAY, company, sales, distr, div, plant, customer, material, ZDOC_CATG, ZBPCACC, ZBPCVERS, qty).ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getPlant(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            company = string.IsNullOrEmpty(company) || company == "null" ? Session["SalesOrg"].ToString() : company;
            customer = string.IsNullOrEmpty(customer) || customer == "null" ? "0000" + Session["Distributor_ID"].ToString() : "0000"+ customer;
            //div = string.IsNullOrEmpty(div) || div == "null" ? Session["Division"].ToString() : div;
            salesForcastBusiness SFB = new salesForcastBusiness();

            List<salesForcastModel> r = SFB.getPlant(CALDAY, company, sales, distr, div, plant, customer, material, ZDOC_CATG, ZBPCACC, ZBPCVERS, qty).ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getCustomer(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            customer = string.IsNullOrEmpty(customer) || customer == "null" ? Session["Distributor_ID"].ToString() : customer;
            salesForcastBusiness SFB = new salesForcastBusiness();
            List<salesForcastModel> r = SFB.getCustomer(CALDAY, company, sales, distr, div, plant, customer, material, ZDOC_CATG, ZBPCACC, ZBPCVERS, qty).ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getMaterial(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {

            salesForcastBusiness SFB = new salesForcastBusiness();

            List<salesForcastModel> r = SFB.getMaterial(CALDAY, company, sales, distr, div, plant, customer, material, ZDOC_CATG, ZBPCACC, ZBPCVERS, qty).ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCompCode(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            salesForcastBusiness SFB = new salesForcastBusiness();

            List<salesForcastModel> r = SFB.getCompCode(CALDAY, company, sales, distr, div, plant, customer, material, ZDOC_CATG, ZBPCACC, ZBPCVERS, qty).ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }
    }
}