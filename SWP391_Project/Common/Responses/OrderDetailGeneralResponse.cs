using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class OrderDetailGeneralResponse
    {
        public string OrderCode { get; set; }
        public string OrderDetailCode { get; set; }
        public string ServiceName { get; set; }
        public double EstimateLength { get; set; }
        public double ServicePrice { get; set; }
        public string ValuationStaffName { get; set; }
        public string ResultPrice { get; set; }
        public string Status { get; set; }
    }
}
