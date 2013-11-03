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
    public class TransmissionTypeManager : ITransmissionTypeManager
    {
        public TransmissionTypeManager()
        {}
        public TransmissionTypeVo get(int transmissionTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.transmissionType
                            .FirstOrDefault(r => r.transmissionTypeId == transmissionTypeId);

                return result;
            }
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public TransmissionTypeVo getFirst()
        {
            using (var db = new MainDb())
            {
                var res = db.transmissionType
                            .FirstOrDefault();

                return res;
            }
        }

        public TransmissionTypeVm search(TransmissionTypeVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.transmissionType
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

        public List<TransmissionTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.transmissionType
                     .OrderBy(b => b.name)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(int transmissionTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.transmissionType
                     .Where(e => e.transmissionTypeId == transmissionTypeId)
                     .Delete();
                return true;
            }
        }

        public TransmissionTypeVo update(TransmissionTypeVo input, int? transmissionTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (transmissionTypeId == null)
                    transmissionTypeId = input.transmissionTypeId;

                var res = db.transmissionType.FirstOrDefault(e => e.transmissionTypeId == transmissionTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public TransmissionTypeVo insert(TransmissionTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.transmissionType.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.transmissionType.Count();
            }
        }
    }
}
