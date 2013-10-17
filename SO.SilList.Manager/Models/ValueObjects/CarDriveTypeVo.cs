
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
     
    [Table("CarDriveType", Schema = "app" )]
    [Serializable]
    public partial class CarDriveTypeVo
    {
    		
    	[DisplayName("Drive")]
    	[Key]
        public int carDriveTypeId { get; set; }
    		
    	[DisplayName("Name")]
    	[Required]
    	[StringLength(10)]
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


        [Association("CarDriveType_Car", "carDriveTypeId", "carDriveTypeId", IsForeignKey = true)]
        public List<CarVo> car { get; set; }

    	public CarDriveTypeVo(){

            this.isActive = true;

    	}
    }
}
