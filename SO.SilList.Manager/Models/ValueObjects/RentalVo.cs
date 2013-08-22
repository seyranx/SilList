
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
    		
    	[DisplayName("Rental")]
    	[Key]
        public System.Guid rentalId { get; set; }
    		
    	[DisplayName("Property Type")]
        public Nullable<int> propertyTypeId { get; set; }
    		
    	//[DisplayName("listing Detail Id")]
        //public Nullable<System.Guid> listingDetailId { get; set; }
    		
    	[DisplayName("Site Id")]
        public Nullable<int> siteId { get; set; }
    		
    	[DisplayName("Bedrooms")]
        public Nullable<int> bedrooms { get; set; }
    		
    	[DisplayName("Bathrooms")]
        public Nullable<int> bathrooms { get; set; }
    		
    	[DisplayName("Rent")]
        public Nullable<double> rent { get; set; }
    		
    	[DisplayName("Lease Term")]
        public Nullable<int> leaseTermTypeId { get; set; }
    		
    	[DisplayName("Size")]
        public Nullable<int> size { get; set; }
    		
    	[DisplayName("lot Size")]
        public Nullable<int> lotSize { get; set; }
    		
    	[DisplayName("Accepts Section8")]
        public Nullable<bool> acceptsSection8 { get; set; }
    		
    	[DisplayName("Rent Type")]
        public Nullable<int> rentTypeId { get; set; }

        [DisplayName("Start Date")]
        [Required]
        public System.DateTime startDate { get; set; }

        [DisplayName("End Date")]
        [Required]
        public System.DateTime endDate { get; set; }

        [DisplayName("is Approved")]
        public bool isApproved { get; set; }
    		
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
    		
    	[DisplayName("Is Active")]
    	[Required]
        public bool isActive { get; set; }

        [ForeignKey("leaseTermTypeId")]
        public virtual LeaseTermTypeVo leaseTermType { get; set; }

        //[ForeignKey("rentTypeId")]
        //public virtual RentTypeVo rentType { get; set; }

        //[ForeignKey("propertyTypeId")]
        //public virtual PropertyTypeVo propertyType { get; set; }

        //[ForeignKey("listingDetailId")]
        //public virtual ListingDetailVo listingDetail { get; set; }

        //[ForeignKey("siteId")]
        //public virtual SiteVo site { get; set; }

    	public RentalVo(){
    			
    		this.rentalId = Guid.NewGuid();
    	    this.isActive = true;
            this.isApproved = false;
    	}
    }
}
