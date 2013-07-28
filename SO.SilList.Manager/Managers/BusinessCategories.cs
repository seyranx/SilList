using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Extensions;
using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Managers
{
    public class BusinessCategoriesManager : IBusinessCategoriesManager
    {

        /// <summary>
        /// Find 'BusinessCategories'
        /// </summary>
        public BusinessCategoriesVo get(Guid businessCategoryTypeIdId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get All items
        /// </summary>
        public List<BusinessCategoriesVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public BusinessCategoriesVo getFirst()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete item given the ratingID
        /// </summary>
        public bool delete(Guid businessCategoryTypeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// update the table
        /// </summary>
        public BusinessCategoriesVo update(BusinessCategoriesVo input, Guid? businessCategoryTypeId = null)
        {
            throw new NotImplementedException();
        }

        public BusinessCategoriesVo insert(BusinessCategoriesVo input)
        {
            throw new NotImplementedException();
        }


    }
}
