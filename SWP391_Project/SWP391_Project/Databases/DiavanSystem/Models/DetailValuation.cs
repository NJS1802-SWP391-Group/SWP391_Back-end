﻿using SWP391_Project.Databases.System.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.Databases.DiavanSystem.Models
{
    [Table("DetailValuation")]
    public class DetailValuation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code {  get; set; }
        public int ServiceId {  get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
        public double Price { get; set; }
        public string Status {  get; set; }
        public bool? isDiamond { get; set; }
        public ValuationObject? valuationObject { get; set; }
    }
}