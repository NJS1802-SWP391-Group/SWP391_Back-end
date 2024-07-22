using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SWP391_Project.Dtos
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string RoleName { get; set; }
        public string Email {  get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Cccd {  get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob {  get; set; }
        public string Address { get; set; }
        public int CustomerId { get; set; }
    }
}
