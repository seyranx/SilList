using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class CarBodyTypeManagerTest
    {
        private CarBodyTypeManager carBodyTypeManager = new CarBodyTypeManager();

        [TestMethod]
        public void getAllTest()
        {
            var res = carBodyTypeManager.getAll(null);

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
                var vo = new CarBodyTypeVo();
                vo.name = "SUV" + i.ToString();
                //vo.name = i.ToString() + " Test BusinessCategoryType Name ";
                var result = carBodyTypeManager.insert(vo);
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
            var vo = new CarBodyTypeVo();
            vo.name = "test";


            var result = carBodyTypeManager.insert(vo);
            var result2 = carBodyTypeManager.get(result.carBodyTypeId);

            carBodyTypeManager.delete(result.carBodyTypeId);

            var result3 = carBodyTypeManager.get(result.carBodyTypeId);

            if (result != null && result2 != null && result3 == null && result2.carBodyTypeId != 0)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void includesTest()
        {

            var result = carBodyTypeManager.getFirst();

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
