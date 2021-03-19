using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class weeklyOrderModel
    {
        public int materialCode { get; set; }
        public string materialDescription { get; set; }
        public double unitPrice { get; set; }
        public int totalWeeklyOrder { get; set; }
        public int orderQuantity { get; set; }
        public int firmOrder { get; set; }
        public string comment { get; set; }
        public int recievedQuantity { get; set; }
        public DateTime datetime { get; set; }
    }
}