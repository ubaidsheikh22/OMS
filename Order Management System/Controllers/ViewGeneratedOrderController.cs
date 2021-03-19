using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
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
    public class ViewGeneratedOrderController : Controller
    {
        // GET: ViewGeneratedOrder
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridView(string customer, string salesorg, string division, string region, string area, string territory, string town, string plant)
        {
            string UserID = Session["User_ID"].ToString();

            generateOrder EML = new generateOrder();
            List<generateOrderModalGrid> emp = EML.ViewGeneratedOrder(customer, salesorg, division, region, area, territory, town, plant, UserID).ToList();

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
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Generated Order View", "Getting Generated Order View", "GeneratedOrderView", "GeneratedOrderView", "", (int)Session["User_ID"]);

            return outputJsonResult;
            //return Json(output, JsonRequestBehavior.AllowGet);





        }
    }
}