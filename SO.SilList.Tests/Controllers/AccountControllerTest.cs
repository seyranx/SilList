using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Web.Controllers;

namespace SO.SilList.Web.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        //Todo: not complete.
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            AccountController controller = new AccountController();

            // Act
            RegisterVm reg = new RegisterVm();
            ViewResult result = controller.Register(reg) as ViewResult;

            // Assert
            //Assert.AreEqual(, result.ViewBag.Message);
            Assert.IsTrue(true);

        }
    }
}
