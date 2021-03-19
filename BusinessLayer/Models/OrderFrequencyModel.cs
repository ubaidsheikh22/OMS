using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
 public   class OrderFrequencyModel
    {
        public int Day_frequency_ID { get; set; }
        public int Customer_Code { get; set; }

        public string Customer_Name { get; set; }
        public string Customer_PostalAddress { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Customer_category { get; set; }
        public string Contact_PersonCell { get; set; }


        public int CheckMonday { get; set; }
        public int CheckTuesday { get; set; }
        public int CheckWednesday { get; set; }
        public int CheckThursday { get; set; }
        public int CheckFriday { get; set; }
        public int CheckSaturday { get; set; }
        public int CheckSunday { get; set; }



        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }

    
    }
}
