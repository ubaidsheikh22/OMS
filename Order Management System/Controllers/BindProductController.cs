using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class BindProductController : Controller
    {
        // GET: BindProduct
        public ActionResult Bind_Product()
        {
            return View();
        }


        public JsonResult GetProduct()
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("General", "Getting Products To Bind", "BindProducts", "BindProducts", "", (int)Session["User_ID"]);

            bindProductBusiness bindProduct = new bindProductBusiness();
            List<materialMasterModel> List = bindProduct.GetAllMaterials.ToList();
            return Json(List,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetProductForList()
        {
            
            bindProductBusiness bindProduct = new bindProductBusiness();
            List<materialMasterModel> List = bindProduct.GetBindedProducts.ToList();
            return Json(List, JsonRequestBehavior.AllowGet);
           
        }

        [HttpPost]
        public JsonResult insertBindingProducts(int ProductCode1, int ProductCode2)
        {
            bindProductBusiness bindProduct = new bindProductBusiness();
            string Message = bindProduct.addProductsToBind(ProductCode1, ProductCode2).ToString();
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("General", "Bind Two Products", "BindProducts", "BindProducts", "", (int)Session["User_ID"]);

            return Json(Message);
        }
    }
}