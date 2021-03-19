using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class WeekWiseOrder
    {
        public string refrence { get; set; }
        public int Material { get; set; }
        public string Description { get; set; }
        public double unitPrice { get; set; }
        public double ClaimValue { get; set; }
        public int day { get; set; }
        public int orderQty { get; set; }
        public string comments { get; set; }
        public string ReceivingComments { get; set; }
        public int recievedQty { get; set; }
        public int damagedQty { get; set; }
        public int expiredQty { get; set; }
        public int shortQty { get; set; }
        public int TotalClaimed { get; set; }
        public string ClaimDay { get; set; }
        public int approved { get; set; }
        public string receivingdate { get; set; }
        public string BillingId { get; set; }
        public string BillingNo { get; set; }
        public string title { get; set; }
        public string referenceId { get; set; }
        public string filepath { get; set; }
        public string Status { get; set; }

    }
}
