using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SWP391_Project.Exceptions;

namespace SWP391_Project.Databases.Models
{
    [Table("Diamond")]
    public class Diamond
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiamondID { get; set; }
        public string GIA { get; set; }
        public string Type { get; set; }
        public string Shape { get; set; }
        public string Carat { get; set; }
        public string Color { get; set; }
        public string Clarity { get; set; }
        public string Fluorescence { get; set; }
        public string Symmetry { get; set; }
        public string Polish { get; set; }
        public string Certificate { get; set; }
        public string CertificateDate { get; set; }
        public string Measurement { get; set; }
        public string CutGrade { get; set; }
        public double CutScore { get; set; }
        public string ClarityCharacteristic { get; set; }
        public string Inscription { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public int ServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public Service Service { get; set; }
        public int RequestValidationFormID {  get; set; }
        [ForeignKey("ValuationReceiptID")]
        public ValuationReceipt requestValidationForm { get; set; }
    }
}
