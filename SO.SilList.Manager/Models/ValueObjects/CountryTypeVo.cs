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
    public  class CountryTypeVo
    {
    
          
    	[DisplayName("country Type Id")]
    	[Required]
    	[Key]
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
    
    
        [Association("CountryType_CityType", "countryTypeId", "countryTypeId")]
        public List<CityTypeVo> cityTypeses { get; set; }
       
        [Association("CountryType_Business", "countryTypeId", "countryTypeId")]
        public List<BusinessVo> businesseses { get; set; }
       
        [Association("CountryType_Car", "countryTypeId", "countryTypeId")]
        public List<CarVo> carses { get; set; }
       
        [Association("CountryType_Job", "countryTypeId", "countryTypeId")]
        public List<JobVo> jobses { get; set; }
       
        [Association("CountryType_Listing", "countryTypeId", "countryTypeId")]
        public List<ListingVo> listingses { get; set; }
       
        [Association("CountryType_Member", "countryTypeId", "countryTypeId")]
        public List<MemberVo> memberses { get; set; }
       
        [Association("CountryType_Property", "countryTypeId", "countryTypeId")]
        public List<PropertyVo> propertieses { get; set; }
       
        [Association("CountryType_StateType", "countryTypeId", "countryTypeId")]
        public List<StateTypeVo> stateTypeses { get; set; }
       
      public CountryTypeVo()
            {
    				this.isActive = true;
            }
    
    }
    
}
