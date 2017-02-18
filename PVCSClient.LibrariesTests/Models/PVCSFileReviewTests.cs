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
    public class PVCSFileReviewTests
    {
        [TestMethod()]
        public void PVCSFileReview_Test()
        {
            string input = @"Rev 1.8" + System.Environment.NewLine + 
            "Checked in:     30 Nov 2016 12:06:46" + System.Environment.NewLine +
            "Last modified:  21 Nov 2016 14:43:20" + System.Environment.NewLine +
            "Author id: platafor lines deleted/added/moved: 0/0/0" + System.Environment.NewLine +
            "#Checked in : amdo_d32 20161130 Reingenieria CS (mademcs13)  #Checked Out: amdo_d31  de 25 2017 enero PCK_BTS_CREDITSCORING.sql  (VOS01812F01V00) Reingenieria CreditScoring (madefng02)";

            var actual = new PVCSFileReview(input);

            Assert.IsNotNull(actual);
            Assert.AreEqual("1.8", actual.Version);
            Assert.IsTrue(actual.LastModified.HasValue);
            Assert.AreEqual(new DateTime(2016, 11, 21, 14, 43, 20), actual.LastModified.Value);
            Assert.AreEqual("platafor", actual.AuthorId);
            Assert.IsNotNull(actual.CheckedIn);
            Assert.IsTrue(actual.CheckedIn.Date.HasValue);
            Assert.AreEqual(new DateTime(2016,11,30,12,6,46), actual.CheckedIn.Date);
            Assert.AreEqual("amdo_d32", actual.CheckedIn.AuthorId );
            Assert.AreEqual("Reingenieria CS", actual.CheckedIn.Description);
            Assert.AreEqual("mademcs13", actual.CheckedIn.UserName);
            Assert.IsNotNull(actual.CheckedOut);
            Assert.IsTrue(actual.CheckedOut.Date.HasValue);
            Assert.AreEqual(new DateTime(2017, 01, 25), actual.CheckedOut.Date);
            Assert.AreEqual("VOS01812F01V00", actual.CheckedOut.Project);
            Assert.AreEqual("Reingenieria CreditScoring", actual.CheckedOut.Description);
            Assert.AreEqual("madefng02", actual.CheckedOut.UserName);
        } 
       
    }
}