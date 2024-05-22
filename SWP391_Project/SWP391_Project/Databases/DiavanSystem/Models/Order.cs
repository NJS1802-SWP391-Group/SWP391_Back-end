using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SWP391_Project.Databases.DiavanSystem.Models;

namespace SWP391_Project.Databases.System.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public DateTime Time {  get; set; }
        public string? Quantity { get; set; }
        public double? TotalPay { get; set; }
        public string? Payment {  get; set; }
        public string? StatusPayment { get; set; }
        public string? Status { get; set; }
        public List<OrderDetail> DetailValuations { get; set; }
    }
}
