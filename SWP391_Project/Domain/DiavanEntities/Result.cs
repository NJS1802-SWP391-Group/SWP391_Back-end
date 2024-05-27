using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.Domain.DiavanEntities
{
    [Table("Result")]
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultId { get; set; }
        public bool IsDiamond { get; set; }
    //  public string? GIACode { get; set; }
        public string? Code { get; set; }
        public string? Origin { get; set; }
        public string? Shape { get; set; }
        public string? Carat { get; set; }
        public string? Color { get; set; }
        public string? Clarity { get; set; }
        public string? Fluorescence { get; set; }
        public string? Symmetry { get; set; }
        public string? Polish { get; set; }
        public string? CutGrade { get; set; }
        public string ValueStatus { get; set; }
        public string? Description { get; set; }
        public double? DiamondValue  { get; set; }
        public string Status { get; set; }
        public int OrderDetailId { get; set; }
        [ForeignKey("OrderDetailId")]
        public OrderDetail OrderDetail { get; set; }  
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        //public string? Signature { get; set; }
        public string? CertificateStatus { get; set; }
    }
}
