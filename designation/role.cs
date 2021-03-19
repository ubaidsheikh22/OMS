using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class role
    {
        public int role_ID { get; set; }
        public string roleDesc { get; set; }
        public int userID { get; set; }
    }
}
