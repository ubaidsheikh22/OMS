using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BusinessLayer.Models;
using BusinessLayer.Repository;



namespace Order_Management_System.Controllers
{
    public class ViewReportsController : Controller
    {
        class ABC
        {
            public string CUSTOMER { get; set; }
            public string customerName { get; set; }
            public string SALESORG { get; set; }
            public string DIVISION { get; set; }
            public string MATERIAL { get; set; }
            public string materialDesc { get; set; }
            public int Order_Qty { get; set; }
            public double MaterialTotalValues { get; set; }

            public string MaterialGroup { get; set; }
            public string MaterialGroupdescription { get; set; }
        };
        // GET: ViewReports
        public ActionResult OMSGeneratedOrders()
        {
            return View();
        }
        public ActionResult OMSConfirmedOrders()
        {
            return View();
        }
        public ActionResult OMSUnConfirmedOrders()
        {
            return View();
        }
        public ActionResult InTransitOrders() 
        {
            return View();
        }
        public ActionResult DaywiseShipment()
        {
            return View();
        }
        public ActionResult CustomizeOrdersReport()
        {
            return View();
        }

        public ActionResult CustomizeOrdersReportWithRSF()
        {
            return View();
        }
        public ActionResult SpecialOrders() 
        {
            return View();
        }
        public ActionResult RSFAchievement()
        {
            return View();
        }
        public ActionResult RSFAchievementReferenceToFirmOrders()
        {
            return View();
        }
        public ActionResult UnservedOrders()
        {
            return View();
        }
        public ActionResult Toss()
        {
            return View();
        }
        public ActionResult WeekWiseAws()
        {
            return View();
        }
        public ActionResult BillingReport()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getAllCustomer()
        {
            string RegionCode = Session["RegionCode"].ToString();
            string Customer = Session["Distributor_ID"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<CustomerModel> ur = DB.getAllCutomers(RegionCode, Customer, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getAllRegions()
        {
            string RegionCode = Session["RegionCode"].ToString();
            string Customer = Session["Distributor_ID"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<CustomerModel> ur = DB.getAllRegions(RegionCode, Customer, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getAllBrands()
        {
            string RegionCode = Session["RegionCode"].ToString();
        //    string Customer = Session["Distributor_ID"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<materialMasterModel> ur = DB.getAllBrands(RegionCode, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult getAllSKUs()
        {
            string SalesOrg = Session["SalesOrg"].ToString();
            //    string Customer = Session["Distributor_ID"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<materialMasterModel> ur = DB.getAllSKUs(SalesOrg, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getAllSalesOrg()
        {
            string RegionCode = Session["RegionCode"].ToString();
            string Customer = Session["Distributor_ID"].ToString();
            string SalesOrg = Session["SalesOrg"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<CustomerModel> ur = DB.getAllSalesOrg(RegionCode, Customer, SalesOrg, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getAllArea()
        {
            string RegionCode = Session["RegionCode"].ToString();
            string Customer = Session["Distributor_ID"].ToString();
            string SalesOrg = Session["SalesOrg"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<CustomerModel> ur = DB.getAllArea(RegionCode, Customer, SalesOrg, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult getAllTown()
        {
            string RegionCode = Session["RegionCode"].ToString();
            string Customer = Session["Distributor_ID"].ToString();
            string SalesOrg = Session["SalesOrg"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<CustomerModel> ur = DB.getAllTown(RegionCode, Customer, SalesOrg, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getAllTerritory()
        {
            string RegionCode = Session["RegionCode"].ToString();
            string Customer = Session["Distributor_ID"].ToString();
            string SalesOrg = Session["SalesOrg"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<CustomerModel> ur = DB.getAllTerritory(RegionCode, Customer, SalesOrg, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getAllPlant()
        {
            string RegionCode = Session["RegionCode"].ToString();
            string Customer = Session["Distributor_ID"].ToString();
            string SalesOrg = Session["SalesOrg"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<CustomerModel> ur = DB.getAllPlant(RegionCode, Customer, SalesOrg, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult getAllMatgrp1()
        {
            string RegionCode = Session["RegionCode"].ToString();
            //    string Customer = Session["Distributor_ID"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<materialMasterModel> ur = DB.getAllMatgrp1(RegionCode, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getAllMatgrp2()
        {
            string RegionCode = Session["RegionCode"].ToString();
            //    string Customer = Session["Distributor_ID"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<materialMasterModel> ur = DB.getAllMatgrp2(RegionCode, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult getAllMatgrp3()
        {
            string RegionCode = Session["RegionCode"].ToString();
            //    string Customer = Session["Distributor_ID"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<materialMasterModel> ur = DB.getAllMatgrp3(RegionCode, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult getAllMatgrp4()
        {
            string RegionCode = Session["RegionCode"].ToString();
            //    string Customer = Session["Distributor_ID"].ToString();
            string UserId = Session["User_ID"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<materialMasterModel> ur = DB.getAllMatgrp4(RegionCode, UserId).ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCustomizeOrdersReport(string Customer = "-1", string Region = "-1", string Brand = "-1", string SalesOrg = "-1", string Area = "-1", string Town = "-1", string Territory = "-1", string Plant = "-1", string MatGrp1 = "-1", string MatGrp2 = "-1", string MatGrp3 = "-1", string MatGrp4 = "-1", string StartDate = "", string EndDate = "")
        {
            if ((string.IsNullOrEmpty(Customer) || Customer == "null" || Customer == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Customer = Session["Distributor_ID"].ToString();

            if ((string.IsNullOrEmpty(Region) || Region == "null" || Region == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Region = Session["RegionCode"].ToString();

            if ((string.IsNullOrEmpty(SalesOrg) || SalesOrg == "null" || SalesOrg == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                SalesOrg = Session["SalesOrg"].ToString();

            if ((string.IsNullOrEmpty(Area) || Area == "null" || Area == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Area = Session["AreaCode"].ToString();

            if ((string.IsNullOrEmpty(Town) || Town == "null" || Town == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Town = Session["TownCode"].ToString();

            if ((string.IsNullOrEmpty(Territory) || Territory == "null" || Territory == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Territory = Session["TerritoryCode"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<generateOrderModal> OrderModal = DB.CustomizeOrdersReport(Customer, Region, Brand, SalesOrg, Area, Town, Territory, Plant, MatGrp1, MatGrp2, MatGrp3, MatGrp4, StartDate, EndDate);

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Customize Orders Report", "Getting Customize Orders Report", "GettingCustomizeOrdersReport", "GettingCustomizeOrdersReport", "", (int)Session["User_ID"]);


            return Json(OrderModal, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetCustomizeOrdersReportWithRSF(string Customer = "-1", string Region = "-1", string Brand = "-1", string SalesOrg = "-1", string Area = "-1", string Town = "-1", string Territory = "-1", string Plant = "-1", string MatGrp1 = "-1", string MatGrp2 = "-1", string MatGrp3 = "-1", string MatGrp4 = "-1", string StartDate = "", string EndDate = "")
        {
            if ((string.IsNullOrEmpty(Customer) || Customer == "null" || Customer == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Customer = Session["Distributor_ID"].ToString();

            if ((string.IsNullOrEmpty(Region) || Region == "null" || Region == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Region = Session["RegionCode"].ToString();

            if ((string.IsNullOrEmpty(SalesOrg) || SalesOrg == "null" || SalesOrg == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                SalesOrg = Session["SalesOrg"].ToString();

            if ((string.IsNullOrEmpty(Area) || Area == "null" || Area == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Area = Session["AreaCode"].ToString();

            if ((string.IsNullOrEmpty(Town) || Town == "null" || Town == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Town = Session["TownCode"].ToString();

            if ((string.IsNullOrEmpty(Territory) || Territory == "null" || Territory == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Territory = Session["TerritoryCode"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<generateOrderModal> OrderModal = DB.CustomizeOrdersReportWithRSF(Customer, Region, Brand, SalesOrg, Area, Town, Territory, Plant, MatGrp1, MatGrp2, MatGrp3, MatGrp4, StartDate, EndDate);

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Customize Orders Report With RSF", "Getting Customize Orders Report With RSF", "GettingCustomizeOrdersReportWithRSF", "GettingCustomizeOrdersReportWithRSF", "", (int)Session["User_ID"]);


            return Json(OrderModal, JsonRequestBehavior.AllowGet);
        }





        [HttpGet]
        public JsonResult GetSpecialOrderReport(string Customer, string Region, string Material, string SKU, string SalesOrg, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate, string EndDate)
        {
            if ((string.IsNullOrEmpty(Customer) || Customer == "null" || Customer == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Customer = Session["Distributor_ID"].ToString();

            if ((string.IsNullOrEmpty(Region) || Region == "null" || Region == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Region = Session["RegionCode"].ToString();

            if ((string.IsNullOrEmpty(SalesOrg) || SalesOrg == "null" || SalesOrg == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                SalesOrg = Session["SalesOrg"].ToString();

            if ((string.IsNullOrEmpty(Area) || Area == "null" || Area == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Area = Session["AreaCode"].ToString();

            if ((string.IsNullOrEmpty(Town) || Town == "null" || Town == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Town = Session["TownCode"].ToString();

            if ((string.IsNullOrEmpty(Territory) || Territory == "null" || Territory == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Territory = Session["TerritoryCode"].ToString();
            ViewReportsBusiness SO = new ViewReportsBusiness();
            List<specialOrderModel> logs = SO.GetSpecialOrderReport(Customer, Region, Material, SKU, SalesOrg, Area, Town, Territory, Plant, MatGrp1, MatGrp2, MatGrp3, MatGrp4, StartDate, EndDate).ToList();

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Special Order Report", "Getting Special Order Report", "GettingSpecialOrderReport", "GettingSpecialOrderReport", "", (int)Session["User_ID"]);


            return Json(logs, JsonRequestBehavior.AllowGet);
        }
       
        [HttpGet]
        public JsonResult GetDayWiseShipmentReport(string Customer, string Region, string Material, string SKU, string SalesOrg, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate, string EndDate)
        {
            if ((string.IsNullOrEmpty(Customer) || Customer == "null" || Customer == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Customer = Session["Distributor_ID"].ToString();

            if ((string.IsNullOrEmpty(Region) || Region == "null" || Region == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Region = Session["RegionCode"].ToString();

            if ((string.IsNullOrEmpty(SalesOrg) || SalesOrg == "null" || SalesOrg == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                SalesOrg = Session["SalesOrg"].ToString();

            if ((string.IsNullOrEmpty(Area) || Area == "null" || Area == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Area = Session["AreaCode"].ToString();

            if ((string.IsNullOrEmpty(Town) || Town == "null" || Town == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Town = Session["TownCode"].ToString();

            if ((string.IsNullOrEmpty(Territory) || Territory == "null" || Territory == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Territory = Session["TerritoryCode"].ToString();
            //Customer = Session["Distributor_ID"].ToString();
            //string SalesOrganization = Session["SalesOrg"].ToString();
            //string Division = Session["Division"].ToString();
            ViewReportsBusiness SO = new ViewReportsBusiness();
            List<customerOrderAcceptanceModel> logs = SO.GetDayWiseShipmentReport(Customer, Region, Material, SKU, SalesOrg, Area, Town, Territory, Plant, MatGrp1, MatGrp2, MatGrp3, MatGrp4, StartDate, EndDate).ToList();

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting DayWiseShipment Report", "Getting DayWiseShipment Report", "GettingDayWiseShipmentReport", "GettingDayWiseShipmentReport", "", (int)Session["User_ID"]);


            return Json(logs, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ReportSuggestedOrder(string Customer = "-1", string Region = "-1", string Brand = "-1", string SKU = "-1", string SalesOrg = "-1", string Area = "-1", string Town = "-1", string Territory = "-1", string Plant = "-1", string MatGrp1 = "-1", string MatGrp2 = "-1", string MatGrp3 = "-1", string MatGrp4 = "-1", string StartDate = "", string EndDate = "")
        {
            if ((string.IsNullOrEmpty(Customer) || Customer == "null" || Customer == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Customer = Session["Distributor_ID"].ToString();

            if ((string.IsNullOrEmpty(Region) || Region == "null" || Region == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Region = Session["RegionCode"].ToString();

            if ((string.IsNullOrEmpty(SalesOrg) || SalesOrg == "null" || SalesOrg == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                SalesOrg = Session["SalesOrg"].ToString();

            if ((string.IsNullOrEmpty(Area) || Area == "null" || Area == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Area = Session["AreaCode"].ToString();

            if ((string.IsNullOrEmpty(Town) || Town == "null" || Town == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Town = Session["TownCode"].ToString();

            if ((string.IsNullOrEmpty(Territory) || Territory == "null" || Territory == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Territory = Session["TerritoryCode"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<generateOrderModal> OrderModal = DB.ReportSuggestedOrder(Customer, Region, Brand, SKU, SalesOrg, Area, Town, Territory, Plant, MatGrp1, MatGrp2, MatGrp3, MatGrp4, StartDate, EndDate);

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Suggested Order Report", "Getting Suggested Order Report", "GettingSuggestedOrderReport", "GettingSuggestedOrderReport", "", (int)Session["User_ID"]);


            return Json(OrderModal, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ReportConfirmedOrder(string Customer = "-1", string Region = "-1", string Brand = "-1", string SKU = "-1", string SalesOrg = "-1", string Area = "-1", string Town = "-1", string Territory = "-1", string Plant = "-1", string MatGrp1 = "-1", string MatGrp2 = "-1", string MatGrp3 = "-1", string MatGrp4 = "-1", string StartDate="", string EndDate="")
        {
            if ((string.IsNullOrEmpty(Customer) || Customer == "null" || Customer == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Customer = Session["Distributor_ID"].ToString();

            if ((string.IsNullOrEmpty(Region) || Region == "null" || Region == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Region = Session["RegionCode"].ToString();

            if ((string.IsNullOrEmpty(SalesOrg) || SalesOrg == "null" || SalesOrg == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                SalesOrg = Session["SalesOrg"].ToString();

            if ((string.IsNullOrEmpty(Area) || Area == "null" || Area == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Area = Session["AreaCode"].ToString();

            if ((string.IsNullOrEmpty(Town) || Town == "null" || Town == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Town = Session["TownCode"].ToString();

            if ((string.IsNullOrEmpty(Territory) || Territory == "null" || Territory == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Territory = Session["TerritoryCode"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<generateOrderModal> OrderModal = DB.ReportConfirmedOrder(Customer, Region, Brand, SKU, SalesOrg, Area, Town, Territory, Plant, MatGrp1, MatGrp2, MatGrp3, MatGrp4, StartDate, EndDate);

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Confirmed Order Report", "Getting Confirmed Order Report", "GettingConfirmedOrderReport", "GettingConfirmedOrderReport", "", (int)Session["User_ID"]);


            return Json(OrderModal, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ReportUnConfirmedOrder(string Customer = "-1", string Region = "-1", string Brand = "-1", string SKU = "-1", string SalesOrg = "-1", string Area = "-1", string Town = "-1", string Territory = "-1", string Plant = "-1", string MatGrp1 = "-1", string MatGrp2 = "-1", string MatGrp3 = "-1", string MatGrp4 = "-1", string StartDate = "", string EndDate = "")
        {
            if ((string.IsNullOrEmpty(Customer) || Customer == "null" || Customer == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Customer = Session["Distributor_ID"].ToString();

            if ((string.IsNullOrEmpty(Region) || Region == "null" || Region == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Region = Session["RegionCode"].ToString();

            if ((string.IsNullOrEmpty(SalesOrg) || SalesOrg == "null" || SalesOrg == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                SalesOrg = Session["SalesOrg"].ToString();

            if ((string.IsNullOrEmpty(Area) || Area == "null" || Area == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Area = Session["AreaCode"].ToString();

            if ((string.IsNullOrEmpty(Town) || Town == "null" || Town == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Town = Session["TownCode"].ToString();

            if ((string.IsNullOrEmpty(Territory) || Territory == "null" || Territory == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Territory = Session["TerritoryCode"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<generateOrderModal> OrderModal = DB.ReportUnConfirmedOrder(Customer, Region, Brand, SKU, SalesOrg, Area, Town, Territory, Plant, MatGrp1, MatGrp2, MatGrp3, MatGrp4, StartDate, EndDate);

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting UnConfirmed Order Report", "Getting UnConfirmed Order Report", "GettingUnConfirmedOrderReport", "GettingUnConfirmedOrderReport", "", (int)Session["User_ID"]);


            return Json(OrderModal, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getInTransitOrderReport(string Customer = "-1", string Region = "-1", string Brand = "-1", string SKU = "-1", string SalesOrg = "-1", string Area = "-1", string Town = "-1", string Territory = "-1", string Plant = "-1", string MatGrp1 = "-1", string MatGrp2 = "-1", string MatGrp3 = "-1", string MatGrp4 = "-1", string StartDate = "", string EndDate = "")
        {
            if (string.IsNullOrEmpty(Customer) || Customer == "null" || Customer == "-1")
                Customer = Session["Distributor_ID"].ToString();

            if (string.IsNullOrEmpty(Region) || Region == "null" || Region == "-1")
                Region = Session["RegionCode"].ToString();

            if (string.IsNullOrEmpty(SalesOrg) || SalesOrg == "null" || SalesOrg == "-1")
                SalesOrg = Session["SalesOrg"].ToString();

            if (string.IsNullOrEmpty(Area) || Area == "null" || Area == "-1")
                Area = Session["AreaCode"].ToString();

            if (string.IsNullOrEmpty(Town) || Town == "null" || Town == "-1")
                Town = Session["TownCode"].ToString();

            if (string.IsNullOrEmpty(Territory) || Territory == "null" || Territory == "-1")
                Territory = Session["TerritoryCode"].ToString();
            //string SalesOrganization = Session["SalesOrg"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<generateOrderModal> OrderModal = DB.getInTransitOrderReport(Customer, Region, Brand, SKU, SalesOrg, Area, Town, Territory, Plant, MatGrp1, MatGrp2, MatGrp3, MatGrp4, StartDate, EndDate);

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting In-Transit Order Report", "Getting In-Transit Order Report", "GettingIn-TransitOrderReport", "GettingIn-TransitOrderReport", "", (int)Session["User_ID"]);


            return Json(OrderModal, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult RSFFirmReport(string Customer = "-1", string Region = "-1", string Brand = "-1", string SKU = "-1", string SalesOrg = "-1", string Area = "-1", string Town = "-1", string Territory = "-1", string Plant = "-1", string MatGrp1 = "-1", string MatGrp2 = "-1", string MatGrp3 = "-1", string MatGrp4 = "-1", string StartDate = "")
        {
            if (string.IsNullOrEmpty(Customer) || Customer == "null" || Customer == "-1")
                Customer = Session["Distributor_ID"].ToString();

            if (string.IsNullOrEmpty(Region) || Region == "null" || Region == "-1")
                Region = Session["RegionCode"].ToString();

            if (string.IsNullOrEmpty(SalesOrg) || SalesOrg == "null" || SalesOrg == "-1")
                SalesOrg = Session["SalesOrg"].ToString();

            if (string.IsNullOrEmpty(Area) || Area == "null" || Area == "-1")
                Area = Session["AreaCode"].ToString();

            if (string.IsNullOrEmpty(Town) || Town == "null" || Town == "-1")
                Town = Session["TownCode"].ToString();

            if (string.IsNullOrEmpty(Territory) || Territory == "null" || Territory == "-1")
                Territory = Session["TerritoryCode"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<generateOrderModal> OrderModal = DB.RSFFirmReport(Customer, Region, Brand, SKU, SalesOrg, Area, Town, Territory, Plant, MatGrp1, MatGrp2, MatGrp3, MatGrp4, StartDate);

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting RSF Firm Report", "Getting RSF Firm Report", "GettingRSFFirmReport", "GettingRSFFirmReport", "", (int)Session["User_ID"]);


            return Json(OrderModal, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TossReport(string Customer, string Region, string Material, string SKU, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate, string EndDate)
        {
            if ((string.IsNullOrEmpty(Customer) || Customer == "null" || Customer == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Customer = Session["Distributor_ID"].ToString();

            if ((string.IsNullOrEmpty(Region) || Region == "null" || Region == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Region = Session["RegionCode"].ToString();

            //if ((string.IsNullOrEmpty(SalesOrg) || SalesOrg == "null" || SalesOrg == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
            //    SalesOrg = Session["SalesOrg"].ToString();

            if ((string.IsNullOrEmpty(Area) || Area == "null" || Area == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Area = Session["AreaCode"].ToString();

            if ((string.IsNullOrEmpty(Town) || Town == "null" || Town == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Town = Session["TownCode"].ToString();

            if ((string.IsNullOrEmpty(Territory) || Territory == "null" || Territory == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Territory = Session["TerritoryCode"].ToString();
            //Customer = Session["Distributor_ID"].ToString();
            string SalesOrganization = Session["SalesOrg"].ToString();
            //string Division = Session["Division"].ToString();
            ViewReportsBusiness SO = new ViewReportsBusiness();
            List<customerOrderAcceptanceModel> logs = SO.TossReport(Customer, Region, Material, SKU, SalesOrganization, Area, Town, Territory, Plant, MatGrp1, MatGrp2, MatGrp3, MatGrp4, StartDate, EndDate).ToList();

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting DayWiseShipment Report", "Getting DayWiseShipment Report", "GettingDayWiseShipmentReport", "GettingDayWiseShipmentReport", "", (int)Session["User_ID"]);


            return Json(logs, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult RSFSuggestedReport(string Customer = "-1", string Region = "-1", string Brand = "-1", string SKU = "-1", string SalesOrg = "-1", string Area = "-1", string Town = "-1", string Territory = "-1", string Plant = "-1", string MatGrp1 = "-1", string MatGrp2 = "-1", string MatGrp3 = "-1", string MatGrp4 = "-1", string StartDate = "")
        {
            if ( (string.IsNullOrEmpty(Customer) || Customer == "null" || Customer == "-1") && Convert.ToInt16( Session["roleid"] ) != 1)
                Customer = Session["Distributor_ID"].ToString();

            if ((string.IsNullOrEmpty(Region) || Region == "null" || Region == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Region = Session["RegionCode"].ToString();

            if ((string.IsNullOrEmpty(SalesOrg) || SalesOrg == "null" || SalesOrg == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                SalesOrg = Session["SalesOrg"].ToString();

            if ((string.IsNullOrEmpty(Area) || Area == "null" || Area == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Area = Session["AreaCode"].ToString();

            if ((string.IsNullOrEmpty(Town) || Town == "null" || Town == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Town = Session["TownCode"].ToString();

            if ((string.IsNullOrEmpty(Territory) || Territory == "null" || Territory == "-1") && Convert.ToInt16(Session["roleid"]) != 1)
                Territory = Session["TerritoryCode"].ToString();
            ViewReportsBusiness DB = new ViewReportsBusiness();
            List<generateOrderModal> OrderModal = DB.RSFSuggestedReport(Customer, Region, Brand, SKU, SalesOrg, Area, Town, Territory, Plant, MatGrp1, MatGrp2, MatGrp3, MatGrp4, StartDate);

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting RSF Suggested Report", "Getting RSF Suggested Report", "GettingRSFSuggestedReport", "GettingRSFSuggestedReport", "", (int)Session["User_ID"]);


            return Json(OrderModal, JsonRequestBehavior.AllowGet);
        }

    }
   

}