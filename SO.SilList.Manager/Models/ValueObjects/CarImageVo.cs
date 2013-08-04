
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
     
    [Table("CarImage", Schema = "data" )]
    [Serializable]
    public partial class CarImageVo
    {
    		
    	[DisplayName("car Images Id")]
    	[Key]
        public System.Guid carImageId { get; set; }
    		
    	[DisplayName("image Id")]
        public Nullable<System.Guid> imageId { get; set; }
    		
    	[DisplayName("car Id")]
        public Nullable<System.Guid> carId { get; set; }
    		
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


        //[ForeignKey("carId")]
        //public virtual CarVo car { get; set; }

        //[ForeignKey("imageId")]
        //public virtual ImageVo image { get; set; }

    	public CarImageVo(){
    			
    		this.carImageId = Guid.NewGuid();
    	
    	 this.isActive = true;
    	}
    }
}
