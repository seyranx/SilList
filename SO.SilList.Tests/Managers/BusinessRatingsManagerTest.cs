using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class BusinessRatingsManagerTest
    {
        private BusinessRatingsManager businessRatingsManager = new BusinessRatingsManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = businessRatingsManager.getAll(null);

            if (res != null)
            {
                Assert.IsTrue(true);
            }
            else Assert.IsTrue(false);
        }

        [TestMethod]
        public void insertDeleteTest()
        {
            var vo = new BusinessRatingsVo();
            vo.createdBy = 3;
            vo.modifiedBy = 4;
            // uncomenting next 2 lines leads to violation of FOREIGN KEY CONSTRAINTS
            //vo.ratingId = new Guid();
            //vo.businessId = new Guid();

            var result = businessRatingsManager.insert(vo);
            var result2 = businessRatingsManager.get(result.businessRatingId);

            businessRatingsManager.delete(result.businessRatingId);

            var result3 = businessRatingsManager.get(result.businessRatingId);

            if (result != null && result2 != null && result3 == null && result2.businessRatingId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }

    }
}
