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
  public  class JobCategoryTypeManager : IJobCategoryTypeManager
    {
      public JobCategoryTypeVo get(int jobCategoryTypeId)
      {
          using (var db = new MainDb())
          {
              var result = db.jobCategoryTypes
                          .FirstOrDefault(b => b.jobCategoryTypeId == jobCategoryTypeId);

              return result;
          }
      }
      public JobCategoryTypeVo getFirst()
      {
          using (var db = new MainDb())
          {
              var res = db.jobCategoryTypes
                          .FirstOrDefault();

              return res;
          }
      }

      public JobCategoryTypeVm search(JobCategoryTypeVm input)
      {

          using (var db = new MainDb())
          {
              var query = db.jobCategoryTypes
 
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

      public List<JobCategoryTypeVo> getAll(bool? isActive = true)
      {
          using (var db = new MainDb())
          {
              var list = db.jobCategoryTypes
                           .Where(e => isActive == null || e.isActive == isActive)
                           .ToList();

              return list;
          }
      }
      public bool delete(int jobCategoryTypeId)
      {
          using (var db = new MainDb())
          {
              var res = db.jobCategoryTypes
                   .Where(e => e.jobCategoryTypeId == jobCategoryTypeId)
                   .Delete();
              return true;
          }
      }
      public JobCategoryTypeVo update(JobCategoryTypeVo input, int? jobCategoryTypeId = null)
      {
          using (var db = new MainDb())
          {

              if (jobCategoryTypeId == null)
                  jobCategoryTypeId = input.jobCategoryTypeId;

              var res = db.jobCategoryTypes.FirstOrDefault(e => e.jobCategoryTypeId == jobCategoryTypeId);

              if (res == null) return null;

              input.created = res.created;
              input.createdBy = res.createdBy;
              db.Entry(res).CurrentValues.SetValues(input);


              db.SaveChanges();
              return res;

          }
      }

      public JobCategoryTypeVo insert(JobCategoryTypeVo input)
      {
          using (var db = new MainDb())
          {

              db.jobCategoryTypes.Add(input);
              db.SaveChanges();

              return input;
          }
      }
      public int count()
      {
          using (var db = new MainDb())
          {
              return db.jobCategoryTypes.Count();
          }
      }
    }
}
