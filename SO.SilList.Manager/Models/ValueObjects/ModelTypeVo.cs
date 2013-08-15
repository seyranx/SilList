
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
    		
    	[DisplayName("Model")]
    	[Key]
        public int modelTypeId { get; set; }
    		
    	[DisplayName("Make")]
        public Nullable<int> makeTypeId { get; set; }
    		
    	[DisplayName("Name")]
    	[StringLength(50)]
        public string name { get; set; }
    		
    	[DisplayName("Description")]
        public string description { get; set; }
    		
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

        //[Association("ModelType_Car", "modelTypeId", "modelTypeId", IsForeignKey = true)]
        //public List<CarVo> car { get; set; }

        //[ForeignKey("makeTypeId")]
        //public virtual MakeTypeVo makeType { get; set; }

    	public ModelTypeVo(){
    			
    	
    	 this.isActive = true;
    	}
    }
}
