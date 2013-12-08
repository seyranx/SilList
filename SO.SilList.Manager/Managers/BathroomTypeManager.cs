using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class BathroomTypeManager : IBathroomTypeManager
    {
        public BathroomTypeVo get(int bathroomTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.bathroomType
                            .FirstOrDefault(r => r.bathroomTypeId == bathroomTypeId);

                return result;
            }
        }

        public List<BathroomTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.bathroomType
                            .OrderBy(n => n.name)
                            .Where(e => isActive == null || e.isActive == isActive)
                            .ToList();

                return list;
            }
        }

        public BathroomTypeVm search(BathroomTypeVm input)
        {
            using (var db = new MainDb())
            {
                var query = db.bathroomType
                            //.Include(c => c.property)
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

        public bool delete(int bathroomTypeId)
        {
             using (var db = new MainDb())
            {
                var res = db.bathroomType
                     .Where(e => e.bathroomTypeId == bathroomTypeId)
                     .Delete();
                return true;
            }
        }

        public BathroomTypeVo update(BathroomTypeVo input, int? bathroomTypeId = null)
        {
            using (var db = new MainDb())
            {
                if (bathroomTypeId == null)
                    bathroomTypeId = input.bathroomTypeId;

                var res = db.bathroomType.FirstOrDefault(e => e.bathroomTypeId == bathroomTypeId);

                if (res == null) 
                    return null;

                input.created = res.created;
                input.createdBy = res.createdBy;

                db.Entry(res).CurrentValues.SetValues(input);

                db.SaveChanges();
                return res;
            }
        }

        public BathroomTypeVo insert(BathroomTypeVo input)
        {
            using (var db = new MainDb())
            {
                db.bathroomType.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.bathroomType.Count();
            }
        }
    }
}
