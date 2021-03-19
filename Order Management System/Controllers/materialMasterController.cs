using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Order_Management_System.Controllers
{
    public class materialMasterController : Controller
    {
        // GET: materialMaster
        public ActionResult materialMaster()
        {

            materialMasterBusiness MMB = new materialMasterBusiness();
            string material = "", sales = Session["SalesOrg"].ToString(), PGD = "", group1 = "", group2 = "", group3 = "", group4 = "", group5 = "", Division = Session["Division"].ToString();
            var data = new {
                material= MMB.GetMaterials(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                sales= MMB.GetSalesOrg(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                PGD= MMB.GetPGD(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                group1= MMB.GetGROUP1(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                group2= MMB.GetGROUP2(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                group3= MMB.GetGROUP3(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                group4= MMB.GetGROUP4(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                group5= MMB.GetGROUP5(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                division= MMB.GetDivision(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList()
                };
            ViewBag.JSONData = new JavaScriptSerializer().Serialize(data); // Json(data, JsonRequestBehavior.AllowGet);
            ViewBag.AllData = new JavaScriptSerializer().Serialize(MMB.GetAllMaterials(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList());
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting Material Master View", "Getting Material Master View", "GettingMaterialMasterView", "GettingMaterialMasterView", "", (int)Session["User_ID"]);

            return View();
        }
        [HttpPost]
        public JsonResult gridView(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {
            
            if (string.IsNullOrEmpty(sales) || sales == "null")
                sales = Session["SalesOrg"].ToString();

            if (string.IsNullOrEmpty(Division) || Division == "null")
                Division = Session["Division"].ToString();

            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetAllMaterials(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getMaterial(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {
            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetMaterials(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getAllDDL(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {
            if (string.IsNullOrEmpty(sales) || sales == "null")
                sales = Session["SalesOrg"].ToString();

            if (string.IsNullOrEmpty(Division) || Division == "null")
                Division = Session["Division"].ToString();

            materialMasterBusiness MMB = new materialMasterBusiness();
            var data = new
            {
                material = MMB.GetMaterials(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                sales = MMB.GetSalesOrg(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                PGD = MMB.GetPGD(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                group1 = MMB.GetGROUP1(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                group2 = MMB.GetGROUP2(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                group3 = MMB.GetGROUP3(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                group4 = MMB.GetGROUP4(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                group5 = MMB.GetGROUP5(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList(),
                division = MMB.GetDivision(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList()
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getSALESORG(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {
            if (string.IsNullOrEmpty(sales) || sales == "null")
                sales = Session["SalesOrg"].ToString();

            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetSalesOrg(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getPGD(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {
            if (string.IsNullOrEmpty(sales) || sales == "null")
                sales = Session["SalesOrg"].ToString();

            if (string.IsNullOrEmpty(Division) || Division == "null")
                Division = Session["Division"].ToString();

            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetPGD(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult getGROUP1(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetGROUP1(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getGROUP2(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetGROUP2(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getGROUP3(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetGROUP3(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getGROUP4(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetGROUP4(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getGROUP5(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetGROUP5(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getDivision(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {
            if (string.IsNullOrEmpty(Division) || Division == "null")
                Division = Session["Division"].ToString();

            materialMasterBusiness MMB = new materialMasterBusiness();
            List<materialMasterModel> materialMasterModel = MMB.GetDivision(material, sales, PGD, group1, group2, group3, group4, group5, Division).ToList();
            return Json(materialMasterModel, JsonRequestBehavior.AllowGet);
        }




    }
}