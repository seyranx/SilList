
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
     
    [Table("CarFuelType", Schema = "dbo" )]
    [Serializable]
    public partial class CarFuelTypeVo
    {
    		
    	[DisplayName("car Fuel Type Id")]
    	[Required]
        public int carFuelTypeId { get; set; }
    		
    	[DisplayName("name")]
    	[Required]
    	[StringLength(50)]
        public string name { get; set; }
    		
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
    	[Required]
        public bool isActive { get; set; }

        [Association("CarFuelType_Car", "carFuelTypeId", "carFuelTypeId", IsForeignKey = true)]
        public List<CarVo> car { get; set; }

    	public CarFuelTypeVo(){
    			this.isActive = true;

    	}
    }
}
