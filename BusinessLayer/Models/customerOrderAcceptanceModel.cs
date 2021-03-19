using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class customerOrderAcceptanceModel
    {
        public int customer { get; set; }
        public int Material { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPayable { get; set; }
        public int Quantity { get; set; }
        public int WeeklyQuantityAmount { get; set; }
        public int WeeklyQuantity { get; set; }
        public int FirmOrder { get; set; }
        public int FirmOrderAmount { get; set; }
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int Sunday { get; set; }
        public bool IsAccepted { get; set; }
        public string CALDAY { get; set; }

        public string OrderRefrenceNumber { get; set; }
        public double SpecialQuanity { get; set; }
        public double SpecialQuanityAmount { get; set; }
        public int TotalValue { get; set; }
        public string CustomerName { get; set; }
        public double totalOrder { get; set; }

        public double TotalFirmPrice { get; set; }
        public double TotalSpecialOrderPrice { get; set; }

        public int MondayValue { get; set; }
        public int TuesdayValue { get; set; }
        public int WednesdayValue { get; set; }
        public int ThursdayValue { get; set; }
        public int FridayValue { get; set; }
        public int SaturdayValue { get; set; }
        public int SundayValue { get; set; }
        public string SalesOrganization { get; set; }
        public string RegionDescription { get; set; }
        public string SKUMapping { get; set; }
        public string DistributionChannel { get; set; }
        public string Division { get; set; }
    }
}