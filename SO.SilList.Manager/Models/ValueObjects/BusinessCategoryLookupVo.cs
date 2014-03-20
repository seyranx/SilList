using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SO.SilList.Manager.Models.ValueObjects
{
    [Table("BusinessCategoryLookup", Schema = "data" )]
    [Serializable]
    public  class BusinessCategoryLookupVo
    {
    
          
    	[DisplayName("business Category Lookup Id")]
    	[Required]
    	[Key]
        public Guid businessCategoryLookupId { get; set; }
    
    	[DisplayName("business Id")]
        public Nullable<Guid> businessId { get; set; }
    
    	[DisplayName("business Category Type Id")]
        public Nullable<int> businessCategoryTypeId { get; set; }
    
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    
    
        [ForeignKey("businessCategoryTypeId")]
        public BusinessCategoryTypeVo businessCategoryType { get; set; }
       
        [ForeignKey("businessId")]
        public BusinessVo business { get; set; }
       
      public BusinessCategoryLookupVo()
            {
    				this.businessCategoryLookupId = Guid.NewGuid();
    				this.isActive = true;
            }
    
    }
    
}
