using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DiamondEntities
{
    [Table("DiamondCheckValue")]
    public class DiamondCheckValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiamondCheckValueId { get; set; }
        public DateTime UpdateDay { get; set; }
        public double Price {  get; set; }
        public int DiamondCheckId {  get; set; }
        [ForeignKey("DiamondCheckId")]
        virtual public DiamondCheck DiamondCheck { get; set; }
    }
}
