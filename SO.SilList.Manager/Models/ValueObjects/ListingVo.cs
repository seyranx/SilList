
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
     
    [Table("Listing", Schema = "data" )]
    [Serializable]
    public partial class ListingVo
    {
    		
    	[DisplayName("listing Id")]
    	[Key]
        public System.Guid listingId { get; set; }
    		
    	[DisplayName("listing Detail Id")]
        public System.Guid? listingDetailId { get; set; }
    		
    	[DisplayName("title")]
    	[StringLength(50)]
        public string title { get; set; }
    		
    	[DisplayName("description")]
    	[StringLength(50)]
        public string description { get; set; }
    		
    	[DisplayName("site Id")]
        public int? siteId { get; set; }
    		
    	[DisplayName("listing Type Id")]
        public int? listingTypeId { get; set; }
    		
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

        [ForeignKey("listingDetailId")]
        public virtual ListingDetailVo listingDetail { get; set; }

        [ForeignKey("listingTypeId")]
        public virtual ListingTypeVo listingType { get; set; }

        [Association("ListingCategories_Listing", "listingId", "listingId", IsForeignKey = true)]
        public List<ListingCategoriesVo> listingCategories { get; set; }

        [Association("ListingImages_Listing", "listingId", "listingId", IsForeignKey = true)]
        public List<ListingImagesVo> listings { get; set; }
      
    	public ListingVo()
        { 			
    		this.listingId = Guid.NewGuid();
    	    this.isActive = true;
    	}
    }
}
