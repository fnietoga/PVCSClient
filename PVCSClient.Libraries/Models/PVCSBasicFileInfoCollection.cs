using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCSClient.Libraries
{
    public class PVCSBasicFileInfoCollection : Collection<PVCSBasicFileInfo>
    {
        public PVCSBasicFileInfoCollection() : base() { }
        public PVCSBasicFileInfoCollection(IEnumerable<string> lines) : this()
        {
            foreach (string curLine in lines)
                if (!string.IsNullOrWhiteSpace(curLine))
                    this.Add(new Libraries.PVCSBasicFileInfo(curLine));
        }
        public PVCSBasicFileInfoCollection(string input) : this(input.Split(new[] { '\r', '\n' })) { }

    }
}
