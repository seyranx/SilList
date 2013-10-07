using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class ModelTypeManagerTest
    {
        private ModelTypeManager modelTypeManager = new ModelTypeManager();

        [TestMethod]
        public void getAllTest()
        {
            var res = modelTypeManager.getAll(null);

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
                var vo = new ModelTypeVo();
                vo.name = "NewCar(" + i.ToString() + ")";
                //vo.name = i.ToString() + " Test BusinessCategoryType Name ";
                var result = modelTypeManager.insert(vo);
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
            var vo = new ModelTypeVo();
            vo.name = "2013XL";


            var result = modelTypeManager.insert(vo);
            var result2 = modelTypeManager.get(result.modelTypeId);

            modelTypeManager.delete(result.modelTypeId);

            var result3 = modelTypeManager.get(result.modelTypeId);

            if (result != null && result2 != null && result3 == null && result2.modelTypeId != 0
                )
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void includesTest()
        {

            var result = modelTypeManager.getFirst();

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
