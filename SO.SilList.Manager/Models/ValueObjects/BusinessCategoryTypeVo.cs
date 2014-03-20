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
    [Table("BusinessCategoryType", Schema = "app" )]
    [Serializable]
    public  class BusinessCategoryTypeVo
    {
    
          
    	[DisplayName("business Category Type Id")]
    	[Required]
    	[Key]
        public int businessCategoryTypeId { get; set; }
    
    	[DisplayName("name")]
    	[Required]
    	[StringLength(200)]
        public string name { get; set; }
    
    	[DisplayName("description")]
        public string description { get; set; }
    
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    
    
        [Association("BusinessCategoryType_BusinessCategoryLookup", "businessCategoryTypeId", "businessCategoryTypeId")]
        public List<BusinessCategoryLookupVo> businessCategoryLookupses { get; set; }
       
      public BusinessCategoryTypeVo()
            {
    				this.isActive = true;
            }
    
    }
    
}
