using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.Databases.System.Models
{
    [Table("Service")]
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
    }
}
