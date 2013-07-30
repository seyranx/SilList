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
            vo.ratingId = b524440fb1f542ce99295dfc8058b22e;
            vo.businessId = b524440fb1f542ce99295dfc8058b22e;

            var result = businessRatingsManager.insert(vo);
            var result2 = businessRatingsManager.get(result.businessRatingId);

            businessRatingsManager.delete(result.businessRatingId);

            var result3 = businessRatingsManager.get(result.businessRatingId);

            // NEEDS FIXING !!!

            if (result != null && result2 != null && result3 == null)//  && result2.businessRatingId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }


        public Guid? b524440fb1f542ce99295dfc8058b22e { get; set; }
    }
}
