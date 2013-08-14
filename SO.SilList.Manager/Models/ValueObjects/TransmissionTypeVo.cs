
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
     
    [Table("TransmissionType", Schema = "app" )]
    [Serializable]
    public partial class TransmissionTypeVo
    {
    		
    	[DisplayName("transmission")]
    	[Key]
        public int transmissionTypeId { get; set; }
    		
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

        [Association("TransmissionType_Car", "transmissionTypeId", "transmissionTypeId", IsForeignKey = true)]
        public List<CarVo> car { get; set; }

    	public TransmissionTypeVo(){
    			
    	
    	 this.isActive = true;
    	}
    }
}
