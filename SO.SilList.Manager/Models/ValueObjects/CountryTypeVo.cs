
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
     
    [Table("CountryType", Schema = "app" )]
    [Serializable]
    public partial class CountryTypeVo
    {
    		
    	[DisplayName("Country")]
    	[Key]
        public int countryTypeId { get; set; }
    		
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

        [Association("CountryType_CityType", "countryTypeId", "countryTypeId", IsForeignKey = true)]
        public List<CityTypeVo> city { get; set; }

        [Association("CountryType_StateType", "countryTypeId", "countryTypeId", IsForeignKey = true)]
        public List<StateTypeVo> state { get; set; }

        [Association("CountryType_Car", "countryTypeId", "countryTypeId", IsForeignKey = true)]
        public List<CarVo> car { get; set; }

        [Association("CountryType_Job", "countryTypeId", "countryTypeId", IsForeignKey = true)]
        public List<JobVo> job { get; set; }

        [Association("CountryType_Business", "countryTypeId", "countryTypeId", IsForeignKey = true)]
        public List<BusinessVo> business { get; set; }

        [Association("CountryType_Listing", "countryTypeId", "countryTypeId", IsForeignKey = true)]
        public List<ListingVo> listing { get; set; }

        [Association("CountryType_Rental", "countryTypeId", "countryTypeId", IsForeignKey = true)]
        public List<RentalVo> rental { get; set; }

        [Association("CountryType_Member", "countryTypeId", "countryTypeId", IsForeignKey = true)]
        public List<MemberVo> member { get; set; }

    	public CountryTypeVo(){
            this.isActive = true;
 
    	}
    }
}
