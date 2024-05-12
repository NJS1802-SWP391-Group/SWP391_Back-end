using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.Databases.Models
{
    [Table("RequestValuationForm")]
    public class RequestValuationForm
    {
        [Key]
        public int RequestValuationFormID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CCCD { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Quantity { get; set; }
        public string Status { get; set; }
    }
}
