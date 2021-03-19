using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
  public  class RoleModel
    {
        public int Role_ID { get; set; }
        [Required(ErrorMessage = "Please Enter Role Name")]
        public string Rele_Desc { get; set; }
        public int User_ID { get; set; }
        public string UserName { get; set; }

    }
}
