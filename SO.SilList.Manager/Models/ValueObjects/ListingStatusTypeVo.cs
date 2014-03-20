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
    [Table("ListingStatusType", Schema = "app" )]
    [Serializable]
    public  class ListingStatusTypeVo
    {
    
          
    	[DisplayName("listing Status Type Id")]
    	[Required]
    	[Key]
        public int listingStatusTypeId { get; set; }
    
    	[DisplayName("name")]
    	[Required]
    	[StringLength(50)]
        public string name { get; set; }
    
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    
    	[DisplayName("is Active")]
        public Nullable<bool> isActive { get; set; }
    
    
        [Association("ListingStatusType_Business", "listingStatusTypeId", "listingStatusTypeId")]
        public List<BusinessVo> businesseses { get; set; }
       
        [Association("ListingStatusType_Car", "listingStatusTypeId", "listingStatusTypeId")]
        public List<CarVo> carses { get; set; }
       
        [Association("ListingStatusType_Job", "listingStatusTypeId", "listingStatusTypeId")]
        public List<JobVo> jobses { get; set; }
       
        [Association("ListingStatusType_Listing", "listingStatusTypeId", "listingStatusTypeId")]
        public List<ListingVo> listingses { get; set; }
       
        [Association("ListingStatusType_Property", "listingStatusTypeId", "listingStatusTypeId")]
        public List<PropertyVo> propertieses { get; set; }
       
      public ListingStatusTypeVo()
            {
    				this.isActive = true;
            }
    
    }
    
}
