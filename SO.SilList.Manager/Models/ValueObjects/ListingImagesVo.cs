
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
     
    [Table("ListingImages", Schema = "data" )]
    [Serializable]
    public partial class ListingImagesVo
    {
    		
    	[DisplayName("Listing Images Id")]
    	[Key]
        public System.Guid listingImageId { get; set; }
    		
    	[DisplayName("Image Id")]
        public System.Guid? imageId { get; set; }
    		
    	[DisplayName("Listing Id")]
        public System.Guid? listingId { get; set; }
    		
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

        [ForeignKey("listingId")]
        public virtual ListingVo listing { get; set; }

        [ForeignKey("imageId")]
        public virtual ImageVo images { get; set; }

        [ForeignKey("imageId")]
        public virtual ImageVo image { get; set; }
      
    	public ListingImagesVo()
        {	
    		this.listingImageId = Guid.NewGuid();   	
    	    this.isActive = true;
    	}
    }
}
