
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
     
    [Table("CarColorType", Schema = "app" )]
    [Serializable]
    public partial class CarColorTypeVo
    {
    		
    	[DisplayName("Color")]
    	[Key]
        public int carColorTypeId { get; set; }
    		
    	[DisplayName("Name")]
    	[Required]
    	[StringLength(50)]
        public string name { get; set; }
    		
    	[DisplayName("Created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("Modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("Created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("Modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("Is Active")]
    	[Required]
        public bool isActive { get; set; }



        //[Association("CarColorType_Car", "carColorTypeId", "exteriorColorTypeId", IsForeignKey = true)]
        //public List<CarVo> cars { get; set; }

        ////[Association("CarColorType_Car", "carColorTypeId", "interiorColorTypeId", IsForeignKey = true)]
        //public List<CarVo> car { get; set; }
      
    	public CarColorTypeVo(){
            this.isActive = true;
    	}
    }
}
