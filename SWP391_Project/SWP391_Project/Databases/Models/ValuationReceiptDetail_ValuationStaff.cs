using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.Databases.Models
{
    [Table("ValuationReceiptDetail_ValuationStaff")]
    public class ValuationReceiptDetail_ValuationStaff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID {  get; set; }
        public int ValuationStaffID { get; set; }
        [ForeignKey("ValuationStaffID")]
        public User ValuationStaff { get; set; }
        public int ValuationReceiptDetailID { get; set; }
        [ForeignKey("ValuationReceiptDetailID")]
        public ValuationReceiptDetail ValuationReceiptDetail { get; set; }
        public DateTime Deadline { get; set; }
        public string Location {  get; set; }
        public string Status { get; set; }
    }
}
