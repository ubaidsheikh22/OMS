using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class salesForcastModel
    {
        public string CalendarDay { get; set; }
        public int Company { get; set; }
        public int SalesOrganization { get; set; }
        public int DistributionChannel { get; set; }
        public int Division { get; set; }
        public int Plant { get; set; }
        public int CustomerSoldToParty { get; set; }
        public int CustomerPayer { get; set; }
        public int Material { get; set; }
        public double Quantity { get; set; }

        public bool Flag { get; set; }

        public int Customer { get; set; }
        public string Name1 { get; set; }

        public string ZDOC_CATG { get; set; }
        public string ZBPCACC { get; set; }
        public string ZBPCVERS { get; set; }

        public string MaterialDescription { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string MaterialCode { get; set; }

        public int Payer { get; set; }

        public string GrWtKg { get; set; }
        public string GRNetKg { get; set; }

        public string Name2 { get; set; }
        public string RegionDescription { get; set; }

        public string AreaDescription { get; set; }
        public string TerritoryDescription { get; set; }
        public string TownDescription { get; set; }
    }
}
