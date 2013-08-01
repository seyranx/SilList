using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Models.ValueObjects;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Tests.Managers
{
    [TestClass]
    public class ServiceTypeManagerTest
    {
        private ServiceTypeManager serviceTypeManager = new ServiceTypeManager();


        [TestMethod]
        public void getAllTest()
        {

            var res = serviceTypeManager.getAll(null);

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
                var vo = new ServiceTypeVo();
                vo.name = i.ToString() + " Test Business Name ";
                vo.siteId = 1;
                var result = serviceTypeManager.insert(vo);
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
            var stmvo = new ServiceTypeVo();
            //stmvo.serviceTypeId = 123;
            stmvo.description  = "test description";

            var result = serviceTypeManager.insert(stmvo);
            var result2 = serviceTypeManager.get(result.serviceTypeId);

            serviceTypeManager.delete(result.serviceTypeId);

            var result3 = serviceTypeManager.get(result.serviceTypeId);

            if (result != null && result2 != null && result3 == null && result2.serviceTypeId  != 0)
            {
                Assert.IsTrue(true);
            }
            else
                Assert.IsTrue(false);
        }
    }
}
