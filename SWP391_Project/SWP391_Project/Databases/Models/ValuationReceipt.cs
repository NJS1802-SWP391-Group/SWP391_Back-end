using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.Databases.Models
{
    public class ValuationReceipt
    {
        [Key]
        public int ValuationReceiptID { get; set; }
        public int ValuationStaffID { get; set; }
        [ForeignKey("ValuationStaffID")]
        public User ValuationStaff { get; set; }
        public int ConsultStaffID { get; set; }
        [ForeignKey("ConsultStaffID")]
        public User ConsultStaff { get; set; }
        public DateTime Time {  get; set; }
        public string Signature { get; set; }
        public double ReceiptPrice { get; set; }
        public string Status { get; set; }
        public int ScheduleFormID { get; set; }
        [ForeignKey("ScheduleFormID")]
        public ScheduleForm ScheduleForm { get; set; }
        public int ServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public Service Service { get; set; }

    }
}
