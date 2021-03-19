using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class secondarySalesModel
    {
        public string CalendarDay { get; set; }
        public int Company { get; set; }
        public int SalesOrganization { get; set; }
        public int DistributionChannel { get; set; }
        public int Division { get; set; }
        public int CustomerSoldToParty { get; set; }
        public string Name1 { get; set; }
        public string CustomerName2 { get; set; }

        public string RegionDescription { get; set; }
        public string AreaDescription { get; set; }
        public string TerritoryDescription { get; set; }
        public string TownDescription { get; set; }
        public int Material { get; set; }

        public string MatPricingGrpDescription { get; set; }
        public string MaterialGroup1_Description { get; set; }
        public string MaterialGroup2_Description { get; set; }
        public string MaterialGroup3_Description { get; set; }
        public string MaterialGroup4_Description { get; set; }
        public string MaterialGroup5_Description { get; set; }
        public string MaterialGroupdescription { get; set; }

        public string UOM { get; set; }
        public double Quantity { get; set; }

     



        public string Description { get; set; }


    }
}
