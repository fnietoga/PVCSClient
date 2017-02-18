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
    public class PVCSFileGroupTests
    {
        [TestMethod()]
        public void PVCSFileGroup_Test1()
        {
            string str = "-> SIT1                 Rev : 1.9";
            var target = new PVCSFileGroup(str);
            Assert.AreEqual("SIT1", target.Environment);
            Assert.AreEqual("1.9", target.Version);
        }

        [TestMethod()]
        public void PVCSFileGroup_Test2()
        {
            string str = "-> IPVPN                Rev : 1.01";
            var target = new PVCSFileGroup(str);
            Assert.AreEqual("IPVPN", target.Environment);
            Assert.AreEqual("1.01", target.Version);
        }
    }
}