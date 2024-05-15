using SWP391_Project.Databases.Models;
using SWP391_Project.Helpers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SWP391_Project.Common.Requests
{
    public class CreateScheduleFormReq
    {
        public DateTime Time { get; set; }
        public int ConsultStaffID { get; set; }
        public int? RequestValuationFormID { get; set; }
        public int? CustomerID { get; set; }
    }
}
