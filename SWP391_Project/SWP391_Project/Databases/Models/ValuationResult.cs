﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SWP391_Project.Databases.Models
{
    [Table("ValuationResult")]
    public class ValuationResult
    {
        [Key]
        public int ValuationResultID { get; set; }
        public int ValuationReceiptDetailID { get; set; }
        [ForeignKey("ValuationReceiptDetailID")]
        public ValuationReceiptDetail ValuationReceiptDetail { get; set; }
        public DateTime Time {  get; set; }
        public string Signature { get; set; }
        public string Status { get; set; }
        public int ValuationStaffID { get; set; }
        [ForeignKey("ValuationStaffID")]
        public User ValuationStaff { get; set; }
    }
}