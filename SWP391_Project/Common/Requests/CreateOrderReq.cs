using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Requests
{
    public class CreateOrderReq
    {
        public int CustomerId { get; set; }
        public DateTime Time { get; set; }
        public int? Quantity { get; set; }
    }
}
