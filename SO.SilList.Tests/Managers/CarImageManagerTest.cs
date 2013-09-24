using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class CarImagesManagerTest
    {
        private CarImagesManager carImagesManager = new CarImagesManager();

        [TestMethod]
        public void getAllTest()
        {
            var res = carImagesManager.getAll(null);

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
                var vo = new CarImagesVo();
               // vo.imageId = i;
                //vo.name = i.ToString() + " Test BusinessCategoryType Name ";
                var result = carImagesManager.insert(vo);
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
            var vo = new CarImagesVo();
            //vo.name = "test";
             vo.carImagesId = Guid.NewGuid();
             vo.createdBy = 123;

            var result = carImagesManager.insert(vo);
            var result2 = carImagesManager.get(result.carImagesId);

            carImagesManager.delete(result.carImagesId);

            var result3 = carImagesManager.get(result.carImagesId);

            if (result != null && result2 != null && result3 == null && result2.carImagesId != null)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void includesTest()
        {

            var result = carImagesManager.getFirst();

            //FK-s are disabled temporarily
            //var site = result.site;
            /*
                    if (result.site != null)
                    {
                        Assert.IsTrue(true);
                    }
                    else
                        Assert.IsTrue(false);
                    */

        }
    }
}
