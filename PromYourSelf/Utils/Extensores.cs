using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

		public static string GetDescription<T>(this T e) where T : IConvertible
		{
			if (e is Enum)
			{
				Type type = e.GetType();
				Array values = System.Enum.GetValues(type);

				foreach (int val in values)
				{
					if (val == e.ToInt32(CultureInfo.InvariantCulture))
					{
						var memInfo = type.GetMember(type.GetEnumName(val));

						if (memInfo[0]
							.GetCustomAttributes(typeof(DescriptionAttribute), false)
							.FirstOrDefault() is DescriptionAttribute descriptionAttribute)
						{
							return descriptionAttribute.Description;
						}
					}
				}
			}
			return null;
		}

	}
}
