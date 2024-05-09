using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.Databases.Models
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogName { get; set; }
        public string Content { get; set; }
        public string Image {  get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
