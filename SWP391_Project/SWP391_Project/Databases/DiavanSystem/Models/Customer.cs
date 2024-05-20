using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using SWP391_Project.Databases.DiavanSystem.Models;

namespace SWP391_Project.Databases.System.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public DateOnly Dob {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CCCD { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
