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
    [Table("PropertyType", Schema = "app" )]
    [Serializable]
    public  class PropertyTypeVo
    {
    
          
    	[DisplayName("property Type Id")]
    	[Required]
    	[Key]
        public int propertyTypeId { get; set; }
    
    	[DisplayName("name")]
    	[StringLength(50)]
        public string name { get; set; }
    
    	[DisplayName("description")]
    	[StringLength(50)]
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
    
    
        [Association("PropertyType_Property", "propertyTypeId", "propertyTypeId")]
        public List<PropertyVo> propertieses { get; set; }
       
      public PropertyTypeVo()
            {
    				this.isActive = true;
            }
    
    }
    
}
