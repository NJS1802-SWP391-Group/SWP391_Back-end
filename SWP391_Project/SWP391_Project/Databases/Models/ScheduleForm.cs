using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.Databases.Models
{
    [Table("ScheduleForm")]
    public class ScheduleForm
    {
        [Key]
        public int ScheduleFormID { get; set; }
        public DateTime Time {  get; set; }
        public int ConsultStaffID { get; set; }
        [ForeignKey("ConsultStaffID")]
        public User ConsultStaff { get; set; }
        public string Status { get; set; }
        public int? RequestValuationFormID { get; set; }
        [ForeignKey("RequestValuationFormID")]
        public RequestValuationForm? RequestValuationForm { get; set; }
        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public User? Customer { get; set; }
    }
}
