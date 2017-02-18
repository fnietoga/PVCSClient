using Microsoft.VisualStudio.TestTools.UnitTesting;
using PVCSClient.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCSClient.Libraries.Tests
{
    [TestClass()]
    public class PVCSFileInfoTests
    {
        [TestMethod()]
        public void PVCSFileInfoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExtractReviewsText_Test()
        {
            string input = "";
            string expected = "";

            PVCSFileInfo target = new PVCSFileInfo();

            string actual = target.ExtractReviewsText(input);

            Assert.IsNull(actual);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExtractGroupsText_Test()
        {
            string input = "";
            string expected = "";

            PVCSFileInfo target = new PVCSFileInfo();

            string actual = target.ExtractGroupsText(input);

            Assert.IsNull(actual);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExtractLabelsText_Test()
        {
            string input = "";
            string expected = "";

            PVCSFileInfo target = new PVCSFileInfo();

            string actual = target.ExtractLabelsText(input);

            Assert.IsNull(actual);
            Assert.IsFalse(string.IsNullOrWhiteSpace(actual));
            Assert.AreEqual(expected, actual);
        }
    }
}