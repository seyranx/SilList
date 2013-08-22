
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
    		
    	[DisplayName("Listing")]
    	[Key]
        public System.Guid listingId { get; set; }
    		
    	//[DisplayName("listing Detail Id")]
        //public System.Guid? listingDetailId { get; set; }
    		
    	[DisplayName("Title")]
    	[StringLength(50)]
        public string title { get; set; }
    		
    	[DisplayName("Description")]
    	[StringLength(50)]
        public string description { get; set; }
    		
    	[DisplayName("Site")]
        public int? siteId { get; set; }
    		
    	[DisplayName("Listing Type")]
        public int? listingTypeId { get; set; }

        [DisplayName("Start Date")]
        [Required]
        public System.DateTime startDate { get; set; }

        [DisplayName("End Date")]
        [Required]
        public System.DateTime endDate { get; set; }

        [DisplayName("Approved")]
        public bool isApproved { get; set; }
    		
    	[DisplayName("Created By")]
        public int? createdBy { get; set; }
    		
    	[DisplayName("Modified By")]
        public int? modifiedBy { get; set; }
    		
    	[DisplayName("Created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("Modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("Active")]
    	[Required]
        public bool isActive { get; set; }

        //[ForeignKey("listingDetailId")]
        //public virtual ListingDetailVo listingDetail { get; set; }

        [DisplayName("Type")]
        [ForeignKey("listingTypeId")]
        public virtual ListingTypeVo listingType { get; set; }

        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

        [Association("ListingCategories_Listing", "listingId", "listingId", IsForeignKey = true)]
        public List<ListingCategoriesVo> listingCategories { get; set; }

        [Association("ListingImages_Listing", "listingId", "listingId", IsForeignKey = true)]
        public List<ListingImagesVo> listingImages { get; set; }
      
    	public ListingVo()
        { 			
    		this.listingId = Guid.NewGuid();
    	    this.isActive = true;
            this.isApproved = false;
    	}
    }
}
