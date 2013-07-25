
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
     
    [Table("RentalImage", Schema = "data" )]
    [Serializable]
    public partial class RentalImageVo
    {
    		
    	[DisplayName("image Id")]
    	[Key]
        public System.Guid imageId { get; set; }
    		
    	[DisplayName("rental Id")]
    	[Required]
        public System.Guid rentalId { get; set; }
    		
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
        public Nullable<bool> isActive { get; set; }

        [ForeignKey("imageId")]
        [ForeignKey("rentalId")]
      
    	public RentalImageVo(){
    			
    		this.imageId = Guid.NewGuid();
    	
    	 this.isActive = true;
    	}
    }
}
