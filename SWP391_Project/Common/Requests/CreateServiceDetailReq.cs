using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.Common.Requests
{
    public class CreateServiceDetailReq
    {
        public string Code { get; set; }
        public double MinRange { get; set; }
        public double MaxRange { get; set; }
        public double Price { get; set; }
        public double ExtraPricePerMM { get; set; }
        public int ServiceID { get; set; }
    }
}
