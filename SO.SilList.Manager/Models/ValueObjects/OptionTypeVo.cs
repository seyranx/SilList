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
    [Table("OptionType", Schema = "app" )]
    [Serializable]
    public  class OptionTypeVo
    {
    
          
    	[DisplayName("option Type Id")]
    	[Required]
    	[Key]
        public int optionTypeId { get; set; }
    
    	[DisplayName("group Name")]
    	[Required]
    	[StringLength(100)]
        public string groupName { get; set; }
    
    	[DisplayName("name")]
    	[StringLength(100)]
        public string name { get; set; }
    
    	[DisplayName("value")]
    	[StringLength(100)]
        public string value { get; set; }
    
    	[DisplayName("description")]
        public string description { get; set; }
    
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    
      public OptionTypeVo()
            {
    				this.isActive = true;
            }
    
    }
    
}
