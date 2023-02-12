using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class BaseFilterExtensions
    {
        public static string ToFilterQuery(this string text) => string.IsNullOrEmpty(text) ? text : $"%{text.TrimStart().TrimEnd().ToUpper(new System.Globalization.CultureInfo("tr-TR"))}%";

        public static string ToFilterText(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            if (text.Contains('i') || text.Contains('ı') || text.Contains('İ') || text.Contains("I"))
            {
                return $"{text.TrimStart().TrimEnd().ToUpper(new System.Globalization.CultureInfo("tr-TR"))}";
            }
            return text;
        }
    }
}
