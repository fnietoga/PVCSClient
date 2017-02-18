using System;

namespace PVCSClient.Libraries
{

    public class PVCSFileReview
    {
        public string Version { get; set; }
        public PVCSCheckInfo CheckedIn { get; private set; }
        public PVCSCheckInfo CheckedOut { get; private set; }
        public DateTime? LastModified { get; private set; }
        public string AuthorId { get; private set; }

        public PVCSFileReview() { }

        /// <summary>
        /// 
        /// </summary>
        /// <example>Rev 1.8
        ///          Checked in:     19 Dec 2016 12:06:46
        ///          Last modified:  21 Nov 2016 14:43:20
        ///          Author id: platafor lines deleted/added/moved: 0/0/0
        ///          #Checked in : amdo_d32 20161130 Reingenieria CS (mademcs13)  #Checked Out: amdo_d31  de 25 2017 enero PCK_BTS_CREDITSCORING.sql  (VOS01812F01V00) Reingenieria CreditScoring (madefng02)
        /// </example>
        /// <param name="input"></param>
        public PVCSFileReview(string input) : this()
        {
            DateTime? checkinDate = null;

            //For each line
            foreach (string curLine in input.Split(new[] { '\r', '\n' }))
            {
                if (!string.IsNullOrWhiteSpace(curLine))
                {
                    //Version 
                    if (curLine.ExtractVersion() != null) this.Version = curLine.ExtractVersion();
                    if (curLine.StartsWith("Checked in", StringComparison.CurrentCultureIgnoreCase))
                        checkinDate = curLine.ExtractDateTime();
                    if (curLine.StartsWith("Last modified", StringComparison.CurrentCultureIgnoreCase))
                        this.LastModified = curLine.ExtractDateTime();
                    if (curLine.StartsWith("Author id", StringComparison.CurrentCultureIgnoreCase))
                        this.AuthorId = curLine.ExtractString(@"\b(?:[Aa]uthor id)\s*:?\s*(\w*)\b");

                    if (curLine.StartsWith("#"))
                    {
                        string[] parts = curLine.Split('#');
                        foreach (string curPart in parts)
                        {
                            if (curPart.Trim().StartsWith("Checked in", StringComparison.CurrentCultureIgnoreCase))
                                this.CheckedIn = new PVCSCheckInfo(curPart, CheckDirection.In);
                            if (curPart.Trim().StartsWith("Checked Out", StringComparison.CurrentCultureIgnoreCase))
                                this.CheckedOut = new PVCSCheckInfo(curPart, CheckDirection.Out);
                        } //foreach (string curPart 
                    } //if (curLine.StartsWith("#"))
                } //if (!string.IsNullOrWhiteSpace(curLine)
            } //foreach (string curLine

            if (checkinDate.HasValue)
            {
                if (CheckedIn == null) CheckedIn = new PVCSCheckInfo();
                CheckedIn.Date = checkinDate;
            }
        } 

    }
}