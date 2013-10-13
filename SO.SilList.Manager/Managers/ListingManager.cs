﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Managers
{
    public class ListingManager : IListingManager
    {

        public ListingManager()
        {

        }

        public ListingVm search(ListingVm input)
        {
            using (var db = new MainDb())
            {
                var query = db.listing
                             .Include(s => s.site)
                             .Include(t => t.listingType)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.title.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                    );
                input.paging.totalCount = query.Count();
                input.result = query
                             .OrderBy(b => b.title)
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount)
                             .ToList();
                return input;
            }
        }

        public ListingVm websearch(ListingVm input)
        {
            using (var db = new MainDb())
            {
                var query = db.listing
                             .Include(s => s.site)
                             .Include(t => t.listingType)
                           .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.title.Contains(input.keyword) || e.description.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                    );
                input.paging.totalCount = query.Count();
                input.result = query
                             .OrderBy(b => b.title)
                             .Skip(input.paging.skip)
                             .Take(input.paging.rowCount)
                             .ToList();
                return input;
            }
        }

/*
        public int count(ListingVm input)
        {   
            using (var db = new MainDb())
            {

                var totcount = db.listing
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.title.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                    )
                             .Count();
                return totcount;


                input.paging.totalCount = query.Count();
            }          
        }

        public List<ListingVo> search(ListingVm input)
        {
            using (var db = new MainDb())
            {
                var list = db.listing
                             .Include(s => s.site)
                             .Include(t => t.listingType)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.title.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                    )
                             .OrderBy(b => b.title)
                             .Skip(input.skip)
                             .Take(input.rowCount)
                             .ToList();

                return list;
            }
        }

        public int webcount(ListingVm input)
        {
            using (var db = new MainDb())
            {

                var totcount = db.listing
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.title.Contains(input.keyword) || e.description.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                    )
                             .Count();
                return totcount;
            }
        }
        
        public List<ListingVo> websearch(ListingVm input)
        {
            using (var db = new MainDb())
            {
                var list = db.listing
                             .Include(s => s.site)
                             .Include(t => t.listingType)
                             .Where(e => (input.isActive == null || e.isActive == input.isActive)
                                      && (e.title.Contains(input.keyword) || e.description.Contains(input.keyword) || string.IsNullOrEmpty(input.keyword))
                                    )
                             .OrderBy(b => b.title)
                             .Skip(input.skip)
                             .Take(input.resultPerPage)
                             .ToList();

                return list;
            }
        }
*/
        /// Find Listing matching the listingId
        public ListingVo get(Guid listingId)
        {
            using (var db = new MainDb())
            {
                var res = db.listing
                            .Include(s => s.site)
                            .Include(t => t.listingType)
                              .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

                            .FirstOrDefault(p => p.listingId == listingId);
                 
                return res;
            }
        }

        /// Get First Item
        public ListingVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.listing
                            //.Include(s=>s.site)
                            .FirstOrDefault();
               
                return res;
            }
        }

        // Get All Items
        public List<ListingVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.listing
                             .Include(s => s.site)
                             .Include(t => t.listingType)
                            .Include(i => i.cityType)
                            .Include(o => o.countryType)
                            .Include(u => u.stateType) 

                             .Where(e => isActive==null || e.isActive == isActive )
                             .ToList();

                return list;
            }
        }

        // Delete single Item matching listingId
        public bool delete(Guid listingId)
        {
            using (var db = new MainDb())
            {
                var res = db.listing
                     .Where(e => e.listingId == listingId)
                     .Delete();
                return true;
            }
        }

        // Update single Item matching listingId
        public ListingVo update(ListingVo input, Guid? listingId = null)
        {
        
            using (var db = new MainDb())
            {

                if (listingId == null)
                    listingId = input.listingId;

                var res = db.listing.FirstOrDefault(e => e.listingId == listingId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);

                 
                db.SaveChanges();
                return res;

            }
        }

        // Insert Listing
        public ListingVo insert(ListingVo input) // maybe "Models.ValueObjects.ListingVo" ?
        {
            using (var db = new MainDb())
            {

                db.listing.Add(input);
                db.SaveChanges();

                return input;
            }

        }

        // Count number of Listings
        public int count()
        {
            using (var db = new MainDb())
            {
                return db.listing.Count();
            }
        }

    }
}
