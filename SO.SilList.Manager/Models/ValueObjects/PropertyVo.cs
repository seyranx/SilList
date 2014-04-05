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
    
          
    	[DisplayName("Property Id")]
    	[Required]
    	[Key]
        public Guid propertyId { get; set; }
    
    	[DisplayName("Title")]
    	[Required]
    	[StringLength(50)]
        public string title { get; set; }
    
    	[DisplayName("Description")]
        public string description { get; set; }
    
    	[DisplayName("Property Type Id")]
        public Nullable<int> propertyTypeId { get; set; }
    
    	[DisplayName("Property Listing Type Id")]
        public Nullable<int> propertyListingTypeId { get; set; }
    
    	[DisplayName("Room Count")]
        public Nullable<int> roomCount { get; set; }
    
    	[DisplayName("Bathroom Count")]
        public Nullable<int> bathroomCount { get; set; }
    
    	[DisplayName("Price")]
        public Nullable<decimal> price { get; set; }
    
    	[DisplayName("Size")]
        public Nullable<int> size { get; set; }
    
    	[DisplayName("Lot Size")]
        public Nullable<int> lotSize { get; set; }
    
    	[DisplayName("Has Section8")]
        public Nullable<int> hasSection8 { get; set; }
    
    	[DisplayName("Is Pet Allowed")]
        public Nullable<int> isPetAllowed { get; set; }
    
    	[DisplayName("Address")]
        public string address { get; set; }
    
    	[DisplayName("City Type Id")]
        public Nullable<int> cityTypeId { get; set; }
    
    	[DisplayName("State Type Id")]
        public Nullable<int> stateTypeId { get; set; }
    
    	[DisplayName("Country Type Id")]
        public Nullable<int> countryTypeId { get; set; }
    
    	[DisplayName("zip")]
        public Nullable<int> zip { get; set; }
    
    	[DisplayName("Start Date")]
    	[Required]
        public DateTime startDate { get; set; }
    
    	[DisplayName("End Date")]
    	[Required]
        public DateTime endDate { get; set; }
    
    	[DisplayName("Listing Status Type Id")]
        public Nullable<int> listingStatusTypeId { get; set; }
    
    	[DisplayName("Modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("Modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("Created By")]
        public Nullable<int> createdBy { get; set; }
    
    	[DisplayName("Created")]
    	[Required]
        public DateTime created { get; set; }
    
    	[DisplayName("Is Active")]
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
