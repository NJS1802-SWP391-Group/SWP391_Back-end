using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.Databases.Models
{
    [Table("ValuationReceiptDetails")]
    public class ValuationReceiptDetail
    {
        [Key]
        public int ValuationReceiptDetailID {  get; set; }
        public int DiamondID { get; set; }
        [ForeignKey("DiamondID")]
        public Diamond Diamond { get; set; }
        public int ServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public Service Service { get; set; }
        public int ValuationReceiptID { get; set; }
        [ForeignKey("ValuationReceiptID")]
        public ValuationReceipt ValuationReceipt { get; set; }
        public DateTime Date { get; set; }
        public double EstimatePrice { get; set; }
        public string Signature { get; set; }
        public string Status { get; set; }
    }
}
