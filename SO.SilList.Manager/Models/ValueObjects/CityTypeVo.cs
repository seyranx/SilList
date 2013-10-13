
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
     
    [Table("CityType", Schema = "dbo" )]
    [Serializable]
    public partial class CityTypeVo
    {
    		
    	[DisplayName("city Type Id")]
    	[Required]
        public int cityTypeId { get; set; }
    		
    	[DisplayName("name")]
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



        [Association("CityType_Car", "cityTypeId", "cityTypeId", IsForeignKey = true)]
        public List<CarVo> car { get; set; }

        [Association("CityType_Job", "cityTypeId", "cityTypeId", IsForeignKey = true)]
        public List<JobVo> job { get; set; }

        [Association("CityType_Business", "cityTypeId", "cityTypeId", IsForeignKey = true)]
        public List<BusinessVo> business { get; set; }

        [Association("CityType_Listing", "cityTypeId", "cityTypeId", IsForeignKey = true)]
        public List<ListingVo> listing { get; set; }

        [Association("CityType_Rental", "cityTypeId", "cityTypeId", IsForeignKey = true)]
        public List<RentalVo> rental { get; set; }

        [Association("CityType_Member", "cityTypeId", "cityTypeId", IsForeignKey = true)]
        public List<MemberVo> member { get; set; }

        public CityTypeVo(){

            this.isActive = true;

    	}
    }
}
