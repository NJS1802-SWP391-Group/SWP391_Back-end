using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Requests
{
    public class UpdateOrderConsult
    {
        public int OrderID { get; set; }
        public string Time { get; set; }
        public int ConsultingStaffId  { get; set; }
        public List<OrderDetailCreate> DetailValuations { get; set; }
    }
    public class OrderDetailCreate
    { 
        public int ServiceId {  get; set; }
        public double EstimateLength { get; set; }
    }
}