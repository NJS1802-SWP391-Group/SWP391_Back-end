using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.Databases.DiamondSystem.Models
{
    [Table("Price")]
    public class Price
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PriceId {  get; set; }
        public double? Value { get; set; }
        public DateTime? DayUpdate { get; set; }
        public double? Rate { get; set; }
        public string Status {  get; set; }
        public int DiamondId { get; set; }
        [ForeignKey("DiamondId")]
        public Diamond Diamond { get; set; }
        public string Source { get; set; }
    }
}
