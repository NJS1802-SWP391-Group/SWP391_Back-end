using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.DTOs
{
    public class FinalReceiptModel
    {
        public int FinalReceiptID { get; set; }
        public string Signature { get; set; }
        public int ValuationResultID { get; set; }
        public int ManagerID {  get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
    }
}
