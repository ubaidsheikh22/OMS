using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Order_Management_System.Controllers
{
    public class CustomerOrderDetailController : Controller
    {
        // GET: CustomerOrderDetail
        public ActionResult Customer_Order_Detail()
        {
            return View();
        }

        public ActionResult CustomerWeekendDetail()
        {
            return View();
        }

        public ActionResult SingleCustomerDetail()
        {
            return View();
        }
    }
}