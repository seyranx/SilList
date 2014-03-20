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
    [Table("Property", Schema = "data" )]
    [Serializable]
    public  class PropertyVo
    {
    
          
    	[DisplayName("property Id")]
    	[Required]
    	[Key]
        public Guid propertyId { get; set; }
    
    	[DisplayName("title")]
    	[Required]
    	[StringLength(50)]
        public string title { get; set; }
    
    	[DisplayName("description")]
        public string description { get; set; }
    
    	[DisplayName("property Type Id")]
        public Nullable<int> propertyTypeId { get; set; }
    
    	[DisplayName("property Listing Type Id")]
        public Nullable<int> propertyListingTypeId { get; set; }
    
    	[DisplayName("room Count")]
        public Nullable<int> roomCount { get; set; }
    
    	[DisplayName("bathroom Count")]
        public Nullable<int> bathroomCount { get; set; }
    
    	[DisplayName("price")]
        public Nullable<decimal> price { get; set; }
    
    	[DisplayName("size")]
        public Nullable<int> size { get; set; }
    
    	[DisplayName("lot Size")]
        public Nullable<int> lotSize { get; set; }
    
    	[DisplayName("has Section8")]
        public Nullable<int> hasSection8 { get; set; }
    
    	[DisplayName("is Pet Allowed")]
        public Nullable<int> isPetAllowed { get; set; }
    
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
    
    	[DisplayName("start Date")]
    	[Required]
        public DateTime startDate { get; set; }
    
    	[DisplayName("end Date")]
    	[Required]
        public DateTime endDate { get; set; }
    
    	[DisplayName("listing Status Type Id")]
        public Nullable<int> listingStatusTypeId { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    
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
       
        [ForeignKey("propertyListingTypeId")]
        public PropertyListingTypeVo propertyListingType { get; set; }
       
        [ForeignKey("propertyTypeId")]
        public PropertyTypeVo propertyType { get; set; }
       
        [ForeignKey("stateTypeId")]
        public StateTypeVo stateType { get; set; }
       
      public PropertyVo()
            {
    				this.propertyId = Guid.NewGuid();
    				this.isActive = true;
            }
    
    }
    
}
