using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
  public  class user
    {
        public int User_ID { get; set; }
        public int Designation_ID { get; set; }
        public string DesigantionDesc { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime UserCreationDate { get; set; }
        public int IsDeleted { get; set; }
        public string IPAddress { get; set; }
    }
}
