using SWP391_Project.Databases.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.DTOs
{
    public class ScheduleFormModel
    {
        public int ScheduleFormID { get; set; }
        public DateTime Time { get; set; }
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
