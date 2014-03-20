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
    public  class RatingVo
    {
    
          
    	[DisplayName("rating Id")]
    	[Required]
    	[Key]
        public Guid ratingId { get; set; }
    
    	[DisplayName("record Id")]
    	[Required]
        public Guid recordId { get; set; }
    
    	[DisplayName("rating1")]
        public Nullable<int> rating1 { get; set; }
    
    	[DisplayName("review")]
    	[StringLength(50)]
        public string review { get; set; }
    
    	[DisplayName("member Id")]
        public Nullable<int> memberId { get; set; }
    
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    
    
        [ForeignKey("memberId")]
        public MemberVo member { get; set; }
       
      public RatingVo()
            {
    				this.ratingId = Guid.NewGuid();
    				this.isActive = true;
            }
    
    }
    
}
