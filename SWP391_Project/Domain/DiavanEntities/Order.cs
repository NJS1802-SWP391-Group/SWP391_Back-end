using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.Domain.DiavanEntities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public string Code { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public DateTime Time {  get; set; }
        public int? Quantity { get; set; }
        public double? TotalPay { get; set; } = 0;
        public string? Payment {  get; set; }
        public string? StatusPayment { get; set; }
        public string? Status { get; set; }
        public virtual List<OrderDetail>? DetailValuations { get; set; }
    }
}
