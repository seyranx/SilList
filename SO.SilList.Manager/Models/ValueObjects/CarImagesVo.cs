
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
    		
    	[DisplayName("Car Image")]
    	[Key]
        public System.Guid carImagesId { get; set; }
    		
    	[DisplayName("Image")]
        public Nullable<System.Guid> imageId { get; set; }
    		
    	[DisplayName("Car")]
        public Nullable<System.Guid> carId { get; set; }
    		
    	[DisplayName("Created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("Modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("Created by")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("Modified by")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("Active")]
        public bool isActive { get; set; }


        //[ForeignKey("carId")]
        //public virtual CarVo car { get; set; }

        [ForeignKey("imageId")]
        public virtual ImageVo image { get; set; }

    	public CarImagesVo(){
    			
    		this.carImagesId = Guid.NewGuid();
    	
    	 this.isActive = true;
    	}
    }
}
