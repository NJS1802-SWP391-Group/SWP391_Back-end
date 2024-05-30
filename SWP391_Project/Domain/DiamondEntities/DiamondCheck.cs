using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.DiamondEntities
{
    [Table("DiamondCheck")]
    public class DiamondCheck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiamondCheckId { get; set; }
        public string? CertificateCode { get; set; }
        public string? Origin { get; set; }
        public string? Shape { get; set; }
        public string? Carat { get; set; }
        public string? Color { get; set; }
        public string? Clarity { get; set; }
        public string? Fluorescence { get; set; }
        public string? Symmetry { get; set; }
        public string? Polish { get; set; }
        public string? CutGrade { get; set; }
        public string? CutScore { get; set; }
        public double? FairPrice { get; set; }
        public DateTime? CertDate { get; set; }
        public string? Measurement { get; set; }
        public string? ClarityCharacteristic { get; set; }
        public string? Comment { get; set; }
        public string Status { get; set; }
    }
}
