using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.Databases.Models
{
    [Table("FinalReceipt")]
    public class FinalReceipt
    {
        [Key]
        public int FinalReceiptID { get; set; }
        public string Signature { get; set; }
        public int ValuationResultID { get; set; }
        [ForeignKey("ValuationResultID")]
        public ValuationResult ValuationResult { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
    }
}
