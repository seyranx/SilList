
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
     
    [Table("ListingCategories", Schema = "data" )]
    [Serializable]
    public partial class ListingCategoriesVo
    {
    		
    	[DisplayName("listing Category Id")]
    	[Key]
        public System.Guid listingCategoryId { get; set; }
    		
    	[DisplayName("listing Category Type Id")]
        public int? listingCategoryTypeId { get; set; }
    		
    	[DisplayName("listing Id")]
        public System.Guid? listingId { get; set; }
    		
    	[DisplayName("created By")]
        public int? createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public int? modifiedBy { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }

        [ForeignKey("listingId")]
        public virtual ListingVo listing { get; set; }

        [ForeignKey("listingCategoryTypeId")]
        public virtual ListingCategoryTypeVo listingCategoryType { get; set; }
      
    	public ListingCategoriesVo()
        {    			
    		this.listingCategoryId = Guid.NewGuid();
    	    this.isActive = true;
    	}
    }
}
