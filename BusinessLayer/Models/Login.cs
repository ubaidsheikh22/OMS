using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
   public class Login
    {
        public int User_ID { get; set; }
        public int Login_ID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Pass { get; set; }
        public string NewPass { get; set; }
        public int Role_ID { get; set; }
        public string Distributor_ID { get; set; }
        public string Distributor_Name { get; set; }

        public string RegionCode { get; set; }
        public string AreaCode { get; set; }
        public string TerritoryCode { get; set; }
        public string TownCode { get; set; }

        public string RegionDesc { get; set; }
        public string AreaDesc { get; set; }
        public string TerritoryDesc { get; set; }
        public string TownDesc { get; set; }

        public int IsLogin { get; set; }
        public string IPAddress { get; set; }
        public DateTime UserCreationDate { get; set; }
        public int IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public int Package_ID { get; set; }
        public string Position { get; set; }
        public string Message { get; set; }
        public string PackageName { get; set; }
        public string Customer { get; set; }

        public string RegionDesc2 { get; set; }
        public int AreaCode2 { get; set; }
        public int TerritoryCode2 { get; set; }
        public int TownCode2 { get; set; }
        public string SalesOrg { get; set; }
        public string Distribution { get; set; }
        public string Division { get; set; }
        public int UserNameAD { get; set; }
        public int AssignedFromRole { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public bool Active { get; set; }
    }
}
