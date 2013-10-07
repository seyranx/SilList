using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
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
        public SiteVm search(SiteVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.sites

                            .OrderBy(b => b.name)
                            .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.name.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                             );
                input.paging.totalCount = query.Count();
                input.result = query
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount)

                             .ToList();

                return input;
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

          public bool delete(int siteId)
        {
           using(var db = new MainDb())
           {
              //
               var deleteSiteReferences_inCar =
                     from cr in db.car
                     where cr.siteId == siteId
                     select cr;
               foreach (var cr in deleteSiteReferences_inCar)
               {
                  db.car.Remove(cr);
               }

              //
               var deleteSiteReferences_InMember =
                    from x in db.members
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSiteReferences_InMember)
               {
                  db.members.Remove(x);
               }


               //
               var deleteSiteReferences_InBusinessCategoryType =
                    from x in db.members
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSiteReferences_InBusinessCategoryType)
               {
                  db.members.Remove(x);
               }

               //
               var deleteSiteReferences_InBusiness  =
                    from x in db.businesses
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSiteReferences_InBusiness )
               {
                  db.businesses.Remove(x);
               }

               //
               var deleteSiteReferences_InImage =
                    from x in db.images
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSiteReferences_InImage)
               {
                  db.images.Remove(x);
               }

               //
               var deleteSiteReferences_InListing =
                    from x in db.listing
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSiteReferences_InListing)
               {
                  db.listing.Remove(x);
               }

               //
               var deleteSiteReferences_InRental =
                    from x in db.rental
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSiteReferences_InRental)
               {
                  db.rental.Remove(x);
               }

               //
               var deleteSite =
                    from x in db.sites
                    where x.siteId == siteId
                    select x;
               foreach (var x in deleteSite)
               {
                  db.sites.Remove(x);
               }             
              try
               {
                  db.SaveChanges();
               }
               catch (Exception e)
               {
                  Console.WriteLine(e);
               }
              return true;
           }
        }

        //*
        // * this version works if Member, Listing, and BusinessCategoryType have no reference to the site being deleted (no data)
        // * or of we enable cascading properties for corresponding FK-s. Enabling Cascading properties causes circular dependencies in Database which 
        // * prevents Database project from updating tables in SqlSerer.
        // */
        //public bool delete_short_version(int siteId)
        //{
        //   using (var db = new MainDb())
        //   {
        //      var deleteSite =
        //           from x in db.sites
        //           where x.siteId == siteId
        //           select x;
        //      foreach (var x in deleteSite)
        //      {
        //         db.sites.Remove(x);
        //      }
        //      try
        //      {
        //         db.SaveChanges(); //  db.SubmitChanges();
        //      }
        //      catch (Exception e)
        //      {
        //         Console.WriteLine(e);
        //         // Provide for exceptions.
        //      }
        //      return true;
        //   }
        //}
        

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
