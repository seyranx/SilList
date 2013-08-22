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
        public Guid businessCategoryId { get; set; }
  		
    	[DisplayName("business Id")]
        public Guid? businessId { get; set; }
    		
    	[DisplayName("business Category Type Id")]
        public int? businessCategoryTypeId { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    		
    	[DisplayName("created By")]
        public int? createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public int? modifiedBy { get; set; }
    		
    	[DisplayName("is Active")]
        public bool isActive { get; set; }

        [ForeignKey("businessId")]
        public virtual BusinessVo business { get; set; }

        [ForeignKey("businessCategoryTypeId")]
        public virtual BusinessCategoryTypeVo businessCategoryType { get; set; }

    	public BusinessCategoriesVo(){

         this.businessCategoryId = Guid.NewGuid();
    	
    	 this.isActive = true;
    	}
    }
}
