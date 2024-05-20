using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.DTOs
{
    public class ValuationResultModel
    {
        public int ValuationResultID { get; set; }
        public int ValuationReceiptDetailID { get; set; }
        public DateTime Time { get; set; }
        public string Signature { get; set; }
        public string Status { get; set; }
        public int ValuationStaffID { get; set; }
    }
}
