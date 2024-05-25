using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.DTOs
{
    public class DiamondPriceModel
    {
        public int DiamondPriceID { get; set; }
        public int DiamondID { get; set; }
        public double Price { get; set; }
        public DateTime UpdateTime { get; set; }
        public string? Source { get; set; }
    }
}
