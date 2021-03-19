using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
  public  class CustomerModel
    {
        public int Customer { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string SalesOrganization { get; set; }
        public string DistributionChannel { get; set; }
        public string Division { get; set; }
        public string RegionCode { get; set; }
        public string AreaCode { get; set; }
        public string TerritoryCode { get; set; }
        public string TownCode { get; set; }
        public string DeliveringPlant { get; set; }
        public string RegionDescription { get; set; }
        public string AreaDescription { get; set; }
        public string TerritoryDescription { get; set; }
        public string TownDescription { get; set; }
        public string PlantDescription { get; set; }
        public string packageID { get; set; }
        public string packageName { get; set; }
    }
}
