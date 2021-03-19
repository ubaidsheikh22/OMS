using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
   public class WeeklyUpliftsModel
    {
        public int Material { get; set; }
        public int SalesOrganization { get; set; }
        public int DistributionChannel { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Region { get; set; }
        public int Customer { get; set; }
        public float Percentage { get; set; }
    }
}
