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
    public partial class PropertyVo
    {
        [DisplayName("Property")]
    	[Key]
        public System.Guid propertyId { get; set; }
        
        [DisplayName("Title")]
        [StringLength(50)]
        public string title { get; set; }

        [DisplayName("Description")]
        [StringLength(250)]
        public string description { get; set; }

    	[DisplayName("Type")]
        public int? propertyTypeId { get; set; }

        [DisplayName("Listing Type")]
        public int? propertyListingTypeId { get; set; }

        [DisplayName("Status Type")]
        public int? statusTypeId { get; set; }
    		
    	[DisplayName("Site")]
        public int? siteId { get; set; }
    		
    	[DisplayName("Bed")]
        public int? bedrooms { get; set; }
    		
    	[DisplayName("Bath")]
        public int? bathrooms { get; set; }
    		
    	[DisplayName("Price")]
        public decimal? price { get; set; }

        [DisplayName("Lot Size")]
        public int? size { get; set; }

        [DisplayName("Section8")]
        public bool? acceptsSection8 { get; set; }

        [DisplayName("Pet")]
        public bool? isPetAllowed { get; set; }

        [DisplayName("Address")]
        [StringLength(50)]
        public string address { get; set; }

        [DisplayName("Phone")]
        [StringLength(15)]
        public string phone { get; set; }

        [DisplayName("City")]
        public int? cityTypeId { get; set; }

        [DisplayName("State")]
        public int? stateTypeId { get; set; }

        [DisplayName("Country")]
        public int? countryTypeId { get; set; }

        [DisplayName("Zip")]
        public int? zip { get; set; }

        [DisplayName("Fax")]
        [StringLength(50)]
        public string fax { get; set; }

        [DisplayName("Start Date")]
        [Required]
        public System.DateTime startDate { get; set; }

        [DisplayName("End Date")]
        [Required]
        public System.DateTime endDate { get; set; }

        [DisplayName("Approved")]
        public bool isApproved { get; set; }
    		
    	[DisplayName("Modified By")]
        public int? modifiedBy { get; set; }
    		
    	[DisplayName("Modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("Created By")]
        public int? createdBy { get; set; }
    		
    	[DisplayName("Created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("Active")]
    	[Required]
        public bool isActive { get; set; }

        [ForeignKey("propertyListingTypeId")]
        public virtual PropertyListingTypeVo propertyListingType { get; set; }

        [ForeignKey("statusTypeId")]
        public virtual StatusTypeVo statusType { get; set; }

        [ForeignKey("propertyTypeId")]
        public virtual PropertyTypeVo propertyType { get; set; }

        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

        [ForeignKey("countryTypeId")]
        public virtual CountryTypeVo countryType { get; set; }

        [ForeignKey("stateTypeId")]
        public virtual StateTypeVo stateType { get; set; }

        [ForeignKey("cityTypeId")]
        public virtual CityTypeVo cityType { get; set; } 

        [ForeignKey("createdBy")]
        public virtual MemberVo member { get; set; }  

        [Association("Property_PropertyImages", "propertyId", "propertyId", IsForeignKey = true)]
        public List<PropertyImageVo> propertyImage { get; set; }

    	public PropertyVo()
        {
    		this.propertyId = Guid.NewGuid();
    	    this.isActive = true;
            this.isApproved = false;
    	}
    }
}
