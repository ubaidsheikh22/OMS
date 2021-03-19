using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Repository;

namespace Order_Management_System.Controllers
{
    public class packageController : Controller
    {
        // GET: package
        public ActionResult package()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddPackage(PackageModel Data)
        {
            int User_id = 1;
            PackageBusiness pb = new PackageBusiness();
            //List<PackageModel> pkmodel = pb.InsertUpdatePackage(model, "add");\
            PackageModel pm = new PackageModel();
            {
                pm.PackageName = Data.PackageName;
                pm.User_ID = User_id;
            }
            string Message = pb.InsertUpdatePackage(pm, "Add");

            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Add Package", "inserting Package", "AddPackage", "AddPackage", "", (int)Session["User_ID"]);
            return Json(Message);
        }

        public JsonResult GetAllPackeges()
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
            PackageBusiness EML = new PackageBusiness();
            List<PackageModel> emp = EML.GetAllPackagesRecords.ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);
            //recordsTotal = emp.Count();
            //var data = emp.Skip(skip).Take(pageSize).ToList();
            //return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult updatePackage(int Package_ID, string PackageName)
        {
            PackageBusiness RB = new PackageBusiness();
            PackageModel pkg = new PackageModel()
            {
                Package_ID = Package_ID,
                PackageName = PackageName
            };
            string message = RB.InsertUpdatePackage(pkg, "Update");
            RoleController RC = new RoleController();
            RC.InsertAuditingLog("Updating Package", "Updating Package", "updatePackage", "updatePackage", "", (int)Session["User_ID"]);
            return Json(message);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Login");
        }
    }
}