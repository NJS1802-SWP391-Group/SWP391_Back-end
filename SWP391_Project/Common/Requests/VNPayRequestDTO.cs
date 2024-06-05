using System.ComponentModel.DataAnnotations;
namespace Common.Requests

{
    public class VNPayRequestDTO
    {
        public int userId {  get; set; }
        [Url]
        public string urlResponse { get; set; } = null!;
    }
}
