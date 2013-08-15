
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
     
    [Table("CarImages", Schema = "data" )]
    [Serializable]
    public partial class CarImagesVo
    {
    		
    	[DisplayName("car image")]
    	[Key]
        public System.Guid carImagesId { get; set; }
    		
    	[DisplayName("image")]
        public Nullable<System.Guid> imageId { get; set; }
    		
    	[DisplayName("car")]
        public Nullable<System.Guid> carId { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("created by")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("modified by")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("active")]
        public bool isActive { get; set; }


        //[ForeignKey("carId")]
        //public virtual CarVo car { get; set; }

        //[ForeignKey("imageId")]
        //public virtual ImageVo image { get; set; }

    	public CarImagesVo(){
    			
    		this.carImagesId = Guid.NewGuid();
    	
    	 this.isActive = true;
    	}
    }
}
