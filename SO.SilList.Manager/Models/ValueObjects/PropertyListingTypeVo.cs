
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
     
    [Table("PropertyListingType", Schema = "app" )]
    [Serializable]
    public partial class PropertyListingTypeVo
    {
    		
    	[DisplayName("Property Listing Type")]
    	[Key]
        public int propertyListingTypeId { get; set; }
    		
    	[DisplayName("Name")]
    	[StringLength(50)]
        public string name { get; set; }
    		
    	[DisplayName("Description")]
        public string description { get; set; }
    		
    	[DisplayName("Modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("Modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("Created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("Created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("Active")]
    	[Required]
        public bool isActive { get; set; }

        [Association("LeaseTermType_Property", "propertyListingTypeId", "propertyListingTypeId", IsForeignKey = true)]
        public List<PropertyVo> property { get; set; }
      
    	public PropertyListingTypeVo()
        {
    			this.isActive = true;
    	}
    }
}
