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
     
    [Table("Rating", Schema = "data" )]
    [Serializable]
    public partial class RatingVo
    {
    		
    	[DisplayName("rating Id")]
    	[Key]
        public Guid ratingId { get; set; }
    		
    	[DisplayName("rating")]
        public int? rating { get; set; }
    		
    	[DisplayName("review")]
    	[StringLength(50)]
        public string review { get; set; }
    		
    	[DisplayName("member Id")]
        public int? memberId { get; set; }
    		
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
        public bool? isActive { get; set; }

        //[ForeignKey("foreignKeyname")]
        // public virtual SiteVo site { get; set; }

    	public RatingVo(){
    			
    	 this.ratingId = Guid.NewGuid();
    	
    	 this.isActive = true;
    	}
    }
}
