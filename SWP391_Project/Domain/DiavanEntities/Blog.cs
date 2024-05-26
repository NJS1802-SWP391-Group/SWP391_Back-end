using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.Domain.DiavanEntities
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; }
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Account Admin { get; set; }
        public string Status { get; set; }
    }
}
