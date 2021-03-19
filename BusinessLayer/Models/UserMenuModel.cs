using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class UserMenuModel
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Screens { get; set; }
        public string Email { get; set; }
        public string Action { get; set; }
        public string SetupForms { get; set; }
        public string MasterData { get; set; }
        public string TransactionForms { get; set; }
        public string ReviewOrders { get; set; }
        public string ClaimForms { get; set; }
        public string Summary { get; set; }
        public string Reports { get; set; }
        public string UserName { get; set; }
    }
}
