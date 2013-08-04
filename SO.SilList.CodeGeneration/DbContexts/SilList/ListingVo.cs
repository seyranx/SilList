
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
     
    [Table("Listing", Schema = "dbo" )]
    [Serializable]
    public partial class ListingVo
    {
    		
    	[DisplayName("listing Id")]
    	[Required]
        public System.Guid listingId { get; set; }
    		
    	[DisplayName("listing Detail Id")]
        public Nullable<System.Guid> listingDetailId { get; set; }
    		
    	[DisplayName("title")]
    	[StringLength(50)]
        public string title { get; set; }
    		
    	[DisplayName("description")]
    	[StringLength(50)]
        public string description { get; set; }
    		
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    		
    	[DisplayName("member Id")]
        public Nullable<int> memberId { get; set; }
    		
    	[DisplayName("listing Type Id")]
        public Nullable<int> listingTypeId { get; set; }
    		
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
      
    	public ListingVo(){
    			
    		this.listingId = Guid.NewGuid();
    	
    	 //this.isActive = true;
    	}
    }
}
