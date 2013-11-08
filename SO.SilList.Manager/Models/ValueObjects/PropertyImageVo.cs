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
     
    [Table("PropertyImages", Schema = "data" )]
    [Serializable]
    public partial class PropertyImageVo
    {
    		
    	[DisplayName("property Image Id")]
    	[Key]
        public System.Guid propertyImageId { get; set; }

        [DisplayName("image Id")]      
        public System.Guid? imageId { get; set; }
    		
    	[DisplayName("property Id")]
        public System.Guid? propertyId { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("created By")]
        public int? createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public int? modifiedBy { get; set; }
    		
    	[DisplayName("is Active")]
        public bool isActive { get; set; }

        [ForeignKey("imageId")]
        public virtual ImageVo image { get; set; }

        [ForeignKey("propertyId")]
        public virtual PropertyVo property { get; set; }
      
    	public PropertyImageVo()
        {
    		this.propertyImageId = Guid.NewGuid();
    	    this.isActive = true;
    	}
    }
}
