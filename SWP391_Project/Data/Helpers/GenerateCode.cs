using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Helpers
{
    public static class GenerateCode
    {
        public static string OrderCode()
        {
            Random random = new Random();
            int randomPart = random.Next(100000, 999999);
            return $"{randomPart}";
        }

        public static string OrderDetailCode(int id)
        {
            Random random = new Random();
            int randomPart = random.Next(100, 999);
            var result = id.ToString("D3");
            return $"OD{result}{randomPart}";
        }
    }
}
