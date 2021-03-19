using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class SubstituteModel
    {
        public int Id { get; set; }
        public int AssignedTo { get; set; }
        public string AssignedToName { get; set; }
        public int AssignedFrom { get; set; }
        public string AssignedFromName { get; set; }
        public string  Reason { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public int IsActive { get; set; }
        public int Index { get; set; }
        public string AssignedToRole { get; set; }
        public string AssignedFromRole { get; set; }
        public int User_ID { get; set; }
        public String User_Name { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }

}
