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
    public class BusinessServicesManagerTest
    {
        public BusinessServicesManager businessServicesManager = new BusinessServicesManager();

        [TestMethod]
        public void insertDeleteTest()
        {
            var bsvo = new BusinessServicesVo();
            bsvo.businessServiceId = Guid.NewGuid();
            //bsvo.businessId = Guid.NewGuid();

            var result = businessServicesManager.insert(bsvo);
            var result2 = businessServicesManager.get(result.businessServiceId);

            businessServicesManager.delete(result.businessServiceId);

            var result3 = businessServicesManager.get(result.businessServiceId);

            if (result != null && result2 != null && result3 == null && result2.businessServiceId != Guid.Empty)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}
