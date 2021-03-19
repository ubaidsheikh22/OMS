using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Order_Management_System.Controllers
{
    public class GenerateOrderController : Controller
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

        [HttpGet]
        public JsonResult getAllDDL(string name, string salesorg, string div, string category, string region, string area, string territory, string town, string plant, bool isFirstLoad)//, string Division)
        {

            salesorg = string.IsNullOrEmpty(salesorg) || salesorg == "null" ? Session["SalesOrg"].ToString() : salesorg;
            region = string.IsNullOrEmpty(region) || region == "null" ? Session["RegionCode"].ToString() : region;
            area = string.IsNullOrEmpty(area) || area == "null" ? Session["AreaCode"].ToString() : area;
            territory = string.IsNullOrEmpty(territory) || territory == "null" ? Session["TerritoryCode"].ToString() : territory;
            town = string.IsNullOrEmpty(town) || town == "null" ? Session["TownCode"].ToString() : town;
            name = string.IsNullOrEmpty(name) || name == "null" ? Session["Distributor_ID"].ToString() : name;
            div = string.IsNullOrEmpty(div) || div == "null" ? Session["Division"].ToString() : div;


            CustomerBusiness business = new CustomerBusiness();

            var data = new
            {
                name = business.GetCustomer(name, salesorg, div, "", region, area, territory, town, plant).ToList(),
                salesorg = business.GetSalesOrg(name, salesorg, div, "", region, area, territory, town, plant).ToList(),
                div = business.GetDivision(name, salesorg, div, "", region, area, territory, town, plant).ToList(),
                region = business.GetRegion(name, salesorg, div, "", region, area, territory, town, plant).ToList(),
                area = business.GetArea(name, salesorg, div, "", region, area, territory, town, plant).ToList(),
                territory = business.GetTerritory(name, salesorg, div, "", region, area, territory, town, plant).ToList(),
                town = business.GetTown(name, salesorg, div, "", region, area, territory, town, plant).ToList(),
                plant = business.GetPlant(name, salesorg, div, "", region, area, territory, town, plant).ToList()
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: GenerateOrder
        public ActionResult GenerateOrder()
        {

            CustomerBusiness customerBusiness = new CustomerBusiness();
            generateOrder business = new generateOrder();
            string customer = "", sales = "", div = "", region = "", area = "", territory = "", town = "", plant = "";

            sales = string.IsNullOrEmpty(sales) || sales == "null" ? Session["SalesOrg"].ToString() : sales;
            region = string.IsNullOrEmpty(region) || region == "null" ? Session["RegionCode"].ToString() : region;
            area = string.IsNullOrEmpty(area) || area == "null" ? Session["AreaCode"].ToString() : area;
            territory = string.IsNullOrEmpty(territory) || territory == "null" ? Session["TerritoryCode"].ToString() : territory;
            town = string.IsNullOrEmpty(town) || town == "null" ? Session["TownCode"].ToString() : town;
            customer = string.IsNullOrEmpty(customer) || customer == "null" ? Session["Distributor_ID"].ToString() : customer;
            div = string.IsNullOrEmpty(div) || div == "null" ? Session["Division"].ToString() : div;


            var data = new
            {
                name = customerBusiness.GetCustomer(customer, sales, div, "", region, area, territory, town, plant).ToList(),
                sales = customerBusiness.GetSalesOrg(customer, sales, div, "", region, area, territory, town, plant).ToList(),
                div = customerBusiness.GetDivision(customer, sales, div, "", region, area, territory, town, plant).ToList(),
                region = customerBusiness.GetRegion(customer, sales, div, "", region, area, territory, town, plant).ToList(),
                area = customerBusiness.GetArea(customer, sales, div, "", region, area, territory, town, plant).ToList(),
                territory = customerBusiness.GetTerritory(customer, sales, div, "", region, area, territory, town, plant).ToList(),
                town = customerBusiness.GetTown(customer, sales, div, "", region, area, territory, town, plant).ToList(),
                plant = customerBusiness.GetPlant(customer, sales, div, "", region, area, territory, town, plant).ToList()
            };
            var output = business.gridView(customer, sales, div, region, area, territory, town, plant).ToList();
            var outputJsonResult = Json(output, JsonRequestBehavior.AllowGet);
            outputJsonResult.MaxJsonLength = 90 * 1024 * 1024; // 90 MB
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 90 * 1024 * 1024;
            ViewBag.JSONData = new JavaScriptSerializer().Serialize(data); // Json(data, JsonRequestBehavior.AllowGet);
            ViewBag.AllData = serializer.Serialize(outputJsonResult);

            return View();
        }

        [HttpPost]
        public string GetAllGeneratedOrders([System.Web.Http.FromBody] string name)
        {
            generateOrder EML = new generateOrder();
            List<generateOrderModal> emp = EML.GetAllCustomerRecords2().ToList();
            string message = insertOrder(emp);
            return message;
        }

        [HttpPost]
        public JsonResult GridView(string customer, string salesorg, string division, string region, string area, string territory, string town, string plant)
        {
            salesorg = string.IsNullOrEmpty(salesorg) || salesorg == "null" ? Session["SalesOrg"].ToString() : salesorg;
            region = string.IsNullOrEmpty(region) || region == "null" ? Session["RegionCode"].ToString() : region;
            area = string.IsNullOrEmpty(area) || area == "null" ? Session["AreaCode"].ToString() : area;
            territory = string.IsNullOrEmpty(territory) || territory == "null" ? Session["TerritoryCode"].ToString() : territory;
            town = string.IsNullOrEmpty(town) || town == "null" ? Session["TownCode"].ToString() : town;
            customer = string.IsNullOrEmpty(customer) || customer == "null" ? Session["Distributor_ID"].ToString() : customer;
            division = string.IsNullOrEmpty(division) || division == "null" ? Session["Division"].ToString() : division;

            generateOrder EML = new generateOrder();
            List<generateOrderModalGrid> emp = EML.gridView(customer, salesorg, division, region, area, territory, town, plant).ToList();
            //            List<generateOrderModal> emp = EML.GetAllCustomerRecords2(AreaCode,TerritoryCode,TownCode,UserID,RegionCode).ToList();

            var distinctCustomer = emp.Select(x => x.CUSTOMER).Distinct();
            var distinctSalesOrg = emp.Select(x => x.SALESORG).Distinct();
            var distinctDivision = emp.Select(x => x.DIVISION).Distinct();

            List<ABC> groupedData = new List<ABC>();
            foreach (var cust in distinctCustomer)
            {
                foreach (var so in distinctSalesOrg)
                {
                    foreach (var div in distinctDivision)
                    {
                        var temp = emp.Where(x => x.CUSTOMER == cust && x.SALESORG == so && x.DIVISION == div).
                            Select(x => x)
                            .GroupBy(u => new { u.CUSTOMER, u.customerName, u.SALESORG, u.DIVISION, u.MaterialGroup, u.MaterialGroupdescription })
                            .Select(x => new ABC
                            {
                                CUSTOMER = x.First().CUSTOMER,
                                customerName = x.First().customerName,
                                SALESORG = x.First().SALESORG,
                                DIVISION = x.First().DIVISION,
                                MATERIAL = x.First().MaterialGroup,
                                materialDesc = x.First().MaterialGroupdescription,
                                Order_Qty = x.Sum(z => Convert.ToInt32(z.Order_Qty)),
                                MaterialTotalValues = x.Sum(y => y.MaterialTotalValues)
                            }).ToList();
                        groupedData.AddRange(temp);
                    }
                }
            }
            var output = new
            {
                emp = emp,
                groupdata = groupedData
            };

            var outputJsonResult = Json(output, JsonRequestBehavior.AllowGet);
            outputJsonResult.MaxJsonLength = 10 * 1024 * 1024; // 10 MB
            return outputJsonResult;
            //return Json(output, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string insertOrder(List<generateOrderModal> dataToPost)
        {
            //DataTable dt = new DataTable();
            generateOrder go = new generateOrder();
            string Message = go.InsertInTable(dataToPost).ToString();

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("General", "inserting Orders", "insertOrder", "insertOrder", "", (int)Session["User_ID"]);
            return Message;
        }

        [HttpPost]
        public string insertConfirmOrder(List<generateOrderModal> dataToPost)
        {
            //DataTable dt = new DataTable();
            generateOrder go = new generateOrder();
            string Message = go.InsertOrderInTable(dataToPost).ToString();

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("General", "inserting Confirm Orders", "insertConfirmOrder", "insertConfirmOrder", "", (int)Session["User_ID"]);
            return Message;
        }

        [HttpGet]
        public JsonResult Customer(string region)
        {
            generateOrder go = new generateOrder();
            List<generateOrderModal> emp = go.getCustomer(region).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetFrequency(int customer, string OrderReferenceNumber)
        {
            generateOrder CustomerOrderAcceptance = new generateOrder();
            List<customerOrderAcceptanceModel> List = CustomerOrderAcceptance.getRecordToGrid(customer, OrderReferenceNumber).ToList();
            return Json(List, JsonRequestBehavior.AllowGet);

        }

    }

}