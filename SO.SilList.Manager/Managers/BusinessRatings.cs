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
    public class BusinessRatingsManager : IBusinessRatingsManager
    {

        /// <summary>
        /// Find 'BusinessRating'
        /// </summary>
        public BusinessRatingsVo get(Guid ratingId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get All items
        /// </summary>
        public List<BusinessRatingsVo> getAll(bool? isActive = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get First Item
        /// </summary>
        public BusinessRatingsVo getFirst()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete item given the ratingID
        /// </summary>
        public bool delete(Guid ratingId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// update the table
        /// </summary>
        public BusinessRatingsVo update(BusinessRatingsVo input, Guid? ratingId = null)
        {
            throw new NotImplementedException();
        }

        public BusinessRatingsVo insert(BusinessRatingsVo input)
        {
            throw new NotImplementedException();
        }


    }
}
