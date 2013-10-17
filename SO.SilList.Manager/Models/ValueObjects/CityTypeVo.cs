
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
     
    [Table("CityType", Schema = "app" )]
    [Serializable]
    public partial class CityTypeVo
    {
    		
    	[DisplayName("City")]
    	[Key]
        public int cityTypeId { get; set; }
    		
    	[DisplayName("Name")]
    	[StringLength(50)]
        public string name { get; set; }

        [DisplayName("State")]
        public int stateTypeId { get; set; }

        [DisplayName("Country")]
        public int countryTypeId { get; set; }

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

        [ForeignKey("stateTypeId")]
        public virtual StateTypeVo stateType { get; set; }

        [ForeignKey("countryTypeId")]
        public virtual CountryTypeVo countryType { get; set; }

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
