using Microsoft.VisualStudio.TestTools.UnitTesting;
using PVCSClient.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using System.Text.RegularExpressions;

namespace PVCSClient.Libraries.Tests
{
    [TestClass()]
    public class PVCSManagerTests
    {

        [TestInitialize]
        public void Init()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        #region Singleton
        [TestMethod]
        public void PVCSManager_EmptyConstructor_Test()
        {

            PVCSManager manager = new PVCSManager();

            Assert.IsNotNull(manager.SessionId);
            Assert.IsTrue(manager.SessionId.Length >= 32);
            Assert.IsTrue(Regex.IsMatch(manager.SessionId, @"^[A-Z0-9]+$"));
        }

        [TestMethod]
        public void PVCSManager_InstanceInit_Test()
        {
            Assert.IsNull(PVCSManager._instance);

            var actual = PVCSManager.Instance;

            Assert.IsNotNull(actual);
            Assert.AreEqual<PVCSManager>(PVCSManager._instance, actual);

        }

        #endregion


        #region Properties

        [TestMethod]
        public void SessionIdTest()
        {
            string sessionId = Guid.NewGuid().ToString("N").ToUpper();
            PVCSManager target = new PVCSManager();

            target.SessionId = sessionId;

            Assert.IsNotNull(target.SessionId);
            Assert.AreEqual(sessionId, target.SessionId);
        }

        [TestMethod]
        public void HostOrIpTest()
        {
            PVCSManager target = new PVCSManager();

            string actual = target.HostOrIp;

            Assert.IsNotNull(actual);
            Assert.AreEqual("opetst71.ono.es", actual);
        }

        [TestMethod]
        public void PortTest()
        {
            PVCSManager target = new PVCSManager();

            int actual = target.Port;

            Assert.IsNotNull(actual);
            Assert.AreEqual(22, actual);
        }

        [TestMethod]
        public void UsernameTest()
        {
            PVCSManager target = new PVCSManager();

            string actual = target.Username;

            Assert.IsNotNull(actual);
            Assert.AreEqual("amdo_d31", actual);
        }

        [TestMethod]
        public void PasswordTest()
        {
            PVCSManager target = new PVCSManager();

            string actual = target.Password;

            Assert.IsNotNull(actual);
            Assert.AreEqual("usamd3841", actual);
        }

        [TestMethod]
        public void ConnectionInfoTest()
        {
            string host = "127.0.0.1"; int port = 22;
            string username = "user"; string password = "secret";

            PVCSManager.Instance.HostOrIp = host;
            PVCSManager.Instance.Port = port;
            PVCSManager.Instance.Username = username;
            PVCSManager.Instance.Password = password;

            Renci.SshNet.ConnectionInfo actual = PVCSManager.Instance.ConnectionInfo;

            Assert.IsNotNull(actual);
            Assert.AreEqual(host, actual.Host);
            Assert.AreEqual(port, actual.Port);
            Assert.AreEqual(username, actual.Username);
            Assert.IsNotNull(actual.AuthenticationMethods);
            Assert.IsTrue(actual.AuthenticationMethods.Count > 0);
            Assert.IsTrue(actual.AuthenticationMethods[0] is Renci.SshNet.PasswordAuthenticationMethod);
            Assert.AreEqual(username, ((Renci.SshNet.PasswordAuthenticationMethod)actual.AuthenticationMethods[0]).Username);
        }

        //TODO: Implement with connection FAKE
        [TestMethod]
        public void ConnectionTest()
        {
            using (PVCSManager target = new PVCSManager())
            {

                var actual = target.Connection;

                Assert.IsNotNull(actual);
                Assert.IsTrue(actual.IsConnected);
            }
        }
        #endregion


        #region Methods
        [TestMethod()]
        public void GetListadoTest()
        {
            string packagePath = "/CRM/BBDD/BTS/PROCEDURES";
            PVCSManager target = new PVCSManager();

            PVCSBasicFileInfoCollection actual = target.GetListado(packagePath);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            foreach (var current in actual)
                Assert.AreEqual(packagePath, current.Path);
            //TODO: Add more assertions

        }

        [TestMethod()]
        public void GetInfoTest()
        {
            PVCSManager target = new PVCSManager();

            string packageName = "";
            string packagePath = "/CRM/BBDD/BTS/PROCEDURES";
            PVCSFileInfo actual = target.GetInfo(packageName, packagePath);

            Assert.IsNotNull(actual);
            Assert.AreEqual(packageName, actual.Name);
            Assert.AreEqual(packagePath, actual.Path);
            Assert.IsNotNull(actual.Groups);
            Assert.IsNotNull(actual.Labels);
            Assert.IsNotNull(actual.Reviews);
            //TODO: Add more assertions
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckoutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckinTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UnlockTest()
        {
            Assert.Fail();
        }
        #endregion


    }
}