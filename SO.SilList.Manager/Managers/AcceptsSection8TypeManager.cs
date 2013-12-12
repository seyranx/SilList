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
    public class AcceptsSection8TypeManager : IAcceptsSection8TypeManager
    {
        public AcceptsSection8TypeVo get(int acceptsSection8TypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.acceptsSection8Type
                            .FirstOrDefault(r => r.acceptsSection8TypeId == acceptsSection8TypeId);

                return result;
            }
        }

        public List<AcceptsSection8TypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.acceptsSection8Type
                            .OrderBy(n => n.acceptsSection8TypeId)
                            .Where(e => isActive == null || e.isActive == isActive)
                            .ToList();

                return list;
            }
        }

        public AcceptsSection8TypeVm search(AcceptsSection8TypeVm input)
        {
            using (var db = new MainDb())
            {
                var query = db.acceptsSection8Type
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

        public bool delete(int acceptsSection8TypeId)
        {
             using (var db = new MainDb())
            {
                var res = db.acceptsSection8Type
                     .Where(e => e.acceptsSection8TypeId == acceptsSection8TypeId)
                     .Delete();
                return true;
            }
        }

        public AcceptsSection8TypeVo update(AcceptsSection8TypeVo input, int? acceptsSection8TypeId = null)
        {
            using (var db = new MainDb())
            {
                if (acceptsSection8TypeId == null)
                    acceptsSection8TypeId = input.acceptsSection8TypeId;

                var res = db.acceptsSection8Type.FirstOrDefault(e => e.acceptsSection8TypeId == acceptsSection8TypeId);

                if (res == null) 
                    return null;

                input.created = res.created;
                input.createdBy = res.createdBy;

                db.Entry(res).CurrentValues.SetValues(input);

                db.SaveChanges();
                return res;
            }
        }

        public AcceptsSection8TypeVo insert(AcceptsSection8TypeVo input)
        {
            using (var db = new MainDb())
            {
                db.acceptsSection8Type.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.acceptsSection8Type.Count();
            }
        }
    }
}
