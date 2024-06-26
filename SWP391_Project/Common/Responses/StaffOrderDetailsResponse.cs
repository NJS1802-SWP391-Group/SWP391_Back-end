using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class StaffOrderDetailsResponse
    {
        public int OrderDetailId { get; set; }
        public string OrderDetailCode { get; set; }
        public string ServiceName {  get; set; }
        public double FinalPrice { get; set; }
        public int ResultID { get; set; }
        public string Status {  get; set; }
    }
}
