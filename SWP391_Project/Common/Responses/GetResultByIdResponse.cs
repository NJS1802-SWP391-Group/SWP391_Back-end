using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class GetResultByIdResponse
    {
        public int ResultId { get; set; }
        public bool IsDiamond { get; set; }
        public string? Code { get; set; }
        public string? Origin { get; set; }
        public string? Shape { get; set; }
        public double? Carat { get; set; }
        public string? Color { get; set; }
        public string? Clarity { get; set; }
        public string? Fluorescence { get; set; }
        public string? Symmetry { get; set; }
        public string? Polish { get; set; }
        public string? CutGrade { get; set; }
        public string? Description { get; set; }
        public double? DiamondValue { get; set; }
        public string Status { get; set; }
        public int OrderDetailId { get; set; }
        public List<ResultImages> ResultImages { get; set; } = new List<ResultImages>();
    }

    public class ResultImages
    {
        public string? ImageUrl { get; set; }
        public string? ImageType { get; set; }
    }
}
