using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.Databases.Models
{
    public class Role
    {
        [Column(TypeName = "char(2)")]
        public string Id { get; set; }
        [Required]
        [StringLength(30)]
        public string RoleName { get; set; }
    }
}
