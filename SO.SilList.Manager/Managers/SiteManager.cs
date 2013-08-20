using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Managers
{
    public class SiteManager : ISiteManager
    {
        public SiteVo get(int siteId)
        {
            using (var db = new MainDb())
            {
                var result = db.sites
                            .FirstOrDefault(s => s.siteId == siteId);
                return result;
            }
        }

        public List<SiteVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.sites
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        /* this is useful but not working anyway
         *  db.DeleteObject(cr);
         *  db.SaveChanges(); 
         *  instead of
         *  db.car.DeleteOnCommit();
         *  db.SubmitChanges();
         *   http://stackoverflow.com/questions/4650684/deleteonsubmit-doesnt-exist
         *   
         *  Remove in Entity Framework 5 instead of DeleteOnSubmit()
         *  This works with my version of EF !!!
         *  http://stackoverflow.com/questions/17203869/entity-framework-beta-3-dtabase-first-does-not-give-deleteonsubmit
         * 
         */
        public bool delete(int siteId)
        {
           using(var db = new MainDb())
           {
        //TODO: Site deletion will be somewhat complicated if the site with given id references already by other tables  . ..
              //var res = db.sites
              //   .Where(e => e.siteId == siteId)
              //   .Delete();

              /////////////////////////////////////////////////////////
               var deleteSiteReferences_inCar =
                     from cr in db.car
                     where cr.siteId == siteId
                     select cr;
               foreach (var cr in deleteSiteReferences_inCar)
               {
                  db.car.Remove(cr);  // 2. Deleteobject(cr); // 1. DeleteOnSubmit(cr);
               }

              /////////////////////////////////////////////////////////
               var deleteSiteReferences_InMember =
                    from x in db.members
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSiteReferences_InMember)
               {
                  db.members.Remove(x);  // 2. Deleteobject(cr); // 1. DeleteOnSubmit(cr);
               }


               /////////////////////////////////////////////////////////
               var deleteSiteReferences_InBusinessCategoryType =
                    from x in db.members
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSiteReferences_InBusinessCategoryType)
               {
                  db.members.Remove(x);  // 2. Deleteobject(cr); // 1. DeleteOnSubmit(cr);
               }

               /////////////////////////////////////////////////////////
               var deleteSiteReferences_InBusiness  =
                    from x in db.businesses
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSiteReferences_InBusiness )
               {
                  db.businesses.Remove(x);  // 2. Deleteobject(cr); // 1. DeleteOnSubmit(cr);
               }

               /////////////////////////////////////////////////////////
               var deleteSiteReferences_InImage =
                    from x in db.images
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSiteReferences_InImage)
               {
                  db.images.Remove(x);  // 2. Deleteobject(cr); // 1. DeleteOnSubmit(cr);
               }

               /////////////////////////////////////////////////////////
               var deleteSiteReferences_InListing =
                    from x in db.listing
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSiteReferences_InListing)
               {
                  db.listing.Remove(x);  // 2. Deleteobject(cr); // 1. DeleteOnSubmit(cr);
               }

               /////////////////////////////////////////////////////////
               var deleteSiteReferences_InRental =
                    from x in db.rental
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSiteReferences_InRental)
               {
                  db.rental.Remove(x);  // 2. Deleteobject(cr); // 1. DeleteOnSubmit(cr);
               }

              // // // 
              
              try
               {
                  db.SaveChanges(); //  db.SubmitChanges();
               }
               catch (Exception e)
               {
                  Console.WriteLine(e);
                  // Provide for exceptions.
               }
              return true;
           }
        }

        public SiteVo update(SiteVo input, int? siteId = null)
        {
           using (var db = new MainDb())
           {
              if(siteId == null)
               siteId = input.siteId;

              var res  = db.sites.FirstOrDefault(e => e.siteId == siteId);

              if (res == null) return null;
              
              input.created = res.created;
              input.createdBy = res.createdBy;
              db.Entry(res).CurrentValues.SetValues(input);

              db.SaveChanges();
              return res;
           }
        }

        public SiteVo insert(SiteVo input)
        {
           using (var db = new MainDb())
           {
               db.sites.Add(input);
               db.SaveChanges();

               return input;
           }
        }
    }
}
