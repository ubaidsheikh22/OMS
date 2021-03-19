using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class designationController : Controller
    {
        // GET: designation
        public ActionResult designation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addDesignation(string designationDesc,int Position)
        {
            int customerCode = Convert.ToInt32(Session["User_ID"]);

            DesginationBusiness db = new DesginationBusiness();
            DesignationModel d = new DesignationModel()
            {
                DesigantionDesc = designationDesc,
                Position = Position,
                User_ID= customerCode
            };
            string message = db.addDesignation(d, "ADD");
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ModelState.Clear();
                return Json(message);
            }
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Add Designation", "AddingDesignation", "AddingDesignation", "AddingDesignation", "", (int)Session["User_ID"]);
            ModelState.Clear();
            return Json(message);
        }

        [HttpPost]
        public ActionResult updateDesignation(int Designation_ID, string Designation_Desc)
        {
           var User_IDD = Session["roleid"];
            DesginationBusiness DB = new DesginationBusiness();
            DesignationModel designation = new DesignationModel()
            {
                Designation_ID = Designation_ID,
                DesigantionDesc = Designation_Desc,
              //  User_ID = User_IDD
            };
            string message = DB.addDesignation(designation, "Update");
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Updating Designation", "UpdatingDesignation", "UpdatingDesignation", "UpdatingDesignation", "", (int)Session["User_ID"]);
            return Json(message);
        }

        [HttpGet]
        public JsonResult getAllUsers()
        {
            DesginationBusiness DB = new DesginationBusiness();
            List<user> ur = DB.getAllUsers.ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllDesignation()
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Getting All Designations", "GettingAllDesignations", "GettingAllDesignations", "GettingAllDesignations", "", (int)Session["User_ID"]);


            DesginationBusiness RB = new DesginationBusiness();

            List<DesignationModel> r = RB.GetAllDesignationRecord.ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public JsonResult gridView()
        {
            
            DesginationBusiness DB = new DesginationBusiness();
            List<DesignationModel> d = DB.gridViewDesignation.ToList();
            return Json(d, JsonRequestBehavior.AllowGet);
          
        }


        public JsonResult DeleteDesignation(int id) {
            DesginationBusiness DB = new DesginationBusiness();
            int m = DB.DeleteUser(id);
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Deleting Designation", "DeletingDesignation", "DeletingDesignation", "DeletingDesignation", "", (int)Session["User_ID"]);

            return Json("Delete Successfully", JsonRequestBehavior.AllowGet);

        }

    }
}