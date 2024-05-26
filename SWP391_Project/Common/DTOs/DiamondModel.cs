using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.DTOs
{
    public class DiamondModel
    {
        public int DiamondID { get; set; }
        public string? GIA { get; set; }
        public string? Origin { get; set; }
        public string? Shape { get; set; }
        public string? Carat { get; set; }
        public string? Color { get; set; }
        public string? Clarity { get; set; }
        public string? Fluorescence { get; set; }
        public string? Symmetry { get; set; }
        public string? Polish { get; set; }
        public string? Certificate { get; set; }
        public string? CertificateDate { get; set; }
        public string? Measurement { get; set; }
        public string? CutGrade { get; set; }
        public double? CutScore { get; set; }
        public string? ClarityCharacteristic { get; set; }
        public string? Inscription { get; set; }
        public string? Comments { get; set; }
        public string Status { get; set; }
    }
}
