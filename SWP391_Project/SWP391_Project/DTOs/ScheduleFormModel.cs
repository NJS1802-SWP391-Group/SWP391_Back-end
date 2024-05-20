using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.DTOs
{
    public class ScheduleFormModel
    {
        public int ScheduleFormID { get; set; }
        public DateTime Time { get; set; }
        public int ConsultStaffID { get; set; }
        public string Status { get; set; }
        public int? RequestValuationFormID { get; set; }
        public int? CustomerID { get; set; }
    }
}
