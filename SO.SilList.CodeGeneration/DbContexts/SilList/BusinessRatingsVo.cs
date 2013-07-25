
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
     
    [Table("BusinessRatings", Schema = "dbo" )]
    [Serializable]
    public partial class BusinessRatingsVo
    {
    		
    	[DisplayName("rating Id")]
    	[Required]
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
      
    	public BusinessRatingsVo(){
    			
    		this.ratingId = Guid.NewGuid();
    	
    	 //this.isActive = true;
    	}
    }
}
