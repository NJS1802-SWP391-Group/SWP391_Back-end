using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.Domain.DiavanEntities
{
    [Table("ServiceDetail")]
    public class ServiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceDetailID { get; set; }
        public string Code {  get; set; }
        public double MinRange {  get; set; }
        public double MaxRange { get; set; }
        public double Price { get; set; }
        public double ExtraPricePerMM { get; set; }
        public string Status { get; set; }
        public int ServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public Service Service { get; set; }
    }
}
