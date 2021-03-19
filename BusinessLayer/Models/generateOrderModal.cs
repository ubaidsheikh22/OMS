using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class generateOrderModal
    {
        public int orderID { get; set; }
        public string CALDAY { get; set; }
        public string COMP_CODE { get; set; }
        public string SALESORG { get; set; }
        public string DISTR_CHAN { get; set; }
        public string DIVISION { get; set; }
        public string MATERIAL { get; set; }
        public string CUSTOMER { get; set; }
        public string BPCTOTPAGE { get; set; }
        public string Order_Qty { get; set; }
        public string Description { get; set; }
        public string Order_Ref { get; set; }
        public string custDATEReport { get; set; }
        public string customerName { get; set; }
        public string weekNumber { get; set; }
        public string materialDesc { get; set; }

        public double MaterialTotalValues { get; set; }
        public double UnitPrice { get; set; }
        public string MaterialGroup { get; set; }
        public string MaterialGroupdescription { get; set; }

        public double DistributorClosingStock { get; set; }
        public int SafetyStock { get; set; }
        public double QTY { get; set; }
        
        public int RSFQTY { get; set; }
        public int MonthlySalesforcast { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RegionDescription { get; set; }
        public string TownDescription { get; set; }
        public string TerritoryDescription { get; set; }
        public string AreaDescription { get; set; }
        public string SKUMapping { get; set; }
        public string MaterialGroup1_Description { get; set; }
        public string MaterialGroup2_Description { get; set; }
        public string MaterialGroup3_Description { get; set; }
        public string MaterialGroup4_Description { get; set; }
        public string MatPricingGrpDescription { get; set; }
        public string AcceptedOrder { get; set; }
        public string SpecialOrder { get; set; }
        public string weeklyrsf { get; set; }
        public string monthlyRSF { get; set; }
        public string TotalOrders { get; set; }
        public string suggestedOrder { get; set; }
        public string InTransitOrder { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
        public string MaxDay { get; set; }
    }
    public class generateOrderModalGrid : generateOrderModal
    {
        public int distinctValue { get; set; }
        

    }
}
