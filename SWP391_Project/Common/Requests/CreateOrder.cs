using SWP391_Project.Domain.DiavanEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Requests
{
    public class CreateOrder
    {
        public int CustomerId {  get; set; }
        public int OrderID { get; set; }
        public string Code { get; set; }
        public DateTime Time { get; set; }
        public int? Quantity { get; set; }
        public string? Status { get; set; }
        public string ConsultingStaffName { get; set; }
        public List<OrderDetail> Details { get; set; }
    }
    public class OrderDetailCreate
    { 
        public double EstimateLength { get; set; }
        public int ServiceId {  get; set; }
    }
}