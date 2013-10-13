
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

        
        [DisplayName("Title")]
        [StringLength(50)]
        public string title { get; set; }

        [DisplayName("Description")]
        [StringLength(250)]
        public string description { get; set; }

    	[DisplayName("Property Type")]
        public Nullable<int> propertyTypeId { get; set; }
    		
    	[DisplayName("Site Id")]
        public Nullable<int> siteId { get; set; }

        [DisplayName("Member Id")]
        public Nullable<int> memberId { get; set; }
    		
    	[DisplayName("Bedrooms")]
        public Nullable<int> bedrooms { get; set; }
    		
    	[DisplayName("Bathrooms")]
        public Nullable<int> bathrooms { get; set; }
    		
    	[DisplayName("Rent")]
        public Nullable<double> rent { get; set; }

        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("City")]
        public Nullable<int> cityTypeId { get; set; }

        [DisplayName("State")]
        public Nullable<int> stateTypeId { get; set; }

        [DisplayName("Country")]
        public Nullable<int> countryTypeId { get; set; }

        [DisplayName("Zip")]
        public Nullable<int> zip { get; set; }

        [DisplayName("Phone")]
        [StringLength(50)]
        public string phone { get; set; }

        [DisplayName("Fax")]
        [StringLength(50)]
        public string fax { get; set; }

    	[DisplayName("Lease Term")]
        //[ForeignKey("leaseTermTyprId")]
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

        [ForeignKey("rentTypeId")]
        public virtual RentTypeVo rentType { get; set; }

        [ForeignKey("propertyTypeId")]
        public virtual PropertyTypeVo propertyType { get; set; }

        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

        [ForeignKey("memberId")]
        public virtual MemberVo member { get; set; }

        [ForeignKey("countryTypeId")]
        public virtual CountryTypeVo countryType { get; set; }

        [ForeignKey("stateTypeId")]
        public virtual StateTypeVo stateType { get; set; }

        [ForeignKey("cityTypeId")]
        public virtual CityTypeVo cityType { get; set; }

        [Association("Rental_RentalImages", "rentalId", "rentalId", IsForeignKey = true)]
        public List<RentalImageVo> rentalImage { get; set; }

    	public RentalVo(){
    			
    		this.rentalId = Guid.NewGuid();
    	    this.isActive = true;
            this.isApproved = false;
    	}
    }
}
