using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Manager.Managers
{
    public class CountryTypeManager : ICountryTypeManager
    {
        public CountryTypeManager()
        {

        }

        public CountryTypeVo get(int countryTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.countryType

                            

                            .FirstOrDefault(r => r.countryTypeId == countryTypeId);

                return result;
            }
        }


        public CountryTypeVm search(CountryTypeVm input)
        {

            using (var db = new MainDb())
            {
                var query = db.countryType

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

        public List<CountryTypeVo> getAll(bool? isActive = true)
        {
            using (var db = new MainDb())
            {
                var list = db.countryType
                    .OrderBy(b => b.name)
                             .Where(e => isActive == null || e.isActive == isActive)
                             .ToList();
                

                return list;
            }
        }

        public bool delete(int countryTypeId)
        {
            using (var db = new MainDb())
            {
                var res = db.countryType
                     .Where(e => e.countryTypeId == countryTypeId)
                     .Delete();
                return true;
            }
        }

        public CountryTypeVo update(CountryTypeVo input, int? countryTypeId = null)
        {
            using (var db = new MainDb())
            {

                if (countryTypeId == null)
                    countryTypeId = input.countryTypeId;

                var res = db.countryType.FirstOrDefault(e => e.countryTypeId == countryTypeId);

                if (res == null) return null;
                
                input.created = res.created;
                input.createdBy = res.createdBy;
               
                db.Entry(res).CurrentValues.SetValues(input);


                db.SaveChanges();
                return res;

            }
        }

        public CountryTypeVo insert(CountryTypeVo input)
        {
            using (var db = new MainDb())
            {

                db.countryType.Add(input);
                db.SaveChanges();

                return input;
            }
        }

        public int count()
        {
            using (var db = new MainDb())
            {
                return db.countryType.Count();
            }
        }
    }
}
