using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class DiamondCalculateResponse
    {
        public string? Origin { get; set; }
        public string? Shape { get; set; }
        public double? Carat { get; set; }
        public string? Color { get; set; }
        public string? Clarity { get; set; }
        public double? FairPrice { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public double? Last30DayChange { get; set; }
        public double? PricePerCarat { get; set; }
    }
}
