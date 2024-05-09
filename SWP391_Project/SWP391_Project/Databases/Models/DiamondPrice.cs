using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SWP391_Project.Databases.Models
{
    [Table("DiamondPrice")]
    public class DiamondPrice
    {
        [Key]
        public int DiamondPriceID { get; set; }
        public int DiamondID { get; set; }
        [ForeignKey("DiamondID")]
        public Diamond Diamond { get; set; }
        public double Price { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
