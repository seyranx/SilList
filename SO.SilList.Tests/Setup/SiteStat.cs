using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Tests.Setup
{
    [TestClass]
    public class SiteStatTest
    {
        [TestMethod]
        public void SetupDB()
        {

            using (var db = new MainDb())
            {

                // get a valid site id
                var site = db.sites.FirstOrDefault();
                Assert.IsTrue(null != site);
                
                // add some visits
                var visit = new VisitVo();
                visit.siteId = site.siteId;
                visit.ipAddress = "192.168.1.1";
                visit.referrerUrl = "silist.com";
                visit.visitTime = new DateTime(2013, 8, 25, 12, 23, 56);
                visit.browser = "IE 8";
                visit.controller = "Home";
                visit.action = "Index";

                try
                {
                    db.visits.Add(visit);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }                
            }
        }
    }
}
