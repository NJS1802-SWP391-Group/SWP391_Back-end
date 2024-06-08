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
        public int CustomerId { get; set; }
    }
}
