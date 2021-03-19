using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class RoleController : Controller
    {


        public ActionResult Role()
        {
            return View();
        }
        // GET: Role
        [HttpPost]
        public ActionResult addRole(string Rele_Desc)
        {
            int User_ID = 1;
            RoleBusiness db = new RoleBusiness();
            RoleModel d = new RoleModel()
            {
                Rele_Desc = Rele_Desc,
                User_ID = User_ID
            };
            string message = db.addRole(d, "ADD");
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Adding New Role", "Adding New Role", "AddingRole", "AddingRole", "", (int)Session["User_ID"]);

            return Json(message);
        }

        [HttpGet]
        public JsonResult GetAllRoles()
        {
            RoleBusiness RB = new RoleBusiness();

            List<RoleModel> r = RB.GetAllRoles.ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetDistrict(int Role_ID)
        {
            RoleBusiness RBb = new RoleBusiness();
            //if (!string.IsNullOrEmpty(Role_ID))
            //{

            List<DistributorModel> r = RBb.GetAllDistributotRecords.ToList();
            //var distributorName = (from N in r
            //                       where N.Role_ID.Equals(Role_ID)
            //                       select new { N.Distributor_ID, N.Distributor_Name });
                                   //select new { N.Distributor_ID });

            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public JsonResult gridView()
        {
            //var draw = Request.Form.GetValues("draw").FirstOrDefault();
            //var start = Request.Form.GetValues("start").FirstOrDefault();
            //var length = Request.Form.GetValues("length").FirstOrDefault();
            //var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            //var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            //string search = Request.Form.GetValues("search[value]")[0];

            //int pageSize = length != null ? Convert.ToInt32(length) : 0;
            //int skip = start != null ? Convert.ToInt32(start) : 0;
            //int recordsTotal = 0;
            RoleBusiness DB = new RoleBusiness();
            List<RoleModel> d = DB.GetAllRoles.ToList();
            return Json(d, JsonRequestBehavior.AllowGet);
            //recordsTotal = d.Count();
            //var data = d.Skip(skip).Take(pageSize).ToList();
            //return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult updateRole(int Role_ID,string Rele_Desc)
        {
            RoleBusiness RB = new RoleBusiness();
            RoleModel role = new RoleModel()
            {
                Role_ID = Role_ID,
                Rele_Desc = Rele_Desc
            };
            string message = RB.addRole(role, "Update");
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Updating Role", "Updating Role", "UpdatingRole", "UpdatingRole", "", (int)Session["User_ID"]);

            return Json(message);
        }

        [HttpPost]
        public int CreateUpdateSubstitute(SubstituteModel model)
        {
            try
            {
                RoleBusiness RBb = new RoleBusiness();
                if (model != null)
                {
                    if (model.CreatedBy == 0)
                        model.CreatedBy = Convert.ToInt32(Session["User_ID"]);
                    int RES= RBb.CreateUpdateSubstitute(model);
                InsertAuditingLog("Substitute Assigned", "Assigned Substitute", "SubstituteAssigned", "SubstituteAssigned", "", (int)Session["User_ID"]);
                    return RES;
                }
                return 1;
            }
            catch(Exception ex)
            {
                InsertAuditingLog("Error Substitute", "Substitute Already exist error", "SubstituteError", "SubstituteError","", (int)Session["User_ID"]);
                return 0;
            }
        }

        public int SetSubstitute_ForceStop(int id)
        {
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Substitute Stop Forcefully", "Substitute Stop Forcefully", "SubstituteStopForcefully", "SubstituteStopForcefully", "", (int)Session["User_ID"]);

            RoleBusiness rb = new RoleBusiness();
            return rb.SetSubstitute_ForceStop(id);
        }

        public ActionResult Substitute()
        {
            RoleBusiness RB = new RoleBusiness();
            List<SubstituteModel> r = RB.GetAllUsers.ToList();
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "-1",
                Text = "Select User"
            });
            foreach (var element in r)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.User_ID.ToString(),
                    Text = element.User_Name
                });
            }
            ViewBag.Users = selectList;
            return View();
        }
        public JsonResult GetAllSubstitute()
        {
            RoleBusiness RB = new RoleBusiness();

            List<SubstituteModel> r = RB.GetAllSubstitute(1);
            return Json(r, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSubstituteById(int UserId)
        {
            RoleBusiness RB = new RoleBusiness();

            List<SubstituteModel> r = RB.GetAllSubstitute(2, UserId);
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public int InsertAuditingLog(string LogType="", string LogName = "", string LogScreen = "", string ActionPerformed = "", string Misc = "",int UserId = 0)
        {
            RoleBusiness RBb = new RoleBusiness();
            AuditingLogModel audit = new AuditingLogModel();
            audit.LogType = LogType;
            audit.LogName = LogName;
            audit.LogScreen = LogScreen;
            audit.ActionPerformed = ActionPerformed;
            audit.Misc = Misc;
            audit.CreatedBy = UserId;
            return RBb.InsertAuditingLog(audit);
        }
    }
}