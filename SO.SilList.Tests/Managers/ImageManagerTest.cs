using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class ImageManagerTest
    {
        private ImageManager imageManager = new ImageManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = imageManager.getAll(null);

            Assert.IsTrue(true);
        }

    }
}
