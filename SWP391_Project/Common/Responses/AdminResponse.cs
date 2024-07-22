using Data.DiavanModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class AdminResponse
    {
        public double Total {  get; set; }
        public double Trend { get; set; }
        public List<AdminData> AdminDatas { get; set; }
    }
}
