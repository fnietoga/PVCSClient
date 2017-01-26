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
        public PVCSCheckInfo(string input):this() {
            throw new NotImplementedException();
        }
    }
}