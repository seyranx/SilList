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
    public class BedroomTypeManager : IBedroomTypeManager
    {
        public BedroomTypeVo get(int bedroomTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.bedroomType
                            .FirstOrDefault(r => r.bedroomTypeId == bedroomTypeId);

                return result;
            }
        }

        public List<BedroomTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.bedroomType
                            .OrderBy(n => n.bedroomTypeId)
                            .Where(e => isActive == null || e.isActive == isActive)
                            .ToList();

                return list;
            }
        }

        public BedroomTypeVm search(BedroomTypeVm input)
        {
            using (var db = new MainDb())
            {
                var query = db.bedroomType
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

        public bool delete(int bedroomTypeId)
        {
             using (var db = new MainDb())
            {
                var res = db.bedroomType
                     .Where(e => e.bedroomTypeId == bedroomTypeId)
                     .Delete();
                return true;
            }
        }

        public BedroomTypeVo update(BedroomTypeVo input, int? bedroomTypeId = null)
        {
            using (var db = new MainDb())
            {
                if (bedroomTypeId == null)
                    bedroomTypeId = input.bedroomTypeId;

                var res = db.bedroomType.FirstOrDefault(e => e.bedroomTypeId == bedroomTypeId);

                if (res == null) 
                    return null;

                input.created = res.created;
                input.createdBy = res.createdBy;

                db.Entry(res).CurrentValues.SetValues(input);

                db.SaveChanges();
                return res;
            }
        }

        public BedroomTypeVo insert(BedroomTypeVo input)
        {
            using (var db = new MainDb())
            {
                db.bedroomType.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.bedroomType.Count();
            }
        }
    }
}
