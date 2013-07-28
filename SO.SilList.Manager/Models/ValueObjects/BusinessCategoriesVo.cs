
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
     
    [Table("BusinessCategories", Schema = "data" )]
    [Serializable]
    public partial class BusinessCategoriesVo
    {

        [DisplayName("business Category Id")]
        [Key]
        public System.Guid businessCategoryId { get; set; }

    	[DisplayName("business Id")]
        public Nullable<System.Guid> businessId { get; set; }
    		
    	[DisplayName("business Category Type Id")]
        public Nullable<int> businessCategoryTypeId { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("is Active")]
        public Nullable<bool> isActive { get; set; }

        [ForeignKey("businessId")]
        public virtual BusinessVo business { get; set; }

        [ForeignKey("businessCategoryTypeId")]
        public virtual BusinessCategoryTypeVo businessCategoryType { get; set; }

    	public BusinessCategoriesVo(){
    			
    	 this.businessId = Guid.NewGuid();
    	
    	 this.isActive = true;
    	}
    }
}
