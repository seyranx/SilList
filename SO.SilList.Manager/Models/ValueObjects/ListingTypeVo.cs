
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
    public partial class ListingTypeVo
    {
    		
    	[DisplayName("Type")]
    	[Key]
        public int listingTypeId { get; set; }
    		
    	[DisplayName("Name")]
    	[StringLength(50)]
        public string name { get; set; }
    		
    	[DisplayName("Description")]
    	[StringLength(50)]
        public string description { get; set; }
    		
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

        [Association("ListingType_Listing", "listingTypeId", "listingTypeId", IsForeignKey = true)]
        public List<ListingVo> listings { get; set; }
      
    	public ListingTypeVo()
        {
    	    this.isActive = true;
    	}
    }
}
