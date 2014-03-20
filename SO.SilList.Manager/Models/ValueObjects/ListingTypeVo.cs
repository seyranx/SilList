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
    [Table("ListingType", Schema = "app" )]
    [Serializable]
    public  class ListingTypeVo
    {
    
          
    	[DisplayName("listing Type Id")]
    	[Required]
    	[Key]
        public int listingTypeId { get; set; }
    
    	[DisplayName("name")]
    	[StringLength(50)]
        public string name { get; set; }
    
    	[DisplayName("description")]
        public string description { get; set; }
    
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
    
    
        [Association("ListingType_Listing", "listingTypeId", "listingTypeId")]
        public List<ListingVo> listingses { get; set; }
       
      public ListingTypeVo()
            {
    				this.isActive = true;
            }
    
    }
    
}
