using System;
using System.Text.RegularExpressions;

namespace PVCSClient.Libraries
{
    public enum CheckDirection
    {
        In,
        Out
    }

    public class PVCSCheckInfo
    {
        public DateTime? Date { get; internal set; }
        public string AuthorId { get; internal set; }
        public string Project { get; internal set; }
        public string Description { get; internal set; }
        public string UserName { get; internal set; }

        public PVCSCheckInfo() { }
        /// <summary>
        /// 
        /// </summary>
        /// <example>#Checked in : amdo_d31 20170125 Reingenieria CreditScoring (madefng02)</example>
        /// <example>#Checked Out: amdo_d31  de 25 2017 enero PCK_BTS_CREDITSCORING.sql  (VOS01812F01V00) Reingenieria CreditScoring (madefng02)</example>
        /// <param name="input"></param>
        public PVCSCheckInfo(string input, CheckDirection direction) : this()
        {
            string pattern = string.Empty;
            switch (direction)
            {
                case CheckDirection.Out:
                    pattern = @"\b(?:[Cc]hecked [Oo]ut)\s*:?\s*(\w*)\s*([^(]*)\s*\(([^)]*)\)\s*(.*)\(([^)]*)\)";
                    break;
                default:
                    pattern = @"\b(?:[Cc]hecked in)\s*:?\s*(\w*)\s*(\w*)\s*([^(]*)\s*\(([^)]*)\)";
                    break;
            }

            if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
            {
                var match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
                this.AuthorId = match.Groups[1].Value.Trim();
                this.Date = match.Groups[2].Value.ExtractDateTime();
                if (direction == CheckDirection.Out) this.Project = match.Groups[3].Value.Trim();
                this.Description = match.Groups[match.Groups.Count - 2].Value.Trim();
                this.UserName = match.Groups[match.Groups.Count - 1].Value.Trim();
            }
        }
    }
}