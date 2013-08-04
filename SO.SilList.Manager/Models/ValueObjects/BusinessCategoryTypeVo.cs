
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
    public partial class BusinessCategoryTypeVo
    {
    		
    	[DisplayName("business Category Type Id")]
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
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    		
    	[DisplayName("site Id")]
        public int? siteId { get; set; }

        //[ForeignKey("siteId")]
        //public virtual SiteVo site { get; set; }

        [Association("BusinessCategoryType_BusinessCategories", "BusinessCateoryTypeId", "BusinessCateoryTypeId", IsForeignKey = true)]
        public List<BusinessCategoriesVo> businessCategories { get; set; }

    	public BusinessCategoryTypeVo(){
    	    this.isActive = true;
    	}
    }
}
