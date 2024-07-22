using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.DTOs
{
    public class ServiceDetailModel
    {
        public int ServiceDetailID { get; set; }
        public string Code { get; set; }
        public double MinRange { get; set; }
        public double MaxRange { get; set; }
        public double Price { get; set; }
        public double ExtraPricePerMM { get; set; }
        public string Status { get; set; }
    }
}
