using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SWP391_Project.Databases.DiavanSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.Databases.System.Models
{
    [Table("Assignment")]
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ValuationStaffID { get; set; }
        [ForeignKey("ValuationStaffID")]
        public Account ValuationStaff { get; set; }
        public int? ValuationObjectId { get; set; }
        [ForeignKey("ValuationObjectId")]
        public ValuationObject? ValuationObject { get; set; }
        public DateTime Deadline { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }
}
