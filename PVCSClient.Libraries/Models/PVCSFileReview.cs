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
        public PVCSFileReview(string input) : this()
        {
            throw new NotImplementedException();
        }
    }
}