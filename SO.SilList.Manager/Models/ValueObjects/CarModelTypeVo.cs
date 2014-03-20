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
    [Table("CarModelType", Schema = "app" )]
    [Serializable]
    public  class CarModelTypeVo
    {
    
          
    	[DisplayName("car Model Type Id")]
    	[Required]
    	[Key]
        public int carModelTypeId { get; set; }
    
    	[DisplayName("make Type Id")]
        public Nullable<int> makeTypeId { get; set; }
    
    	[DisplayName("name")]
    	[StringLength(50)]
        public string name { get; set; }
    
    	[DisplayName("description")]
        public string description { get; set; }
    
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
    
    
        [ForeignKey("carMakeTypeId")]
        public CarMakeTypeVo carMakeType { get; set; }
       
        [Association("CarModelType_Car", "carModelTypeId", "carModelTypeId")]
        public List<CarVo> carses { get; set; }
       
      public CarModelTypeVo()
            {
    				this.isActive = true;
            }
    
    }
    
}
