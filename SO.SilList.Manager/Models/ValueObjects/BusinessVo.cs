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
    [Table("Business", Schema = "data")]
    [Serializable]
    public partial class BusinessVo
    {

        [DisplayName("Business Id")]
        [Key]
        public System.Guid businessId { get; set; }

        [DisplayName("Site Id")]
        public Nullable<int> siteId { get; set; }

        [DisplayName("Name")]
        [StringLength(250)]
        public string name { get; set; }

        [DisplayName("Address")]
        [StringLength(250)]
        public string address { get; set; }

        [DisplayName("City")]
        public Nullable<int> cityTypeId { get; set; }

        [DisplayName("State")]
        public Nullable<int> stateTypeId { get; set; }

        [DisplayName("Country")]
        public Nullable<int> countryTypeId { get; set; }

        [DisplayName("Url")]
        [StringLength(50)]
        public string url { get; set; }

        [DisplayName("Zip")]
        public Nullable<int> zip { get; set; }

        [DisplayName("Phone")]
        [StringLength(50)]
        public string phone { get; set; }

        [DisplayName("Fax")]
        [StringLength(50)]
        public string fax { get; set; }

        [DisplayName("start Date")]
        [Required]
        public System.DateTime startDate { get; set; }

        [DisplayName("end Date")]
        [Required]
        public System.DateTime endDate { get; set; }

        [DisplayName("Entry Status Type")]
        public Nullable<int> entryStatusTypeId { get; set; }

        [DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }

        [DisplayName("modified By")]
        public int? modifiedBy { get; set; }

        [DisplayName("modified")]
        [Required]
        public System.DateTime modified { get; set; }

        [DisplayName("Created")]
        [Required]
        public System.DateTime created { get; set; }

        [DisplayName("Is Active")]
        [Required]
        public bool isActive { get; set; }
       
        [DisplayName("Site")]
        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

        [DisplayName("Country")]
        [ForeignKey("countryTypeId")]
        public virtual CountryTypeVo countryType { get; set; }

        [DisplayName("State")]
        [ForeignKey("stateTypeId")]
        public virtual StateTypeVo stateType { get; set; }

        [DisplayName("City")]
        [ForeignKey("cityTypeId")]
        public virtual CityTypeVo cityType { get; set; }

        [Association("Business_BusinessCategories", "businessId", "businessId", IsForeignKey = true)]
        public List<BusinessCategoriesVo> businessCategories { get; set; }
        
        [Association("Business_BusinessRatings", "businessId", "businessId", IsForeignKey = true)]
        public List<BusinessRatingsVo> businessRatings { get; set; }

        [Association("Business_BusinessServices", "businessId", "businessId", IsForeignKey = true)]
        public List<BusinessServicesVo> businessServices { get; set; }

        [Association("Business_BusinessImages", "businessId", "businessId", IsForeignKey = true)]
        public List<BusinessImagesVo> businessImages { get; set; }

        [ForeignKey("entryStatusTypeId")]
        public virtual EntryStatusTypeVo entryStatusType { get; set; }

        public BusinessVo()
        {
    		this.businessId = Guid.NewGuid();
    	    this.isActive = true;
            //this.entryStatusTypeId = 0;
    	 }

    }
}
