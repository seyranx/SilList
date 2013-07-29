using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class PropertyTypeManagerTest
    {
        private PropertyTypeManager propertyTypeManager = new PropertyTypeManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = propertyTypeManager .getAll(null);

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
                var vo = new PropertyTypeVo();
                vo.name = i.ToString() + " Test PropertyType Name ";
                vo.propertyTypeId = 1;
                var result = propertyTypeManager.insert(vo);
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
            var vo = new PropertyTypeVo();
            vo.name = "testName";
            vo.description = "testDescription";
            // do we need other columns?
            var result = propertyTypeManager.insert(vo);
            var result2 = propertyTypeManager.get(result.propertyTypeId);

            propertyTypeManager.delete(result.propertyTypeId);

            var result3 = propertyTypeManager.get(result.propertyTypeId);

            if (result != null && result2 != null && result3 == null && result2.propertyTypeId != null)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

        // FK-s are disabled temporarily
        //[TestMethod]
        //public void includesTest()
        //{

        //    var result = businessManager.getFirst();

        //    //FK-s are disabled temporarily
        //    //var site = result.site;

        //    if (result.site != null)
        //    {
        //        Assert.IsTrue(true);
        //    }
        //    else
        //        Assert.IsTrue(false);


        //}


    }
}
