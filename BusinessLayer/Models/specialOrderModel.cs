using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
   public class specialOrderModel
    {

        public string SP_Order_ID { get; set; }
        public int Customer { get; set; }
        public int Package_ID { get; set; }
        public int Material { get; set; }
        public string MaterialName { get; set; }
        public string RegionDescription { get; set; }
        public string MaterialSKU { get; set; }
        public string Description { get; set; }
        public int SalesOrganization { get; set; }
        public int RegionCode { get; set; }
        public int Quantity { get; set; }
        public int Aproved { get; set; }
        public int Division { get; set; }

    }
}
