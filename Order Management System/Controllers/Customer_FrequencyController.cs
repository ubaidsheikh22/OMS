using BusinessLayer.Models;
using BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
  
namespace Order_Management_System.Controllers
{
    public class Customer_FrequencyController : Controller
    {
        // GET: Customer_Frequency
        public ActionResult Customer_Frequency()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAllCustomerRecords()
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
            CustomerBusiness EML = new CustomerBusiness();
            List<CustomerModel> emp = EML.GetAllCustomerRecords.ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);
            //recordsTotal = emp.Count();
            //var data = emp.Skip(skip).Take(pageSize).ToList();
            //return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAllPackages()
        {
            Customer_FrequencyBusiness RB = new Customer_FrequencyBusiness();

            List<PackageModel> r = RB.GetAllpackagesFrequency.ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllPackagaeFrequency()
        {
            Customer_FrequencyBusiness RB = new Customer_FrequencyBusiness();

            List<Customer_FrequencyModel> r = RB.GetAllpackagesRecord.ToList();
            return Json(r, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult GetAllCusRecord(string Customer_Name ,string Region,string Customer_Code)
        {
            try
            {
                if (Customer_Name !=null)
                { 
                Customer_FrequencyBusiness RB = new Customer_FrequencyBusiness();

                List<CustomerModel> r = RB.GetAllCustomerRecords.ToList();
                var CustomerList = (from N in r
                                    where N.Name1.StartsWith(Customer_Name)
                                    select new { N.Name1 });


                    return Json(CustomerList, JsonRequestBehavior.AllowGet);
                }
                if (Region != null)
                {
                    Customer_FrequencyBusiness RB = new Customer_FrequencyBusiness();

                    List<CustomerModel> r = RB.GetAllCustomerRecords.ToList();
                    var CustomerList = (from N in r
                                        where N.RegionDescription.StartsWith(Region)
                                        select new { N.RegionDescription });


                    return Json(CustomerList, JsonRequestBehavior.AllowGet);
                }
                if (Customer_Code !=null)
                {
                    Customer_FrequencyBusiness RB = new Customer_FrequencyBusiness();

                    List<CustomerModel> r = RB.GetAllCustomerRecords.ToList();
                    var CustomerList = (from N in r
                                        where N.Customer.Equals(Customer_Code)
                                        select new { N.Customer });


                    return Json(CustomerList, JsonRequestBehavior.AllowGet);
                }

                return Json(true, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                RoleController rc = new RoleController();
                rc.InsertAuditingLog("Error", "GetAllCusRecord", "GetAllCusRecord", "GetAllCusRecord", ex.Message, (int)Session["User_ID"]);
                throw;
            }
           
        }


        }
}