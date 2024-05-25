using SWP391_Project.Databases.System.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.Databases.DiavanSystem.Models
{
    [Table("ServiceDetail")]
    public class ServiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Size {  get; set; }
        public double MinRange {  get; set; }
        public double MaxRange { get; set; }
        public double Price { get; set; }
        public double Status { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
    }
}
