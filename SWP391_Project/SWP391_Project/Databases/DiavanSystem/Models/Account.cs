using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.Databases.DiavanSystem.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status {  get; set; }
        public string RoleName {  get; set; } 
    }
}
