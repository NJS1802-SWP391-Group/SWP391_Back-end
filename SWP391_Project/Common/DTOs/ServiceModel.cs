
using System.Text.Json.Serialization;

namespace SWP391_Project.DTOs
{
    public class ServiceModel
    {
        public int ServiceID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public List<ServiceDetailModel> ServiceDetails { get; set;}
    }
}
