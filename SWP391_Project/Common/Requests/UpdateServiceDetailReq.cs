using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Requests
{
    public class UpdateServiceDetailReq
    {
        public double MinRange { get; set; }
        public double MaxRange { get; set; }
        public double Price { get; set; }
        public double ExtraPricePerMM { get; set; }
    }
}
