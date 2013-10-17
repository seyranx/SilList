
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
     
    [Table("StateType", Schema = "app" )]
    [Serializable]
    public partial class StateTypeVo
    {
    		
    	[DisplayName("State")]
    	[Key]
        public int stateTypeId { get; set; }
    		
    	[DisplayName("Name")]
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




        [Association("StateType_Car", "stateTypeId", "stateTypeId", IsForeignKey = true)]
        public List<CarVo> car { get; set; }

        [Association("StateType_Job", "stateTypeId", "stateTypeId", IsForeignKey = true)]
        public List<JobVo> job { get; set; }

        [Association("StateType_Business", "stateTypeId", "stateTypeId", IsForeignKey = true)]
        public List<BusinessVo> business { get; set; }

        [Association("StateType_Listing", "stateTypeId", "stateTypeId", IsForeignKey = true)]
        public List<ListingVo> listing { get; set; }

        [Association("StateType_Rental", "stateTypeId", "stateTypeId", IsForeignKey = true)]
        public List<RentalVo> rental { get; set; }

        [Association("StateType_Member", "stateTypeId", "stateTypeId", IsForeignKey = true)]
        public List<MemberVo> member { get; set; }

    	public StateTypeVo(){
            this.isActive = true;

    	}
    }
}
