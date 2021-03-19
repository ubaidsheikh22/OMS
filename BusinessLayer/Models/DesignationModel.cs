using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
   public class DesignationModel
    {
        public int Designation_ID { get; set; }
        public string DesigantionDesc { get; set; }
        public int Position { get; set; }
        public DateTime CreationDate { get; set; }
        public int IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public int User_ID { get; set; }
    }
}
