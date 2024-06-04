using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Requests
{
    public class UpdateOrderDetail
    {
        public int OrderDetailId { get; set; }
        public int ServiceId { set; get; }
        public double EstimateLength { set; get; }
    }
}
