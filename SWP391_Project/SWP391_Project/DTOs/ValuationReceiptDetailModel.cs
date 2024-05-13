using SWP391_Project.Databases.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.DTOs
{
    public class ValuationReceiptDetailModel
    {
        public int ValuationReceiptDetailsID { get; set; }
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
