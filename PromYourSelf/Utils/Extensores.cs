using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromYourSelf.Utils
{
    public static class Extensores
    {
        public static bool EsNulo(this object obj)
        {
            return obj == null;
        }
        public static int ToInt(this object obj)
        {
            if (obj.EsNulo())
                return 0;
            int.TryParse(obj.ToString(), out int value);
            return value;
        }
        public static decimal ToDecimal(this object obj)
        {
            if (obj.EsNulo())
                return 0;
            decimal.TryParse(obj.ToString(), out decimal value);
            return value;
        }
        public static DateTime ToDatetime(this object obj)
        {
            DateTime.TryParse(obj.ToString(), out DateTime value);
            return value;
        }
    }
}
