using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer.Models
{
    public class SafetyStockModel
    {
        public string customer { get; set; }
        public string CustomerName { get; set; }
        public string material { get; set; }
        public string MaterialDescription { get; set; }
        public string division { get; set; }
        public string MyProperty { get; set; }
        public string salesOrg { get; set; }
        public string distr_chan { get; set; }
        public string region { get; set; }
        public string area { get; set; }
        public string territory { get; set; }
        public string town { get; set; }
        public string quantity { get; set; }


        public string Resume { get; set; }
        public HttpPostedFileBase ResumeFile { get; set; }
    }
}
