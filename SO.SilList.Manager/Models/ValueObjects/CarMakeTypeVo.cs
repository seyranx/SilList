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
    [Table("CarMakeType", Schema = "app" )]
    [Serializable]
    public  class CarMakeTypeVo
    {
    
          
    	[DisplayName("car Make Type Id")]
    	[Required]
    	[Key]
        public int carMakeTypeId { get; set; }
    
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
    
    
        [Association("CarMakeType_CarModelType", "carMakeTypeId", "carMakeTypeId")]
        public List<CarModelTypeVo> carModelTypeses { get; set; }
       
      public CarMakeTypeVo()
            {
    				this.isActive = true;
            }
    
    }
    
}
