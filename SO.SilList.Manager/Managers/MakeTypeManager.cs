using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Managers
{
    public class MakeTypeManager : IMakeTypeManager
    {
        public MakeTypeManager()
        {}
        public MakeTypeVo get(int makeTypeId)
        {

            using (var db = new MainDb())
            {
                var result = db.makeType
                            .FirstOrDefault(r => r.makeTypeId == makeTypeId);

                return result;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public MakeTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.makeType
                            .FirstOrDefault();

                return res;
            }
        }

        public MakeTypeVm search(MakeTypeVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.makeType
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

        public List<MakeTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.makeType
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(int makeTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.makeType
                     .Where(e => e.makeTypeId == makeTypeId)
                     .Delete();
                return true;
            }
        }

        public MakeTypeVo update(MakeTypeVo input, int? makeTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (makeTypeId == null)
                    makeTypeId = input.makeTypeId;

                var res = db.makeType.FirstOrDefault(e => e.makeTypeId == makeTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public MakeTypeVo insert(MakeTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.makeType.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.makeType.Count();
            }
        }
    }
}
