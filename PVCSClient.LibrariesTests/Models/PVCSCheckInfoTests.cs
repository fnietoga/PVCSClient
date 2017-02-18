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
    public class PVCSCheckInfoTests
    {
        [TestMethod()]
        public void PVCSCheckInfo_Test1()
        {
            string input = "#Checked in : amdo_d31 20170125 Reingenieria CreditScoring (madefng02)";
            PVCSCheckInfo expected = new PVCSCheckInfo()
            {
                AuthorId = "amdo_d31",
                Date = new DateTime(2017, 1, 25),
                Description = "Reingenieria CreditScoring",
                UserName = "madefng02",
            };

            PVCSCheckInfo actual = new Libraries.PVCSCheckInfo(input, CheckDirection.In);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.AuthorId, actual.AuthorId);
            Assert.IsTrue(actual.Date.HasValue);
            Assert.AreEqual<DateTime>(expected.Date.Value, actual.Date.Value);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.UserName, actual.UserName);
        }

        [TestMethod()]
        public void PVCSCheckInfo_Test2()
        {
            string input = "#Checked Out: amdo_d31  de 25 2017 enero PCK_BTS_CREDITSCORING.sql  (VOS01812F01V00) Reingenieria CreditScoring (madefng02)";
            PVCSCheckInfo expected = new PVCSCheckInfo()
            {
                AuthorId = "amdo_d31",
                Date = new DateTime(2017, 1, 25),
                Project = "VOS01812F01V00",
                Description = "Reingenieria CreditScoring",
                UserName = "madefng02",
            };

            PVCSCheckInfo actual = new PVCSCheckInfo(input, CheckDirection.Out);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.AuthorId, actual.AuthorId);
            Assert.IsTrue(actual.Date.HasValue);
            Assert.AreEqual<DateTime>(expected.Date.Value, actual.Date.Value);
            Assert.AreEqual(expected.Project, actual.Project);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.UserName, actual.UserName);

        }
    }
}