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
    public  class StateTypeVo
    {
    
          
    	[DisplayName("state Type Id")]
    	[Required]
    	[Key]
        public int stateTypeId { get; set; }
    
    	[DisplayName("state Code")]
    	[Required]
    	[StringLength(2)]
        public string stateCode { get; set; }
    
    	[DisplayName("country Type Id")]
    	[Required]
        public int countryTypeId { get; set; }
    
    	[DisplayName("name")]
    	[StringLength(50)]
        public string name { get; set; }
    
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    
    
        [Association("StateType_CityType", "stateTypeId", "stateTypeId")]
        public List<CityTypeVo> cityTypeses { get; set; }
       
        [ForeignKey("countryTypeId")]
        public CountryTypeVo countryType { get; set; }
       
        [Association("StateType_Business", "stateTypeId", "stateTypeId")]
        public List<BusinessVo> businesseses { get; set; }
       
        [Association("StateType_Car", "stateTypeId", "stateTypeId")]
        public List<CarVo> carses { get; set; }
       
        [Association("StateType_Job", "stateTypeId", "stateTypeId")]
        public List<JobVo> jobses { get; set; }
       
        [Association("StateType_Listing", "stateTypeId", "stateTypeId")]
        public List<ListingVo> listingses { get; set; }
       
        [Association("StateType_Member", "stateTypeId", "stateTypeId")]
        public List<MemberVo> memberses { get; set; }
       
        [Association("StateType_Property", "stateTypeId", "stateTypeId")]
        public List<PropertyVo> propertieses { get; set; }
       
      public StateTypeVo()
            {
    				this.isActive = true;
            }
    
    }
    
}
