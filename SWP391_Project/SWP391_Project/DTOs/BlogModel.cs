using SWP391_Project.Databases.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.DTOs
{
    public class BlogModel
    {
        public int BlogID { get; set; }
        public string BlogName { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int UserID { get; set; }
    }
}
