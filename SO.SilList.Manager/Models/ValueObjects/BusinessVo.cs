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

        //[DisplayName("listingDetail Id")]
        //public System.Guid? listingDetailId { get; set; }

        [DisplayName("Site Id")]
        public Nullable<int> siteId { get; set; }

        [DisplayName("Name")]
        [StringLength(250)]
        public string name { get; set; }

        [DisplayName("Address")]
        [StringLength(250)]
        public string address { get; set; }

        [DisplayName("City")]
        [StringLength(250)]
        public string city { get; set; }

        [DisplayName("State")]
        [StringLength(50)]
        public string state { get; set; }

        [DisplayName("Zip")]
        public Nullable<int> zip { get; set; }

        [DisplayName("start Date")]
        [Required]
        public System.DateTime startDate { get; set; }

        [DisplayName("end Date")]
        [Required]
        public System.DateTime endDate { get; set; }

        [DisplayName("is Approved")]
        public bool isApproved { get; set; }

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


        //[Association("Business_BusinessCategories", "businessId", "businessId", IsForeignKey = true)]
        //public List<BusinessCategories> businessCategories { get; set; }

       
        [DisplayName("Site")]
        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

        //[ForeignKey("listingDetailId")]
        //public virtual ListingDetailVo listingdetail { get; set; }
        
        //[Association("Business_BusinessRatings", "businessId", "businessId", IsForeignKey = true)]
        //public List<BusinessRatingsVo> businessRatings { get; set; }

        //[Association("Business_BusinessCategories", "businessId", "businessId", IsForeignKey = true)]
        //public List<BusinessCategoriesVo> businessCategories { get; set; }

        public BusinessVo()
        {
    		this.businessId = Guid.NewGuid();
    	    this.isActive = true;
            this.isApproved = false;
    	 }

    }
}
