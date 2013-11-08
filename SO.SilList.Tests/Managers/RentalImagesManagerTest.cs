using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class RentalImagesManagerTest
    {

        private RentalImagesManager rentalImagesManager = new RentalImagesManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = rentalImagesManager.getAll(null);

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
                var vo = new PropertyImageVo();
                vo.createdBy = i;
                vo.propertyImageId = Guid.NewGuid();
                var result = rentalImagesManager.insert(vo);
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
            var vo = new PropertyImageVo();
            vo.propertyImageId = Guid.NewGuid();
            vo.createdBy = 123;

            var result = rentalImagesManager.insert(vo);
            var result2 = rentalImagesManager.get(result.propertyImageId);

            rentalImagesManager.delete(result.propertyImageId);

            var result3 = rentalImagesManager.get(result.propertyImageId);

            if (result != null && result2 != null && result3 == null && result2.propertyImageId != Guid.Empty)
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
