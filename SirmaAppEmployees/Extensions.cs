using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaAppEmployees
{
    internal static class Extensions
    {
        public static bool EqualsIgnoreCase(this string a, string b)
        {
            return a.ToLowerInvariant().Equals(b.ToLowerInvariant());
        }

        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return true;
            }
            return false;
        }

        public static DateTime ParseDate(this string dateString)
        {
            DateTime date;
            if (string.IsNullOrEmpty(dateString) || dateString.EqualsIgnoreCase(Constants.NullValue))
            {
                return DateTime.Today;
            }

            //different formats
            //try untill 1st success found
            foreach (string format in Constants.DateFormatsToTry)
            {
                if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }
            }

            throw new Exception($"Cannot parse date '{dateString}'");
        }
    }
}
