using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer.Models
{
    public class pendingQuantities
    {
        public int pendingQtyID { get; set; }
        public string materialCode { get; set; }
        public string materialDescription { get; set; }
        public string salesOrganization { get; set; }
        public string division { get; set; }
        public decimal unitPrice { get; set; }
        public decimal ClaimValue { get; set; }
        public int orderQuantity { get; set; }
        public int recievedQuantity { get; set; }
        public int ManualClaimedQty { get; set; }
        public string ManualBatchNo { get; set; }
        public int commentID { get; set; }
        public string day { get; set; }
        public string Order_Ref { get; set; }
        public string ClaimComment { get; set; }
        public string ReceivingComments { get; set; }
        public string Aproved { get; set; }

        public int newApproved { get; set; }

        public string Resume { get; set; }
        public HttpPostedFileBase ResumeFile { get; set; }


        public int Damaged { get; set; }
        public int Expired { get; set; }
        public int Short { get; set; }
        public int TotalClaimed { get; set; }
        public int Execss { get; set; }
        public int wrong_SKU { get; set; }
        public int BillingId { get; set; }
        public string BillingNo { get; set; }
        public string Status { get; set; }
        public string title { get; set; }
        public string referenceId { get; set; }
        public string filepath { get; set; }
       
    }
}