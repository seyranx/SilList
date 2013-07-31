using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class RatingManagerTest
    {
        private RatingManager ratingManager = new RatingManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = ratingManager.getAll(null);

            if (res != null)
            {
                Assert.IsTrue(true);
            }
            else Assert.IsTrue(false);
        }


        [TestMethod]
        public void insertDeleteTest()
        {
            var vo = new RatingVo();
            vo.rating = 4;
            vo.review = "good job";

            var result = ratingManager.insert(vo);
            var result2 = ratingManager.get(result.ratingId);

            ratingManager.delete(result.ratingId);

            var result3 = ratingManager.get(result.ratingId);

            if (result != null && result2 != null && result3 == null && result2.ratingId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}
