using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Managers
{
    public class BusinessCategoryTypeManager : IBusinessCategoryTypeManager
    {
        public BusinessCategoryTypeVo get(int businessCategoryTypeId)
        {
            using (var db = new MainDb())
            {
                var result = db.businessCategoryType
                            .FirstOrDefault(b => b.businessCategoryTypeId == businessCategoryTypeId);

                return result;
            }
        }

        public List<BusinessCategoryTypeVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(int businessCategoryTypeId)
        {
            throw new NotImplementedException();
        }

        public BusinessCategoryTypeVo update(BusinessCategoryTypeVo input, int? businessCategoryTypeId = null)
        {
            throw new NotImplementedException();
        }

        public BusinessCategoryTypeVo insert(BusinessCategoryTypeVo input)
        {
            throw new NotImplementedException();
        }
    }
}
