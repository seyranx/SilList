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
    [Table("Listing", Schema = "data" )]
    [Serializable]
    public  class ListingVo
    {
    
          
    	[DisplayName("listing Id")]
    	[Required]
    	[Key]
        public Guid listingId { get; set; }
    
    	[DisplayName("title")]
    	[StringLength(50)]
        public string title { get; set; }
    
    	[DisplayName("description")]
        public string description { get; set; }
    
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    
    	[DisplayName("listing Type Id")]
        public Nullable<int> listingTypeId { get; set; }
    
    	[DisplayName("price")]
        public Nullable<decimal> price { get; set; }
    
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
    
    	[DisplayName("start Date")]
    	[Required]
        public DateTime startDate { get; set; }
    
    	[DisplayName("end Date")]
    	[Required]
        public DateTime endDate { get; set; }
    
    	[DisplayName("entry Status Type Id")]
        public Nullable<int> entryStatusTypeId { get; set; }
    
    	[DisplayName("created By_")]
        public Nullable<int> createdBy_ { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    
    
        [ForeignKey("cityTypeId")]
        public CityTypeVo cityType { get; set; }
       
        [ForeignKey("countryTypeId")]
        public CountryTypeVo countryType { get; set; }
       
        [ForeignKey("listingStatusTypeId")]
        public ListingStatusTypeVo listingStatusType { get; set; }
       
        [ForeignKey("listingTypeId")]
        public ListingTypeVo listingType { get; set; }
       
        [ForeignKey("stateTypeId")]
        public StateTypeVo stateType { get; set; }
       
        [Association("Listing_ListingCategoryLookup", "listingId", "listingId")]
        public List<ListingCategoryLookupVo> listingCategoryLookupses { get; set; }
       
      public ListingVo()
            {
    				this.listingId = Guid.NewGuid();
    				this.isActive = true;
            }
    
    }
    
}
