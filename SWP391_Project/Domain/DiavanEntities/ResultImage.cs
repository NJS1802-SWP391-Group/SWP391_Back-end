using SWP391_Project.Domain.DiavanEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DiavanEntities
{
    [Table("ResultImage")]
    public class ResultImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultImageID { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public Guid ImageGuid { get; set; }
        public string ImageType { get; set; }
        public int? ResultID { get; set; }
        [ForeignKey("ResultID")]
        public Result? Result { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
