using System;

namespace PVCSClient.Libraries
{
    public class PVCSFileGroup
    {
        string Environment { get; set; }

        string Version { get; set; }

        public PVCSFileGroup() { }
        public PVCSFileGroup(string input) : this() {
            throw new NotImplementedException();
        }
    }
}