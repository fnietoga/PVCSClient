using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCSClient.Libraries
{
    public class PVCSFileLabelCollection : Collection<PVCSFileLabel>
    {
        public PVCSFileLabelCollection() : base() { }
        public PVCSFileLabelCollection(IEnumerable<string> lines) : this()
        {
            foreach (string curLine in lines)
                if (!string.IsNullOrWhiteSpace(curLine))
                    this.Add(new Libraries.PVCSFileLabel(curLine));
        }
        public PVCSFileLabelCollection(string input) : this(input.Split(new[] { '\r', '\n' })) { }

    }
}
