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
    public  class CityTypeVo
    {
    
          
    	[DisplayName("city Type Id")]
    	[Required]
    	[Key]
        public int cityTypeId { get; set; }
    
    	[DisplayName("state Type Id")]
    	[Required]
        public int stateTypeId { get; set; }
    
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
    
    
        [Association("CityType_Business", "cityTypeId", "cityTypeId")]
        public List<BusinessVo> businesseses { get; set; }
       
        [Association("CityType_Car", "cityTypeId", "cityTypeId")]
        public List<CarVo> carses { get; set; }
       
        [ForeignKey("countryTypeId")]
        public CountryTypeVo countryType { get; set; }
       
        [ForeignKey("stateTypeId")]
        public StateTypeVo stateType { get; set; }
       
        [Association("CityType_Job", "cityTypeId", "cityTypeId")]
        public List<JobVo> jobses { get; set; }
       
        [Association("CityType_Listing", "cityTypeId", "cityTypeId")]
        public List<ListingVo> listingses { get; set; }
       
        [Association("CityType_Member", "cityTypeId", "cityTypeId")]
        public List<MemberVo> memberses { get; set; }
       
        [Association("CityType_Property", "cityTypeId", "cityTypeId")]
        public List<PropertyVo> propertieses { get; set; }
       
      public CityTypeVo()
            {
    				this.isActive = true;
            }
    
    }
    
}
