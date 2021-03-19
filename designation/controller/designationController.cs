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
        public ActionResult addDesignation(string designationDesc, int userId)
        {
            designationBusiness db = new designationBusiness();
            designation d = new designation()
            {
                DesigantionDesc = designationDesc,
                User_ID = userId
            };
            string message = db.addDesignation(d, "ADD");
            return Json(message);
        }

        [HttpGet]
        public JsonResult getAllUsers()
        {
            designationBusiness DB = new designationBusiness();
            List<user> ur = DB.getAllUsers.ToList();
            return Json(ur, JsonRequestBehavior.AllowGet);
        }



        public JsonResult gridView()
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            string search = Request.Form.GetValues("search[value]")[0];

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            designationBusiness DB = new designationBusiness();
            List<designation> d = DB.gridViewDesignation.ToList();

            recordsTotal = d.Count();
            var data = d.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);

        }
    }
}