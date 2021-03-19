using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class distributorFrequencyModel
    {
        public float Monday { get; set; }
        public float Tuesday { get; set; }
        public float Wednesday { get; set; }
        public float Thursday { get; set; }
        public float Friday { get; set; }
        public float Saturday { get; set; }
        public float Sunday { get; set; }
        public int Customer { get; set; }
        public string Name1 { get; set; }
        public int Division { get; set; }
        public string RegionDescription { get; set; }
        public int SalesOrganization { get; set; }
    }
}
