using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
   public class MaterialModel
    {
        public int DistributionChannel { get; set; }
        public int Division { get; set; }
        public int Materialpricinggrp { get; set; }
        public int Materialgroup1 { get; set; }
        public int Materialgroup2 { get; set; }
        public int Materialgroup3 { get; set; }
        public int Materialgroup4 { get; set; }
        public int Materialgroup5 { get; set; }
        public int MaterialGroup { get; set; }
        public string MaterialType { get; set; }
        public string Description { get; set; }
        public string MatPricingGrpDescription { get; set; }

        public string MaterialGroup1_Description { get; set; }
        public string MaterialGroup2_Description { get; set; }
        public string MaterialGroup3_Description { get; set; }
        public string MaterialGroup4_Description { get; set; }
        public string MaterialGroup5_Description { get; set; }
        public string MaterialGroupdescription { get; set; }
        public string MaterialTypeDescripiton { get; set; }

    }
}
