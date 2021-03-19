using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class SaleOrderLogModel
    {
        public string OrderReferenceNumber { get; set; }
        public string Customer { get; set; }
        public string SalesOrganization { get; set; }
        public string Division { get; set; }
        public string Type { get; set; }
        public string ID { get; set; }
        public string Number { get; set; }
        public string Message { get; set; }
        public string Message_V1 { get; set; }
        public string Message_V2 { get; set; }
        public string Message_V3 { get; set; }
        public string Message_V4 { get; set; }
        public string Parameter { get; set; }
        public string Row { get; set; }
        public string System { get; set; }
        public string LoggedAt { get; set; }
    }
}
