using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SWP391_Project.Databases.DiavanSystem.Models;

namespace SWP391_Project.Databases.System.Models
{
    [Table("ValuationCertificate")]
    public class ValuationCertificate
    {
        [Key]
        public int ValuationCertificateId { get; set; }
        public int ValuationResultId { get; set; }
        [ForeignKey("ValuationResultId")]
        public ValuationResult ValuationResult { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Signature { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
