﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.DiamondEntities
{
    [Table("DiamondCheck")]
    public class DiamondCheck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiamondCheckId { get; set; }
        public string? CertificateId { get; set; }
        public string? Origin { get; set; }
        public string? Shape { get; set; }
        public double? Carat { get; set; }
        public string? Color { get; set; }
        public string? Clarity { get; set; }
        public string? Fluorescence { get; set; }
        public string? Symmetry { get; set; }
        public string? Polish { get; set; }
        public string? CutGrade { get; set; }
        public string? CutScore { get; set; }
        public DateTime? CertDate { get; set; }
        public string? Measurement { get; set; }
        public string? ClarityCharacteristic { get; set; }
        public string? Comment { get; set; }
        public string Status { get; set; }
        public List<DiamondCheckValue> DiamondCheckValues { get; set; }
    }
}
