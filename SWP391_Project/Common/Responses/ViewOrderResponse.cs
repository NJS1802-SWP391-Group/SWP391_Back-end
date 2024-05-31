using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class ViewOrderResponse
    {
        public int OrderID { get; set; }
        public string Code { get; set; }
        public int CustomerId {  get; set; }
        public int? Quantity { set; get; }
        public DateTime Time { set; get; }
        public string? Status { set; get; }
    }
}
