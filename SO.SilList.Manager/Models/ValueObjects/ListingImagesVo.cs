
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
    		
    	[DisplayName("listing Images Id")]
    	[Key]
        public System.Guid listingImageId { get; set; }
    		
    	[DisplayName("image Id")]
        public System.Guid? imageId { get; set; }
    		
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

      
    	public ListingImagesVo()
        {	
    		this.listingImageId = Guid.NewGuid();   	
    	    this.isActive = true;
    	}
    }
}
