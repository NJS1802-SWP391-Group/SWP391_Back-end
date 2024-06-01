using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class ViewOrderResult
    {
        public int OrderID { get; set; }
        public string Code { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { set; get; }
        public DateTime Time { set; get; }
        public string Status { set; get; }
        public double TotalPay { set; get; }
        public List<ViewOrderDetailResult> DetailValuations { set; get; }
    }
    public class ViewOrderDetailResult
    {
        public int OrderDetailId{ get; set; }
        public string Code{set; get;}
        public string ServiceName{ set; get; }
        public double EstimateLength{ set; get; }
        public double Price { set; get; }
    }
}
