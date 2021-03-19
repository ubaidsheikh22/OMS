using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class packageFrequencyModel
    {
        public int Day_frequency_ID { get; set; }
        public int Package_ID { get; set; }
        public string PackageName { get; set; }
        public string Customer_Code { get; set; }
        public string Name1 { get; set; }
        public DateTime Date { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
    }
}
