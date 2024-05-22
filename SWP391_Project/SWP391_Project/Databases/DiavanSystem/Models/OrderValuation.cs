using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SWP391_Project.Databases.DiavanSystem.Models;

namespace SWP391_Project.Databases.System.Models
{
    [Table("OrderValuation")]
    public class OrderValuation
    {
        [Key]
        public int ID { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public DateTime Time {  get; set; }
        public string? Quantity { get; set; }
        public double? TotalPay { get; set; }
        public string? Payment {  get; set; }
        public string? StatusPayment { get; set; }
        public string? Status { get; set; }
        public List<DetailValuation> DetailValuations { get; set; }
    }
}
