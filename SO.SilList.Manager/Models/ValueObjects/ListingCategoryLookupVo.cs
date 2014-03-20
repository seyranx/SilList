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
    [Table("ListingCategoryLookup", Schema = "data" )]
    [Serializable]
    public  class ListingCategoryLookupVo
    {
    
          
    	[DisplayName("listing Category Lookup Id")]
    	[Required]
    	[Key]
        public Guid listingCategoryLookupId { get; set; }
    
    	[DisplayName("listing Category Type Id")]
        public Nullable<int> listingCategoryTypeId { get; set; }
    
    	[DisplayName("listing Id")]
        public Nullable<Guid> listingId { get; set; }
    
    	[DisplayName("created By_")]
        public Nullable<int> createdBy_ { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    
    
        [ForeignKey("listingCategoryTypeId")]
        public ListingCategoryTypeVo listingCategoryType { get; set; }
       
        [ForeignKey("listingId")]
        public ListingVo listing { get; set; }
       
      public ListingCategoryLookupVo()
            {
    				this.listingCategoryLookupId = Guid.NewGuid();
    				this.isActive = true;
            }
    
    }
    
}
