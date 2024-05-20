using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.Databases.DiavanSystem.Models
{
    [Table("TotalCertificate")]
    public class TotalCertificate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Code { get; set; }
        public int Time {  get; set; }
        public string Information {  get; set; }
    }
}
