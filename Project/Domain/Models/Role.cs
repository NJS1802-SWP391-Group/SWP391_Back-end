using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Role
    {
        [Column(TypeName = "char(2)")]
        public string Id { get; set; }
        [Required]
        [StringLength(10)]
        public string RoleName { get; set; }
    }
}
