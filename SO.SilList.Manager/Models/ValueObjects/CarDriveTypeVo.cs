
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
    		
    	[DisplayName("car Drive Type Id")]
    	[Key]
        public int carDriveTypeId { get; set; }
    		
    	[DisplayName("name")]
    	[Required]
    	[StringLength(10)]
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


        [Association("CarDriveType_Car", "carDriveTypeId", "carDriveTypeId", IsForeignKey = true)]
        public List<CarVo> car { get; set; }

    	public CarDriveTypeVo(){

            this.isActive = true;

    	}
    }
}
