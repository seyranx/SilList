
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
    		
    	[DisplayName("CAR IMAGE")]
    	[Key]
        public System.Guid carImagesId { get; set; }
    		
    	[DisplayName("IMAGE")]
        public Nullable<System.Guid> imageId { get; set; }
    		
    	[DisplayName("CAR")]
        public Nullable<System.Guid> carId { get; set; }
    		
    	[DisplayName("CREATED")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("MODIFIED")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("CREATED BY")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("MODIFIED BY")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("ACTIVE")]
        public bool isActive { get; set; }


        [ForeignKey("carId")]
        public virtual CarVo car { get; set; }

        [ForeignKey("imageId")]
        public virtual ImageVo image { get; set; }

    	public CarImagesVo(){
    			
    		this.carImagesId = Guid.NewGuid();
    	
    	 this.isActive = true;
    	}
    }
}
