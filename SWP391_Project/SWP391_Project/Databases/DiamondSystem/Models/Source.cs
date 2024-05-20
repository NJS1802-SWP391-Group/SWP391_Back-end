using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.Databases.DiamondSystem.Models
{
    [Table("Source")]
    public class Source
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SourceId {  get; set; }
        public int Name {  get; set; }
        public string Description { get; set; }
        public string Status {  get; set; }
    }
}
