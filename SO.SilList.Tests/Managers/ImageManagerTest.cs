using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

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

            if (res != null)
            {
                Assert.IsTrue(true);
            }
            else Assert.IsTrue(false);
        }


        [TestMethod]
        public void insertRecordsTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                var vo = new ImageVo();
                vo.name = "Test Business Name " + i.ToString();
                //vo.siteId = 1;
                vo.url = "http://xxxx.yyyy.com";
                var result = imageManager.insert(vo);
                if (result == null)
                {
                    Assert.IsTrue(false);
                    break;
                }
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void insertDeleteTest()
        {
            var vo = new ImageVo();
            vo.name = "testName";
            vo.url = "http address 1";

            var result = imageManager.insert(vo);
            var result2 = imageManager.get(result.imageId);

            imageManager.delete(result.imageId);

            var result3 = imageManager.get(result.imageId);

            if (result != null && result2 != null && result3 == null && result2.imageId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}
