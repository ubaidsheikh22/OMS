using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
   public class DashboardModel
    {
        public string TotalOrder { get; set; }
        public string TotalQuantity { get; set; }
        public string TotalFirmOrder { get; set; }

        public string RegionDescription { get; set; }
        public int NoOfOrders { get; set; }
        public long OrderValues { get; set; }
        public string Division { get; set; }
        public string Salesorg { get; set; }

        public string SuggestedOrder { get; set; }
        public string FirOrderValue { get; set; }

        public string SpeacialQty { get; set; }
        public string SpeacialValue { get; set; }
        public double suggestedValue { get; set; }
        public double InTransactionQty { get; set; }
        public double InTransactionQtyValue { get; set; }
        public double PendingQty { get; set; }
        public double PendingQtyValue { get; set; }
        public string OrderDescription { get; set; }
        public decimal suggestedValues { get; set; }
    }
}
