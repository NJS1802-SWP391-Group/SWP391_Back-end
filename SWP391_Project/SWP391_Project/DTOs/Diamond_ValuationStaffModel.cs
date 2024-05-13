using SWP391_Project.Databases.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWP391_Project.DTOs
{
    public class Diamond_ValuationStaffModel
    {
        public int ID { get; set; }
        public int ValuationStaffID { get; set; }
        [ForeignKey("ValuationStaffID")]
        public User ValuationStaff { get; set; }
        public int DiamondID { get; set; }
        [ForeignKey("DiamondID")]
        public Diamond Diamond { get; set; }
        public DateTime Deadline { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }
}
