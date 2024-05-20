using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SWP391_Project.Databases.DiavanSystem.Models;

namespace SWP391_Project.Databases.System.Models
{
    [Table("ValuationResult")]
    public class ValuationResult
    {
        [Key]
        public int ValuationResultID { get; set; }
        public int AssignmentID { get; set; }
        [ForeignKey("AssignmentID")]
        public Assignment Assignment { get; set; }
        public DateTime Time { get; set; }
        public string Signature { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int? TotalCertificateId {  get; set; }
        [ForeignKey("TotalCertificateId")]
        public TotalCertificate? TotalCertificate {  get; set; }
    }
}
