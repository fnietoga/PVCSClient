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

        /// <summary>
        /// 
        /// </summary>
        /// <example>->Promocionado a SIT2: 05/11/2016 14:30:19.......... rev: 1.2</example>
        /// <example>->Promocionado a TST1 05/01/2017 a las 125032 en 232 rev: 1.7</example>
        /// <example>19 Dec 2016 12:06:46</example>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DateTime? ExtractDateTime(this String input)
        {
            DateTime dateValue;

            string[] sDateTimePatterns = {
              @"\b(\d{1,2})[\/\- ]?(\d{1,2})[\/\- ]?(\d{2,4})\s*(?:a las)?\s*(\d{1,2})[: ]?(\d{1,2})[: ]?(\d{1,2})\b",
              @"\b(\d{1,2}\s*[a-zA-Z]*\s*\d{2,4}\s*\d{1,2}[: ]\s*\d{1,2}[: ]\d{1,2})\b",
              @"\b(\d{4})(\d{2})(\d{2})\b",
              @"\b(\d{2})\s*(\d{4})\s*(\w*)\b" };

            foreach (string currPattern in sDateTimePatterns)
            {
                if (Regex.IsMatch(input, currPattern, RegexOptions.IgnoreCase))
                {
                    Match match = Regex.Match(input, currPattern, RegexOptions.IgnoreCase);
                    string[] formats = new string[] {
                        "dd/MM/yyyy HH:mm:ss",
                        "dd/MM/yyyy HHmmss",
                        "dd MM yyyy HH:mm:ss",
                        "dd MM yyyy HH mm ss",
                        "dd MMM yyyy HH:mm:ss",
                        "yyyyMMdd",
                        "dd yyyy MMMM" };

                    //Try to convert to DateTime
                    if (DateTime.TryParseExact(
                         match.Value.Replace("a las ", ""),
                         formats,
                         CultureInfo.InvariantCulture,
                         DateTimeStyles.None,
                         out dateValue)
                    || DateTime.TryParseExact(
                         match.Value.Replace("a las ", ""),
                         formats,
                         CultureInfo.CurrentCulture,
                         DateTimeStyles.None,
                         out dateValue))

                        return dateValue;
                }
            }
            return null;
        }


        /// <summary>
        /// Extract the version information from a string
        /// </summary>
        /// <param name="input"></param>
        /// <example>Rev 1.8</example>
        /// <example>-> SIT1                 Rev : 1.9</example>
        /// <example>->Version PROD...................................... rev: 1.8</example>
        /// <returns></returns>
        public static string ExtractVersion(this String input)
        {
            return input.ExtractString(@"\b(?:rev|Rev)\s*:?\s*(\d+.\d+)\b");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="regexPattern"></param>
        /// <returns></returns>
        public static string ExtractString(this String input, string regexPattern)
        {
            return ExtractString(input, regexPattern, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="regexPattern"></param>
        /// <param name="groupIndex"></param>
        /// <returns></returns>
        public static string ExtractString(this String input, string regexPattern, int groupIndex)
        {
            if (Regex.IsMatch(input, regexPattern, RegexOptions.IgnoreCase))
            {
                return Regex.Match(input, regexPattern, RegexOptions.IgnoreCase).Groups[groupIndex].Value;
            }
            return null;
        } 

    }
}
