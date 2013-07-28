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
    class BusinessImageManager : IBusinessImagesManager
    {
        public BusinessImageManager() { }

        public BusinessImagesVo get(Guid imageId)
        {
            using (var db = new MainDb())
            {
                var res = db.businessImages 
                            .FirstOrDefault(p => p.imageId == imageId);

                return res;
            }
        }

        public List<BusinessImagesVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(Guid imageId)
        {
            throw new NotImplementedException();
        }

        public BusinessImagesVo update(BusinessImagesVo input, Guid? imageId = null)
        {
            throw new NotImplementedException();
        }

        public BusinessImagesVo insert(BusinessImagesVo input)
        {
            throw new NotImplementedException();
        }
    }
}
