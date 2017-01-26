using System;

namespace PVCSClient.Libraries
{
    public class PVCSFileReview
    {
        string Version { get; set;}
        PVCSCheckInfo CheckedIn { get; set; }
        PVCSCheckInfo CheckedOut { get; set; }
        DateTime LastModified { get; set; }
        string AuthorId { get; set; }

        public PVCSFileReview() { }

        /// <summary>
        /// 
        /// </summary>
        /// <example>Rev 1.8
        ///          Checked in:     19 Dec 2016 12:06:46
        ///          Last modified:  21 Nov 2016 14:43:20
        ///          Author id: platafor lines deleted/added/moved: 0/0/0
        ///          #Checked in : amdo_d32 20161130 Reingenieria CS (mademcs13)  #Checked Out: amdo_d31  de 25 2017 enero PCK_BTS_CREDITSCORING.sql  (VOS01812F01V00) Reingenieria CreditScoring (madefng02)</example>
        /// <param name="input"></param>
        public PVCSFileReview(string input) : this()
        {
            throw new NotImplementedException();
        }
    }
}