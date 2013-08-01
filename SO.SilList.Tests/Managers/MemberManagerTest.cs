using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Managers
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MemberManagerTest
    {
        private MemberManager memberManager = new MemberManager();

        [TestMethod]
        public void getAllTest()
        {

            var res = memberManager.getAll(null);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void insertRecordsTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                var vo = new MemberVo();
                vo.firstName = "Test First Name Name " + i.ToString();
                vo.lastName = "Test Last Name Name " + i.ToString();
                vo.siteId = 1;

                var TimeNow = DateTime.Now;
                vo.created = TimeNow;
                vo.modified = TimeNow;
                vo.lastLogin = TimeNow;

                var result = memberManager.insert(vo);
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
            var vo = new MemberVo();
            vo.firstName = "testFirstName";
            vo.address = "1245 address";
            vo.memberId = 55;
            // just in case
            vo.lastLogin = DateTime.Now;
            vo.created = DateTime.Now;
            vo.modified = DateTime.Now;


            var result = memberManager.insert(vo);
            var result2 = memberManager.get(result.memberId);

            memberManager.delete(result.memberId);

            var result3 = memberManager.get(result.memberId);

            if (result != null && result2 != null && result3 == null && result2.memberId != 0)
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
        //    var result = memberManager.getFirst();

        //    var site = result.site;

        //    if (result.site != null)
        //    {
        //        Assert.IsTrue(true);
        //    }
        //    else
        //        Assert.IsTrue(false);
        //}

    }
}
