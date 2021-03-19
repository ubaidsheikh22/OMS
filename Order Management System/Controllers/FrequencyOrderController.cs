using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Repository;
using BusinessLayer.Models;
using System.Data;
using System.Data.SqlClient;

namespace Order_Management_System.Controllers
{
    public class FrequencyOrderController : Controller
    {
        // GET: FrequencyOrder
        public ActionResult FrequencyOrder()
        {
            return View();
        }
        [HttpPost]
        public JsonResult FrequencyOrder(List<OrderFrequencyModel> dataToPost)
        {

           
            Connection con = new Connection();
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {

                   
                    SqlCommand cmd = new SqlCommand("SP_Day_Frequency_insert", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter tvparam = cmd.Parameters.AddWithValue("@tbl_Day_Frequency", dataToPost);
                    tvparam.SqlDbType = SqlDbType.Structured;
                    cmd.ExecuteNonQuery();
                    RoleController RC = new RoleController();
                    RC.InsertAuditingLog("General", "Adding Frequency", "FrequencyOrder", "FrequencyOrder", "", (int)Session["User_ID"]);
                
                };
            }
            catch (Exception ex )
            {
                RoleController rc = new RoleController();
                rc.InsertAuditingLog("Error", "FrequencyOrder", "FrequencyOrder", "FrequencyOrder", ex.Message, (int)Session["User_ID"]);
                throw ex;
            }
           
         

            return Json(JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAllCustomerRecords()
        {
          
            CustomerBusiness EML = new CustomerBusiness();
            List<CustomerModel> emp = EML.GetAllCustomerRecords.ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);
            
        }
    }
}