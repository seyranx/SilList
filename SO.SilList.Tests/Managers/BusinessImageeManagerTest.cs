using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class BusinessImageeManagerTest
    {
        public BusinessImageManager businessImageManager = new BusinessImageManager();

        [TestMethod]
        public void insertDeleteTest()
        {
            var bivo = new BusinessImagesVo();
            bivo.businessImageId = Guid.NewGuid();
            //bivo.businessId = new Guid();

            var result = businessImageManager.insert(bivo);
            var result2 = businessImageManager.get(result.businessImageId);

            businessImageManager.delete(result.businessImageId);

            var result3 = businessImageManager.get(result.businessImageId);

            if (result != null && result2 != null && result3 == null && result2.businessImageId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}
