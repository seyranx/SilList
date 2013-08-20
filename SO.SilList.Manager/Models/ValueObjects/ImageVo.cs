
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
     
    [Table("Image", Schema = "data" )]
    [Serializable]
    public partial class ImageVo
    {

    	[DisplayName("image Id")]
        [Key]
        public System.Guid imageId { get; set; }
    		
    	[DisplayName("name")]
    	[StringLength(50)]
        public string name { get; set; }
    		
    	[DisplayName("url")]
    	[StringLength(50)]
        public string url { get; set; }
    		
    	[DisplayName("path")]
    	[StringLength(50)]
        public string path { get; set; }
    		
    	[DisplayName("file Type")]
    	[StringLength(50)]
        public string fileType { get; set; }
    		
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    		
    	[DisplayName("height")]
        public Nullable<int> height { get; set; }
    		
    	[DisplayName("width")]
        public Nullable<int> width { get; set; }
    		
    	[DisplayName("size")]
        public Nullable<int> size { get; set; }
    		
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
        public bool isActive { get; set; }

        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

        [Association("Image_BusinessImages", "imageId", "imageId", IsForeignKey = true)]
        public List<BusinessImagesVo> businessImages { get; set; }

        [Association("Image_CarImages", "imageId", "imageId", IsForeignKey = true)]
        public List<CarImagesVo> carImages { get; set; }

        [Association("Image_RentalImages", "imageId", "imageId", IsForeignKey = true)]
        public List<RentalImageVo> rentalImages { get; set; }

        [Association("Image_ListingImages", "imageId", "imageId", IsForeignKey = true)]
        public List<ListingImagesVo> listingImages { get; set; }

     	public ImageVo(){
    			
    		this.imageId = Guid.NewGuid();
    	
    	    this.isActive = true;
    	}
    }
}
