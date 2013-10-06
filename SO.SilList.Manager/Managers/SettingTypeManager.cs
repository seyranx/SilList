using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Managers
{
    public class SettingTypeManager : ISettingTypeManager 
    {
        public SettingTypeVo get(int settingTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.settingTypes
                            .FirstOrDefault(b => b.settingTypeId == settingTypeId);

                return result;
            }
        }
        public SettingTypeVm search(SettingTypeVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.settingTypes
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

        public List<SettingTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.settingTypes
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();

                return list;
            }
        }

        public bool delete(int settingTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.settingTypes
                     .Where(e => e.settingTypeId == settingTypeId)
                     .Delete();
                return true;
            }
        }

        public Models.ValueObjects.SettingTypeVo update(Models.ValueObjects.SettingTypeVo input, int? settingTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (settingTypeId == null)
                    settingTypeId = input.settingTypeId;

                var res = db.settingTypes.FirstOrDefault(e => e.settingTypeId == settingTypeId);

                if (res == null) return null;

                input.created = res.created;
                input.createdBy = res.createdBy;
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }

        }

        public Models.ValueObjects.SettingTypeVo insert(Models.ValueObjects.SettingTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.settingTypes.Add(input);
                db.SaveChanges();

                return input;
            }
        }
    }
}
