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

namespace SO.SilList.Manager.Managers
{
    class IsPetAllowedManager : IIsPetAllowedManager
    {
        public IsPetAllowedTypeVo get(int isPetAllowedTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.isPetAllowedType
                            .FirstOrDefault(r => r.isPetAllowedTypeId == isPetAllowedTypeId);

                return result;
            }
        }

        public List<IsPetAllowedTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.isPetAllowedType
                            .OrderBy(n => n.isPetAllowedTypeId)
                            .Where(e => isActive == null || e.isActive == isActive)
                            .ToList();

                return list;
            }
        }

        public IsPetAllowedTypeVm search(IsPetAllowedTypeVm input)
        {
            using (var db = new MainDb())
            {
                var query = db.isPetAllowedType
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

        public bool delete(int isPetAllowedTypeId)
        {
             using (var db = new MainDb())
            {
                var res = db.isPetAllowedType
                     .Where(e => e.isPetAllowedTypeId == isPetAllowedTypeId)
                     .Delete();
                return true;
            }
        }

        public IsPetAllowedTypeVo update(IsPetAllowedTypeVo input, int? isPetAllowedTypeId = null)
        {
            using (var db = new MainDb())
            {
                if (isPetAllowedTypeId == null)
                    isPetAllowedTypeId = input.isPetAllowedTypeId;

                var res = db.isPetAllowedType.FirstOrDefault(e => e.isPetAllowedTypeId == isPetAllowedTypeId);

                if (res == null) 
                    return null;

                input.created = res.created;
                input.createdBy = res.createdBy;

                db.Entry(res).CurrentValues.SetValues(input);

                db.SaveChanges();
                return res;
            }
        }

        public IsPetAllowedTypeVo insert(IsPetAllowedTypeVo input)
        {
            using (var db = new MainDb())
            {
                db.isPetAllowedType.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.isPetAllowedType.Count();
            }
        }
    }
}
