using System;

namespace PVCSClient.Libraries
{
    public class PVCSCheckInfo
    {
        DateTime Date { get; set; }
        string AuthorId { get; set; }
        string Project { get; set; }
        string Description { get; set; }
        string UserName { get; set; }

        public PVCSCheckInfo() { }
        /// <summary>
        /// 
        /// </summary>
        /// <example>#Checked in : amdo_d31 20170125 Reingenieria CreditScoring (madefng02)</example>
        /// <example>#Checked Out: amdo_d31  de 25 2017 enero PCK_BTS_CREDITSCORING.sql  (VOS01812F01V00) Reingenieria CreditScoring (madefng02)</example>
        /// <param name="input"></param>
        public PVCSCheckInfo(string input):this() {
            throw new NotImplementedException();
        }
    }
}