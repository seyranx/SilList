
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
     
    [Table("Rental", Schema = "data" )]
    [Serializable]
    public partial class RentalVo
    {
    		
    	[DisplayName("rental Id")]
    	[Key]
        public System.Guid rentalId { get; set; }
    		
    	[DisplayName("property Type Id")]
        public Nullable<int> propertyTypeId { get; set; }
    		
    	[DisplayName("listing Detail Id")]
        public Nullable<System.Guid> listingDetailId { get; set; }
    		
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    		
    	[DisplayName("bedrooms")]
        public Nullable<int> bedrooms { get; set; }
    		
    	[DisplayName("bathrooms")]
        public Nullable<int> bathrooms { get; set; }
    		
    	[DisplayName("rent")]
        public Nullable<double> rent { get; set; }
    		
    	[DisplayName("lease Term Type Id")]
        public Nullable<int> leaseTermTypeId { get; set; }
    		
    	[DisplayName("size")]
        public Nullable<int> size { get; set; }
    		
    	[DisplayName("lot Size")]
        public Nullable<int> lotSize { get; set; }
    		
    	[DisplayName("accepts Section8")]
        public Nullable<bool> acceptsSection8 { get; set; }
    		
    	[DisplayName("rent Type Id")]
        public Nullable<int> rentTypeId { get; set; }
    		
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }

       // [ForeignKey("leaseTermTypeId")]
      //  public virtual LeaseTermTypeVo leaseTermType { get; set; }

       // [ForeignKey("rentTypeId")]
       // public virtual RentTypeVo rentType { get; set; }

       // [ForeignKey("propertyTypeId")]
       // public virtual PropertyTypeVo propertyType { get; set; }

       // [ForeignKey("listingDetailId")]
       // public virtual ListingDetailVo listingDetail { get; set; }

       // [ForeignKey("siteId")]
       // public virtual SiteVo site { get; set; }

    	public RentalVo(){
    			
    		this.rentalId = Guid.NewGuid();
    	    this.isActive = true;
    	}
    }
}
