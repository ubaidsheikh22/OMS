using BusinessLayer.Repository;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class secondarySalesController : Controller
    {
        // GET: secondarySales
        public ActionResult secondarySales()
        {
            return View();
        }

        public JsonResult gridView(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {
            secondarySaleBusiness SSB = new secondarySaleBusiness();
            List<secondarySalesModel> secondarySalesModel = SSB.gridViewSecondarySales(CALDAY, Comp, salesorg, distr, div, customer, material).ToList();

            var json = Json(secondarySalesModel, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        [HttpPost]
        public JsonResult gridViewPaging(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {
            var take = Convert.ToInt32(Request["length"]);
            var skip = Convert.ToInt32(Request["start"]);
            var draw = Convert.ToInt32(Request["draw"]);
            var search = Request["search[value]"];

            //var len = Convert.ToInt32( Request["length"]);
            //var len = Convert.ToInt32(Request["length"]);
            secondarySaleBusiness SSB = new secondarySaleBusiness();
            List<secondarySalesModel> secondarySalesModel = SSB.gridViewSecondarySales(CALDAY, Comp, salesorg, distr, div, customer, material).ToList();
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
                                            x.Name1.ToLower().Contains(search) ||
                                            x.CustomerName2.ToLower().Contains(search) ||
                                            x.RegionDescription.ToLower().Contains(search) ||
                                            x.AreaDescription.ToLower().Contains(search) ||
                                            x.TerritoryDescription.ToLower().Contains(search) ||
                                            x.TownDescription.ToLower().Contains(search) ||
                                            x.Material.ToString().Contains(search) ||
                                            x.Description.ToLower().Contains(search) ||
                                            x.MatPricingGrpDescription.ToLower().Contains(search) ||
                                            x.MaterialGroup1_Description.ToLower().Contains(search) ||
                                            x.MaterialGroup2_Description.ToLower().Contains(search) ||
                                            x.MaterialGroup3_Description.ToLower().Contains(search) ||
                                            x.MaterialGroup4_Description.ToLower().Contains(search) ||
                                            x.MaterialGroup5_Description.ToLower().Contains(search) ||
                                            x.MaterialGroupdescription.ToLower().Contains(search) ||
                                            x.UOM.ToLower().Contains(search) ||
                                            x.DistributionChannel.ToString().Contains(search) ||
                                            x.Quantity.ToString().Contains(search)
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

        [HttpGet]
        public JsonResult GetCALDAY(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            secondarySaleBusiness EML = new secondarySaleBusiness();

            List<secondarySalesModel> emp = EML.GetCALDAY(CALDAY, Comp, salesorg, distr, div, customer, material).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetComp(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            secondarySaleBusiness EML = new secondarySaleBusiness();

            List<secondarySalesModel> emp = EML.GetComp(CALDAY, Comp, salesorg, distr, div, customer, material).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetSalesOrg(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            secondarySaleBusiness EML = new secondarySaleBusiness();

            List<secondarySalesModel> emp = EML.GetSalesOrg(CALDAY, Comp, salesorg, distr, div, customer, material).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetDistr(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            secondarySaleBusiness EML = new secondarySaleBusiness();

            List<secondarySalesModel> emp = EML.GetDistr(CALDAY, Comp, salesorg, distr, div, customer, material).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetDiv(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            secondarySaleBusiness EML = new secondarySaleBusiness();

            List<secondarySalesModel> emp = EML.GetDiv(CALDAY, Comp, salesorg, distr, div, customer, material).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetCustomer(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            secondarySaleBusiness EML = new secondarySaleBusiness();

            List<secondarySalesModel> emp = EML.GetCustomer(CALDAY, Comp, salesorg, distr, div, customer, material).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetMaterial(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            secondarySaleBusiness EML = new secondarySaleBusiness();

            List<secondarySalesModel> emp = EML.GetMaterial(CALDAY, Comp, salesorg, distr, div, customer, material).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);

        }
    }
}