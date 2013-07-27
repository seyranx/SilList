using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Models.ValueObjects;


namespace SO.SilList.Manager.Managers
{
    public class ImageManager : IImageManager
    {
        /// <summary>
        /// Find Image matching the imageId (primary key)
        /// </summary>
        public ImageVo get(Guid imageId)
        {
            using (var db = new MainDb())
            {
                var res = db.images
                            .Include(s => s.site)
                            .FirstOrDefault(p => p.imageId == imageId);

                return res;
            }
        }

        public List<ImageVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        public bool delete(Guid imageId)
        {
            throw new NotImplementedException();
        }

        public ImageVo update(ImageVo input, Guid? imageId = null)
        {
            throw new NotImplementedException();
        }

        public ImageVo insert(ImageVo input)
        {
            throw new NotImplementedException();
        }
    }
}
