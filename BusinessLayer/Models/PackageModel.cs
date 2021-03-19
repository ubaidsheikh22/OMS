using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
   public class PackageModel
    {
        public int Package_ID { get; set;   }
        public string PackageName { get; set; }
        public int User_ID { get; set; }
        public string UserName { get; set; }
    }
}
