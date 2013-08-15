
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

        [DisplayName("business Rating Id")]
        [Key]
        public Guid businessRatingId { get; set; }		

    	[DisplayName("rating Id")]
        public Guid? ratingId { get; set; }
    		
    	[DisplayName("business Id")]
        public Guid? businessId { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    		
    	[DisplayName("created By")]
        public int? createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public int? modifiedBy { get; set; }
    		
    	[DisplayName("is Active")]
        public bool isActive { get; set; }


        //[ForeignKey("ratingId")]
        //public virtual RatingVo rating { get; set; }

        //[ForeignKey("businessId")]
        //public virtual BusinessVo business { get; set; }
      
    	public BusinessRatingsVo(){

        this.businessRatingId = Guid.NewGuid();
    	
    	this.isActive = true;
    	}
    }
}
