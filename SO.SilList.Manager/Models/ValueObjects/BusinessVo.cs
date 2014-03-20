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
    [Table("Business", Schema = "data" )]
    [Serializable]
    public  class BusinessVo
    {
    
          
    	[DisplayName("business Id")]
    	[Required]
    	[Key]
        public Guid businessId { get; set; }
    
    	[DisplayName("name")]
    	[Required]
    	[StringLength(250)]
        public string name { get; set; }
    
    	[DisplayName("summary")]
        public string summary { get; set; }
    
    	[DisplayName("description")]
        public string description { get; set; }
    
    	[DisplayName("address")]
        public string address { get; set; }
    
    	[DisplayName("city Type Id")]
        public Nullable<int> cityTypeId { get; set; }
    
    	[DisplayName("state Type Id")]
        public Nullable<int> stateTypeId { get; set; }
    
    	[DisplayName("country Type Id")]
        public Nullable<int> countryTypeId { get; set; }
    
    	[DisplayName("zip")]
        public Nullable<int> zip { get; set; }
    
    	[DisplayName("phone")]
    	[StringLength(50)]
        public string phone { get; set; }
    
    	[DisplayName("fax")]
    	[StringLength(50)]
        public string fax { get; set; }
    
    	[DisplayName("url")]
    	[StringLength(50)]
        public string url { get; set; }
    
    	[DisplayName("start Date")]
    	[Required]
        public DateTime startDate { get; set; }
    
    	[DisplayName("end Date")]
    	[Required]
        public DateTime endDate { get; set; }
    
    	[DisplayName("listing Status Type Id")]
        public Nullable<int> listingStatusTypeId { get; set; }
    
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    
    
        [ForeignKey("cityTypeId")]
        public CityTypeVo cityType { get; set; }
       
        [ForeignKey("countryTypeId")]
        public CountryTypeVo countryType { get; set; }
       
        [ForeignKey("listingStatusTypeId")]
        public ListingStatusTypeVo listingStatusType { get; set; }
       
        [ForeignKey("stateTypeId")]
        public StateTypeVo stateType { get; set; }
       
        [Association("Business_BusinessCategoryLookup", "businessId", "businessId")]
        public List<BusinessCategoryLookupVo> businessCategoryLookupses { get; set; }
       
        [Association("Business_BusinessServiceLookup", "businessId", "businessId")]
        public List<BusinessServiceLookupVo> businessServiceLookupses { get; set; }
       
      public BusinessVo()
            {
    				this.businessId = Guid.NewGuid();
    				this.isActive = true;
            }
    
    }
    
}
