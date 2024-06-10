using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class ViewFullInfomaionOrder
    {
            public int OrderID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Code { get; set; }
            public int CustomerId { get; set; }
            public int Quantity { set; get; }
            public DateTime Time { set; get; }
            public string Status { set; get; }
            public double TotalPay { set; get; }
            public string Payment { get; set; }
            public string StatusPayment { get; set; }
            public List<ViewOrderDetail> DetailValuations { set; get; }
    }
        public class ViewOrderDetail
        {
            public int OrderDetailId { get; set; }
            public string Code { set; get; }
            public string ServiceName { set; get; }
            public double EstimateLength { set; get; }
            public string Status {  set; get; }
            public double Price { set; get; }
        }
}
