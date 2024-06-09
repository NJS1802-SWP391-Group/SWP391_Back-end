using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class GetDoneOrderDetailsResponse
    {
        public int OrderDetailId { get; set; }
        public int ResultId { get; set; }
        public string OrderCode { get; set; }
        public string OrderDetailCode { get; set; }
        public string ServiceName { get; set; }
        public string ValuationStaffName { get; set; }
        public double ValuatingPrice { get; set; }
        public string Status { get; set; }

    }
}
