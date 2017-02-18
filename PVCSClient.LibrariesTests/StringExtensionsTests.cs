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
    public class StringExtensionsTests
    {
        [TestMethod()]
        public void ExtractDateTime_Test1()
        {
            string input = "->Promocionado a SIT2: 05/11/2016 14:30:19.......... rev: 1.2";
            DateTime expected = new DateTime(2016, 11, 5, 14, 30, 19);

            DateTime? actual = input.ExtractDateTime();

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.HasValue);
            Assert.AreEqual<DateTime>(expected, actual.Value);
        }


        [TestMethod()]
        public void ExtractDateTime_Test2()
        {
            string input = "->Promocionado a TST1 05/01/2017 a las 125032 en 232 rev: 1.7";
            DateTime expected = new DateTime(2017, 01, 05, 12, 50, 32);

            DateTime? actual = input.ExtractDateTime();

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.HasValue);
            Assert.AreEqual<DateTime>(expected, actual.Value);
        }

        [TestMethod()]
        public void ExtractDateTime_Test3()
        {
            string input = "Checked in:     19 Dec 2016 12:06:46";
            DateTime expected = new DateTime(2016, 12, 19, 12, 06, 46);

            DateTime? actual = input.ExtractDateTime();

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.HasValue);
            Assert.AreEqual<DateTime>(expected, actual.Value);
        }

        [TestMethod()]
        public void ExtractVersion_Test1()
        {
            string input = "Rev 1.8";
            string expected = "1.8";

            string actual = input.ExtractVersion();

            Assert.IsNotNull(actual);            
            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod()]
        public void ExtractVersion_Test2()
        {
            string input = "-> SIT1                 Rev : 1.9";
            string expected = "1.9";

            string actual = input.ExtractVersion();

            Assert.IsNotNull(actual);
            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod()]
        public void ExtractVersion_Test3()
        {
            string input = "->Version PROD...................................... rev: 1.08";
            string expected = "1.08";

            string actual = input.ExtractVersion();

            Assert.IsNotNull(actual);
            Assert.AreEqual<string>(expected, actual);
        }
    }
}