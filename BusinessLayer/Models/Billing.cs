using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class Billing
    {
        public int BillingId { get; set; }
        public string SapOrderNo { get; set; }
        public string Customer { get; set; }
        public string CALDAY { get; set; }
        public string BillingNo { get; set; }
    }
}
