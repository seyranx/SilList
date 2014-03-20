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
    [Table("Image", Schema = "data" )]
    [Serializable]
    public  class ImageVo
    {
    
          
    	[DisplayName("image Id")]
    	[Required]
    	[Key]
        public Guid imageId { get; set; }
    
    	[DisplayName("record Id")]
        public Nullable<Guid> recordId { get; set; }
    
    	[DisplayName("name")]
    	[StringLength(50)]
        public string name { get; set; }
    
    	[DisplayName("url")]
    	[StringLength(250)]
        public string url { get; set; }
    
    	[DisplayName("path")]
    	[StringLength(250)]
        public string path { get; set; }
    
    	[DisplayName("file Type")]
    	[StringLength(50)]
        public string fileType { get; set; }
    
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    
    	[DisplayName("height")]
        public Nullable<int> height { get; set; }
    
    	[DisplayName("width")]
        public Nullable<int> width { get; set; }
    
    	[DisplayName("size")]
        public Nullable<int> size { get; set; }
    
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
    
      public ImageVo()
            {
    				this.imageId = Guid.NewGuid();
    				this.isActive = true;
            }
    
    }
    
}
