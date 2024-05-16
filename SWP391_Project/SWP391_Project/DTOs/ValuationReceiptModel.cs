using SWP391_Project.Databases.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.DTOs
{
    public class ValuationReceiptModel
    {
        public int ValuationReceiptID { get; set; }
        public int ConsultStaffID { get; set; }
        public DateTime Time { get; set; }
        public string Signature { get; set; }
        public double ReceiptPrice { get; set; }
        public string Status { get; set; }
        public int ScheduleFormID { get; set; }
    }
}
