using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class OrderStatus
    {
        public string OrderRefrenceNumber { get; set; }
        public string Customer { get; set; }

        public string FirmOrder { get; set; }
        public string Calday { get; set; }
        public string SalesOrganization { get; set; }
        public string division { get; set; }
        public string IsPushed { get; set; }
    }
}
