using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class UpdatePassword
    {
        public string User_ID { get; set; }
        public string Pass { get; set; }
        public string NewPass { get; set; }
    }
}
