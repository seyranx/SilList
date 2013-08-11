
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
    		
    	[DisplayName("BODY")]
    	[Key]
        public int carBodyTypeId { get; set; }
    		
    	[DisplayName("NAME")]
    	[StringLength(50)]
        public string name { get; set; }
    		
    	[DisplayName("DESCRIPTION")]
        public string description { get; set; }
    		
    	[DisplayName("CREATED")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("MODIFIED")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("CREATED BY")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("MODIFIED BY")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("ACTIVE")]
        public bool isActive { get; set; }

        [Association("CarBodyType_Car", "carBodyTypeId", "carBodyTypeId", IsForeignKey = true)]
        public List<CarVo> car { get; set; }

    	public CarBodyTypeVo(){
    			
    	
    	 this.isActive = true;
    	}
    }
}
