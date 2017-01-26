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
    public class PVCSFileLabelTests
    {
        [TestMethod()]
        public void PVCSFileLabel_Test1()
        {
            string str1 = "->Promocionado a SIT2: 05/11/2016 14:30:19.......... rev: 1.2";
            var target1 = new PVCSFileLabel(str1);
            Assert.AreEqual(str1, target1.Descripcion);
            Assert.AreEqual("SIT2", target1.Environment);
            Assert.AreEqual("1.2", target1.Version);
            Assert.IsTrue(target1.Date.HasValue);
            Assert.AreEqual<DateTime>(new DateTime(2016, 11, 5, 14, 30, 19), target1.Date.Value);
        }

        [TestMethod()]
        public void PVCSFileLabel_Test2()
        {
            string str = "->Promocionado a SIT2: 05/11/2016 14:30:19.......... rev: 1.2";
            var target = new PVCSFileLabel(str);
            Assert.AreEqual(str, target.Descripcion);
            Assert.AreEqual("SIT2", target.Environment);
            Assert.AreEqual("1.2", target.Version);
            Assert.IsTrue(target.Date.HasValue);
            Assert.AreEqual<DateTime>(new DateTime(2016, 11, 5, 14, 30, 19), target.Date.Value);
        }

        [TestMethod()]
        public void PVCSFileLabel_Test3()
        {
            string str = "->Promocionado a PROD 01/12/2016 a las 134922 en ver rev: 1.4";
            var target = new PVCSFileLabel(str);
            Assert.AreEqual(str, target.Descripcion);
            Assert.AreEqual("PROD", target.Environment);
            Assert.AreEqual("1.4", target.Version);
            Assert.IsTrue(target.Date.HasValue);
            Assert.AreEqual<DateTime>(new DateTime(2016, 12, 1,13,49,22), target.Date.Value);
        }

        [TestMethod()]
        public void PVCSFileLabel_Test4()
        {
            string str = "->Version PROD...................................... rev: 1.8";
            var target = new PVCSFileLabel(str);
            Assert.AreEqual(str, target.Descripcion);
            Assert.AreEqual("PROD", target.Environment);
            Assert.AreEqual("1.8", target.Version);
            Assert.IsFalse(target.Date.HasValue);
        }
    }
}