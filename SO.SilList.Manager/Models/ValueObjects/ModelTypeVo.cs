
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
     
    [Table("ModelType", Schema = "app" )]
    [Serializable]
    public partial class ModelTypeVo
    {
    		
    	[DisplayName("model")]
    	[Key]
        public int modelTypeId { get; set; }
    		
    	[DisplayName("make")]
        public Nullable<int> makeTypeId { get; set; }
    		
    	[DisplayName("name")]
    	[StringLength(50)]
        public string name { get; set; }
    		
    	[DisplayName("description")]
        public string description { get; set; }
    		
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

        [Association("ModelType_Car", "modelTypeId", "modelTypeId", IsForeignKey = true)]
        public List<CarVo> car { get; set; }

        [ForeignKey("makeTypeId")]
        public virtual MakeTypeVo makeType { get; set; }

    	public ModelTypeVo(){
    			
    	
    	 this.isActive = true;
    	}
    }
}
