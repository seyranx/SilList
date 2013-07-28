
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
     
    [Table("BusinessRatings", Schema = "data" )]
    [Serializable]
    public partial class BusinessRatingsVo
    {
    		
    	[DisplayName("rating Id")]
    	[Key]
        public System.Guid ratingId { get; set; }
    		
    	[DisplayName("business Id")]
        public Nullable<System.Guid> businessId { get; set; }
    		
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


       // [ForeignKey("ratingId")]
       // public virtual RatingVo rating { get; set; }

       // [ForeignKey("businessId")]
       // public virtual BusinessVo business { get; set; }
      
    	public BusinessRatingsVo(){
    			
    	this.ratingId = Guid.NewGuid();
    	
    	this.isActive = true;
    	}
    }
}
