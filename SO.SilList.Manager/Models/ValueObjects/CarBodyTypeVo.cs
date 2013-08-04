
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
     
    [Table("CarBodyType", Schema = "app" )]
    [Serializable]
    public partial class CarBodyTypeVo
    {
    		
    	[DisplayName("car Body Type Id")]
    	[Key]
        public int carBodyTypeId { get; set; }
    		
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
    		
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("is Active")]
        public Nullable<bool> isActive { get; set; }

        [Association("CarBodyType_Car", "carBodyTypeId", "carBodyTypeId", IsForeignKey = true)]
        public List<CarVo> car { get; set; }

    	public CarBodyTypeVo(){
    			
    	
    	 this.isActive = true;
    	}
    }
}
