using BusinessLayer.Models;
using BusinessLayer.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class weeklyUpliftController : Controller
    {
        // GET: weeklyUplift
        public ActionResult weeklyUplift()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetGrid()
        {
            string customer = "";
            customer = string.IsNullOrEmpty(customer) || customer == "null" ? Session["Distributor_ID"].ToString() : customer;
            weeklyUpliftBusiness wub = new weeklyUpliftBusiness();
            List<WeeklyUpliftsModel> materialList = wub.GetAllMaterials(customer).ToList();
            return Json(materialList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddWeeklyUplift(List<WeeklyUpliftsModel> dataToPost)
        {
            weeklyUpliftBusiness db = new weeklyUpliftBusiness();
            string message = db.AddWeeklyUpliftRecord(dataToPost);
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Applying Weekly Uplift", "Applying Weekly Uplift", "ApplyingWeeklyUplift", "ApplyingWeeklyUplift", "", (int)Session["User_ID"]);

            return Json(message);
        }


        [HttpPost]
        public JsonResult getAllCustomers(int regionCode)
        {
            string customer = "";
            customer = string.IsNullOrEmpty(customer) || customer == "null" ? Session["Distributor_ID"].ToString() : customer;
            weeklyUpliftBusiness db = new weeklyUpliftBusiness();
            List<CustomerModel> PR = db.getAllPackages(regionCode, customer).ToList();
            return Json(PR, JsonRequestBehavior.AllowGet);
        }
    }
}