using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCSClient.Libraries
{
    public class PVCSFileReviewCollection : Collection<PVCSFileReview>
    {
        public PVCSFileReviewCollection() : base() { }
        public PVCSFileReviewCollection(IEnumerable<string> lines) : this()
        {
            foreach (string curLine in lines)
                if (!string.IsNullOrWhiteSpace(curLine))
                    this.Add(new Libraries.PVCSFileReview(curLine));
        }
        public PVCSFileReviewCollection(string input) : this(input.Split(new[] { '\r', '\n' })) { }

    }
}
