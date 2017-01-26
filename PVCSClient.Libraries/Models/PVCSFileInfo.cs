using System;

namespace PVCSClient.Libraries
{
    public class PVCSFileInfo : PVCSBasicFileInfo
    {
        PVCSFileLabel[] Labels { get; set; }

        PVCSFileGroup[] Groups { get; set; }

        PVCSFileReview[] Reviews { get; set; }

        public PVCSFileInfo() { }
        public PVCSFileInfo(string input) : this()
        {
            throw new NotImplementedException();
        }

    }
}