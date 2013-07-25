
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
     
    [Table("BusinessImages", Schema = "data" )]
    [Serializable]
    public partial class BusinessImagesVo
    {
    		
    	[DisplayName("image Id")]
    	[Key]
        public System.Guid imageId { get; set; }
    		
    	[DisplayName("business Id")]
        public Nullable<System.Guid> businessId { get; set; }
    		
    	[DisplayName("created")]
        public Nullable<System.DateTime> created { get; set; }
    		
    	[DisplayName("modified")]
        public Nullable<System.DateTime> modified { get; set; }
    		
    	[DisplayName("craeted By")]
        public Nullable<int> craetedBy { get; set; }
    		
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("is Active")]
        public Nullable<bool> isActive { get; set; }

        //[ForeignKey("imageId")]
        // public virtual ImageVo image { get; set; }

        //[ForeignKey("businessId")]
        // public virtual BusinessVo business { get; set; }

    	public BusinessImagesVo(){
    			
    		this.imageId = Guid.NewGuid();
    	
    	 this.isActive = true;
    	}
    }
}
