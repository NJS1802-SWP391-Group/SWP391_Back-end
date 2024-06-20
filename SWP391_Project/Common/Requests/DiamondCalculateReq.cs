using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Requests
{
    public class DiamondCalculateReq
    {
        public string Origin { get; set; }
        public string Shape { get; set; }
        public double Carat { get; set; }
        public string Color { get; set; }
        public string Clarity { get; set; }
        public string Fluorescence { get; set; }
        public string Symmetry { get; set; }
        public string Polish { get; set; }
        public string CutGrade { get; set; }
    }
}
