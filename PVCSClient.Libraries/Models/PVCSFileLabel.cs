using System;

namespace PVCSClient.Libraries
{
    public class PVCSFileLabel
    {
        string Descripcion { get; set; }
        DateTime? Date { get; set; }
        string version { get; set; }

        public PVCSFileLabel() { }
        public PVCSFileLabel(string input) : this()
        {
            throw new NotImplementedException();
        }

    }
}