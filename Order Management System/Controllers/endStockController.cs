using BusinessLayer.Repository;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Order_Management_System.Controllers
{
    public class endStockController : Controller
    {
        // GET: endStock
        public ActionResult endStock()
        {
            endSTockBusiness MMB = new endSTockBusiness();
            string Material = "", salesOrg = Session["SalesOrg"].ToString(), RegionCode = Session["RegionCode"].ToString(), AreaCode = Session["AreaCode"].ToString(),
                TerritoryCode = Session["TerritoryCode"].ToString(), TownCode = Session["TownCode"].ToString(), customer = Session["Distributor_ID"].ToString(), division = Session["Division"].ToString();
            var data = new
            {
                Material = MMB.GetmATERIAL(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                salesOrg = MMB.GetSales(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                RegionCode = MMB.GetARegion(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                AreaCode = MMB.GetAreaa(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                TerritoryCode = MMB.GetTerriotory(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                TownCode = MMB.GetTown(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                Customer = MMB.GetCustomer(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                division = MMB.GetDivision(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList()
            };
            ViewBag.JSONData = new JavaScriptSerializer().Serialize(data); // Json(data, JsonRequestBehavior.AllowGet);
            var output = MMB.gridViewEndStock(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList();
            var outputJsonResult = Json(output, JsonRequestBehavior.AllowGet);
            outputJsonResult.MaxJsonLength = 10 * 1024 * 1024; // 10 MB
            ViewBag.AllData = outputJsonResult;
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Opening EndStock Master View", "OpeningEndStockMasterRecord", "OpeningEndStockMasterRecord", "OpeningEndStockMasterRecord", "", (int)Session["User_ID"]);

            return View();
        }

        [HttpGet]
        public JsonResult getAllCustomers()
        {
            packageFrequencyBusiness PFB = new packageFrequencyBusiness();
            List<CustomerModel> PR = PFB.getAllCustomer.ToList();
            return Json(PR, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getAllDDL(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string customer, string division)
         {
            salesOrg = string.IsNullOrEmpty(salesOrg) || salesOrg == "null" ? Session["SalesOrg"].ToString() : salesOrg;
            RegionCode = string.IsNullOrEmpty(RegionCode) || RegionCode == "null" ? Session["RegionCode"].ToString() : RegionCode;
            AreaCode = string.IsNullOrEmpty(AreaCode) || AreaCode == "null" ? Session["AreaCode"].ToString() : AreaCode;
            TerritoryCode = string.IsNullOrEmpty(TerritoryCode) || TerritoryCode == "null" ? Session["TerritoryCode"].ToString() : TerritoryCode;
            TownCode = string.IsNullOrEmpty(TownCode) || TownCode == "null" ? Session["TownCode"].ToString() : TownCode;
            customer = string.IsNullOrEmpty(customer) || customer == "null" ? Session["Distributor_ID"].ToString() : customer;
            division = string.IsNullOrEmpty(division) || division == "null" ? Session["Division"].ToString() : division;

            endSTockBusiness MMB = new endSTockBusiness();
            var data = new
            {
                Material = MMB.GetmATERIAL(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                salesOrg = MMB.GetSales(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                RegionCode = MMB.GetARegion(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                AreaCode = MMB.GetAreaa(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                TerritoryCode = MMB.GetTerriotory(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                TownCode = MMB.GetTown(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                Customer = MMB.GetCustomer(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList(),
                division = MMB.GetDivision(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList()
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult gridView(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string customer, string division)
        {
            salesOrg = string.IsNullOrEmpty(salesOrg) || salesOrg == "null" ? Session["SalesOrg"].ToString() : salesOrg;
            RegionCode = string.IsNullOrEmpty(RegionCode) || RegionCode == "null" ? Session["RegionCode"].ToString() : RegionCode;
            AreaCode = string.IsNullOrEmpty(AreaCode) || AreaCode == "null" ? Session["AreaCode"].ToString() : AreaCode;
            TerritoryCode = string.IsNullOrEmpty(TerritoryCode) || TerritoryCode == "null" ? Session["TerritoryCode"].ToString() : TerritoryCode;
            TownCode = string.IsNullOrEmpty(TownCode) || TownCode == "null" ? Session["TownCode"].ToString() : TownCode;
            customer = string.IsNullOrEmpty(customer) || customer == "null" ? Session["Distributor_ID"].ToString() : customer;
            division = string.IsNullOrEmpty(division) || division == "null" ? Session["Division"].ToString() : division;

            endSTockBusiness ESB = new endSTockBusiness();
            List<endSTockModel> endSTockModel = ESB.gridViewEndStock(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting EndStock Master Record", "GettingEndStockMasterRecord", "GettingEndStockMasterRecord", "GettingEndStockMasterRecord", "", (int)Session["User_ID"]);

            var json = Json(endSTockModel, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
        [HttpPost]
        public JsonResult gridViewPaging(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string customer, string division)
        {
            var take = Convert.ToInt32(Request["length"]);
            var skip = Convert.ToInt32(Request["start"]);
            var draw = Convert.ToInt32(Request["draw"]);
            var search = Request["search[value]"];

            salesOrg = string.IsNullOrEmpty(salesOrg) || salesOrg == "null" ? Session["SalesOrg"].ToString() : salesOrg;
            RegionCode = string.IsNullOrEmpty(RegionCode) || RegionCode == "null" ? Session["RegionCode"].ToString() : RegionCode;
            AreaCode = string.IsNullOrEmpty(AreaCode) || AreaCode == "null" ? Session["AreaCode"].ToString() : AreaCode;
            TerritoryCode = string.IsNullOrEmpty(TerritoryCode) || TerritoryCode == "null" ? Session["TerritoryCode"].ToString() : TerritoryCode;
            TownCode = string.IsNullOrEmpty(TownCode) || TownCode == "null" ? Session["TownCode"].ToString() : TownCode;
            customer = string.IsNullOrEmpty(customer) || customer == "null" ? Session["Distributor_ID"].ToString() : customer;
            division = string.IsNullOrEmpty(division) || division == "null" ? Session["Division"].ToString() : division;

            endSTockBusiness ESB = new endSTockBusiness();
            List<endSTockModel> secondarySalesModel = ESB.gridViewEndStock(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, customer, division).ToList();

            //secondarySaleBusiness SSB = new secondarySaleBusiness();
            //List<secondarySalesModel> secondarySalesModel = SSB.gridViewSecondarySales(CALDAY, Comp, salesorg, distr, div, customer, material).ToList();
            var filtered = secondarySalesModel;
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                filtered = filtered.Where(x =>
                                            x.AreaDescription.ToLower().Contains(search) ||
                                            x.CalendarDay.ToLower().Contains(search) ||
                                            x.Company.ToString().Contains(search) ||
                                            x.SalesOrganization.ToString().Contains(search) ||
                                            x.Division.ToString().Contains(search) ||
                                            x.CustomerSoldToParty.ToString().Contains(search) ||
                                            x.CustomerName.ToLower().Contains(search) ||
                                            x.CustomerName2.ToLower().Contains(search) ||
                                            x.RegionDescription.ToLower().Contains(search) ||
                                            x.AreaDescription.ToLower().Contains(search) ||
                                            x.TerritoryDescription.ToLower().Contains(search) ||
                                            x.TownDescription.ToLower().Contains(search) ||
                                            x.Material.ToString().Contains(search) ||
                                            x.MaterialDescription.ToLower().Contains(search) ||
                                            x.MatPricingGrpDescription.ToLower().Contains(search) ||
                                            x.MaterialGroup1_Description.ToLower().Contains(search) ||
                                            x.MaterialGroup2_Description.ToLower().Contains(search) ||
                                            x.MaterialGroup3_Description.ToLower().Contains(search) ||
                                            x.MaterialGroup4_Description.ToLower().Contains(search) ||
                                            x.MaterialGroup5_Description.ToLower().Contains(search) ||
                                            x.MaterialGroupdescription.ToLower().Contains(search) ||
                                            x.UOM.ToLower().Contains(search) ||
                                            x.DistributionChannel.ToString().Contains(search) ||
                                            x.ClosingQuantity.ToString().Contains(search)
                        ).ToList();
            }
            var result = filtered.Skip(skip).Take(take).ToList();
            var obj = new
            {
                draw = draw,
                recordsTotal = secondarySalesModel.Count(),
                recordsFiltered = filtered.Count(),
                data = result
            };
            var json = Json(obj, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        [HttpPost]
        //public JsonResult returnValue()
        //{

        //    var Message = 1;
        //    return Json(Message, JsonRequestBehavior.AllowGet);

        //}
        [HttpGet]
        public JsonResult TotalCount()
        {
            endSTockBusiness ESB = new endSTockBusiness();
            List<endSTockModel> endSTockModel = ESB.TotalEndStock.ToList();
          
            return Json(endSTockModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMaterial(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string Customer, string division)
        {
            endSTockBusiness ESB = new endSTockBusiness();
            List<endSTockModel> endsalesOrg = ESB.GetmATERIAL(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division).ToList();

            return Json(endsalesOrg, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult GetSalesOrg(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string Customer, string division)
        {
            salesOrg = string.IsNullOrEmpty(salesOrg) || salesOrg == "null" ? Session["SalesOrg"].ToString() : salesOrg;
            endSTockBusiness ESB = new endSTockBusiness();
            List<endSTockModel> endsalesOrg = ESB.GetSales(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division).ToList();

            return Json(endsalesOrg, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetRegion(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string Customer, string division)
        {
            RegionCode = string.IsNullOrEmpty(RegionCode) || RegionCode == "null" ? Session["RegionCode"].ToString() : RegionCode;

            endSTockBusiness ESB = new endSTockBusiness();
            List<endSTockModel> endsalesOrg = ESB.GetARegion(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division).ToList();

            return Json(endsalesOrg, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetArea(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string Customer, string division)
        {
            AreaCode = string.IsNullOrEmpty(AreaCode) || AreaCode == "null" ? Session["AreaCode"].ToString() : AreaCode;

            endSTockBusiness ESB = new endSTockBusiness();
            List<endSTockModel> endsalesOrg = ESB.GetAreaa(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division).ToList();

            return Json(endsalesOrg, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetTerritory(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string Customer, string division)
        {
            TerritoryCode = string.IsNullOrEmpty(TerritoryCode) || TerritoryCode == "null" ? Session["TerritoryCode"].ToString() : TerritoryCode;

            endSTockBusiness ESB = new endSTockBusiness();
            List<endSTockModel> endsalesOrg = ESB.GetTerriotory(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division).ToList();

            return Json(endsalesOrg, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetTown(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string Customer, string division)
        {
            TownCode = string.IsNullOrEmpty(TownCode) || TownCode == "null" ? Session["TownCode"].ToString() : TownCode;

            endSTockBusiness ESB = new endSTockBusiness();
            List<endSTockModel> endsalesOrg = ESB.GetTown(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division).ToList();

            return Json(endsalesOrg, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetCustomer(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string Customer, string division)
        {
            Customer = string.IsNullOrEmpty(Customer) || Customer == "null" ? Session["Distributor_ID"].ToString() : Customer;

            endSTockBusiness ESB = new endSTockBusiness();
            List<endSTockModel> endsalesOrg = ESB.GetCustomer(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division).ToList();

            return Json(endsalesOrg, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetDivision(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string Customer, string division)
        {
            division = string.IsNullOrEmpty(division) || division == "null" ? Session["Division"].ToString() : division;

            endSTockBusiness ESB = new endSTockBusiness();
            List<endSTockModel> endsalesOrg = ESB.GetDivision(Material, salesOrg, RegionCode, AreaCode, TerritoryCode, TownCode, Customer, division).ToList();

            return Json(endsalesOrg, JsonRequestBehavior.AllowGet);

        }

    }
}