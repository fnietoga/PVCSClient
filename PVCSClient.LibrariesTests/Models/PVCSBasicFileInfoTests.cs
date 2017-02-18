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
    public class PVCSBasicFileInfoTests
    {
        [TestMethod()]
        public void PVCSBasicFileInfo_Test1()
        {
            string input = "CRM/BBDD/BTS/FUNCIONES/GIOR_OBTENERSINTOMAS.sql";

            var actual = new PVCSBasicFileInfo(input);

            Assert.IsNotNull(actual);
            Assert.AreEqual("GIOR_OBTENERSINTOMAS.sql", actual.Name);
            Assert.AreEqual("CRM/BBDD/BTS/FUNCIONES", actual.Path);
            Assert.IsTrue (string.IsNullOrWhiteSpace(actual.LockedBy));
        }

        [TestMethod()]
        public void PVCSBasicFileInfo_Test2()
        {
            string input = "CRM/BBDD/BTS/FUNCIONES/SELECTUPDATEOLPOLLING_2.sql              Bloqueado por : amdo_d31";

            var actual = new PVCSBasicFileInfo(input);

            Assert.IsNotNull(actual);
            Assert.AreEqual("SELECTUPDATEOLPOLLING_2.sql", actual.Name);
            Assert.AreEqual("CRM/BBDD/BTS/FUNCIONES", actual.Path);
            Assert.AreEqual("amdo_d31",actual.LockedBy);
        }
    }
}