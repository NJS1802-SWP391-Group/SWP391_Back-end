using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.DTOs
{
    public class ValuationReceiptDetail_ValuationStaffModel
    {
        public int ID { get; set; }
        public int ValuationStaffID { get; set; }
        public int ValuationReceiptDetailID { get; set; }
        public DateTime Deadline { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }
}
