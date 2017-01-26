using System;

namespace PVCSClient.Libraries
{
    public class PVCSBasicFileInfo
    {
        string Path { get; set; }
        string Name { get; set; }
        string LockedBy { get; set; }

        public PVCSBasicFileInfo() { }
        public PVCSBasicFileInfo(string input) : this() {
            throw new NotImplementedException();
        }
    }
}