using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Managers;


namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class CarManagerTest
    {
        private CarManager carManager = new CarManager();
        [TestMethod]
        public void searchTest()
        {

        }

        [TestMethod]
        public void getAllTest()
        {
            var res = carManager.getAll(null);

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
                var vo = new CarVo();
                vo.millage = i * 1234;
                //vo.name = i.ToString() + " Test BusinessCategoryType Name ";
                var result = carManager.insert(vo);
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
            var vo = new CarVo();
            vo.millage = 32500;


            var result = carManager.insert(vo);
            var result2 = carManager.get(result.carId);

            carManager.delete(result.carId);

            var result3 = carManager.get(result.carId);

            if (result != null && result2 != null && result3 == null && result2.carId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void includesTest()
        {

            var result = carManager.getFirst();

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
