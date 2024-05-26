using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SWP391_Project.Domain.DiavanEntities
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        public string Code {  get; set; }
        public double Range { get; set; }
        public int ServiceId {  get; set; }
        [ForeignKey("ServiceDetailId")]
        public ServiceDetail ServiceDetail { get; set; }
        public double Price { get; set; }
        public string Status {  get; set; }
        public bool? isDiamond { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public int? ValuationStaffId { get; set; }
        [ForeignKey("ValuationStaffId")]
        public Account? ValuationStaff {  get; set; }
        public int? ResultId { get; set; }
        [ForeignKey("ResultId")]
        public Result? Result { get; set; }
    }
}
