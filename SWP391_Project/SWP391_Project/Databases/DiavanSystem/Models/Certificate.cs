using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SWP391_Project.Databases.DiavanSystem.Models;

namespace SWP391_Project.Databases.System.Models
{
    [Table("Certificate")]
    public class Certificate
    {
        [Key]
        public int CertificateId { get; set; }
        public int ResultId { get; set; }
        [ForeignKey("ResultId")]
        public Result Result { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Signature { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
