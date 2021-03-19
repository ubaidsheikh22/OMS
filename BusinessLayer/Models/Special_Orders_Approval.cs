using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
   public class Special_Orders_Approval
    {

        public int SP_Order_ID { get; set; }
        public int Material { get; set; }
        public int SalesOrganization { get; set; }
        public int Quantity { get; set; }
        public string Aproved { get; set; }
        public int Package_ID { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public float Value { get; set; }
        public string Status { get; set; }
      
        

    }
}
