using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.DTOs
{
    public class DiamondModel
    {
        public int DiamondId { get; set; }
        public string? Origin { get; set; }
        public string? Shape { get; set; }
        public double? Carat { get; set; }
        public string? Color { get; set; }
        public string? Clarity { get; set; }
        public string? Fluorescence { get; set; }
        public string? Symmetry { get; set; }
        public string? Polish { get; set; }
        public string? CutGrade { get; set; }
        public double? Value { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Source { get; set; }
        public string Status { get; set; }
    }
}
