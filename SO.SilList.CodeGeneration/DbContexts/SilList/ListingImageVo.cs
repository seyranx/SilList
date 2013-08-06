
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

namespace SO.SilList.CodeGeneration.DbContexts.SilList
{
     
    [Table("ListingImage", Schema = "dbo" )]
    [Serializable]
    public partial class ListingImageVo
    {
    		
    	[DisplayName("listing Images Id")]
    	[Required]
        public System.Guid listingImagesId { get; set; }
    		
    	[DisplayName("image Id")]
        public Nullable<System.Guid> imageId { get; set; }
    		
    	[DisplayName("listing Id")]
        public Nullable<System.Guid> listingId { get; set; }
    		
    	[DisplayName("created By_")]
        public Nullable<int> createdBy_ { get; set; }
    		
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
      
    	public ListingImageVo(){
    			
    		this.listingImagesId = Guid.NewGuid();
    	
    	 //this.isActive = true;
    	}
    }
}
