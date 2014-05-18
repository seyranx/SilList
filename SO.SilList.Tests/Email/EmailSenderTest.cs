using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.Utility.Classes.Email;

namespace SO.SilList.Web.Tests.Email
{
    [TestClass]
    public class EmailSenderTest
    {
        [TestMethod]
        public void TestMethod1()
        {

            var sender = new EmailSender();

           // sender.setCredentials("rndm2014@outlook.com", "office5757", "smtp.live.com");

            sender.send("Me", "nameinfo@gmail.com", "test one2", "test two2");


            Assert.IsTrue(true);



        }
    }
}
