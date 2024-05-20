using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SWP391_Project.Databases.DiavanSystem.Models;

namespace SWP391_Project.Databases.System.Models
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; }
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Account Admin { get; set; }
    }
}
