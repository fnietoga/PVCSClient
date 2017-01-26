using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PVCSClient.Libraries
{
    public static class StringExtensions
    {

        public static DateTime? ExtractDateTime(this String input)
        {
            DateTime dateValue;
            string sDateTimePattern = @"\b(\d{1,2})[/-](\d{1,2})[/-](\d{2,4})\s*(?:a las)?\s*(\d{1,2}):?(\d{1,2}):?(\d{1,2})\b";
            //.*? = Cualquier texto, [a las|\s?] = texto específico o espacio opcional
            Match match = Regex.Match(input, sDateTimePattern, RegexOptions.IgnoreCase);
            if (match.Success
                && match.Groups.Count >= 6
                && DateTime.TryParse(String.Format("{0}/{1}/{2} {3}:{4}:{5}", match.Groups[1], match.Groups[2], match.Groups[3], match.Groups[4], match.Groups[5], match.Groups[6]),
                    out dateValue))
            {
                return dateValue;
            }

            return null;
        }

        public static string ExtractString(this String input, string regexPattern)
        {
            if (Regex.IsMatch(input, regexPattern, RegexOptions.IgnoreCase))
            {
                return Regex.Match(input, regexPattern, RegexOptions.IgnoreCase).Groups[1].Value;
            }
            return null;
        }
    }
}
