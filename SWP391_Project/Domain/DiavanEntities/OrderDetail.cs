using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SWP391_Project.Domain.DiavanEntities
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        public string Code {  get; set; }
        public double EstimateLength { get; set; }
        public int ServiceId {  get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
        public double Price { get; set; }
        public string Status {  get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        [JsonIgnore]
        public Order Order { get; set; }
        public int? ValuationStaffId { get; set; }
        [ForeignKey("ValuationStaffId")]
        public Account? ValuationStaff {  get; set; }
        public int? ResultId { get; set; }
        [ForeignKey("ResultId")]
        public Result? Result { get; set; }
    }
}
