
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
     
    [Table("Job", Schema = "data" )]
    [Serializable]
    public partial class JobVo
    {
    		
    	[DisplayName("Job Id")]
    	[Key]
        public System.Guid jobId { get; set; }
    		
    		
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    		
    	[DisplayName("Title")]
    	[StringLength(50)]
        public string title { get; set; }
    		
    	[DisplayName("Description")]
    	[StringLength(50)]
        public string description { get; set; }
    		
    	[DisplayName("Job Type")]
        public Nullable<int> jobTypeId { get; set; }

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
    		
    	[DisplayName("Travel Required")]
        public Nullable<bool> isTravelRequired { get; set; }
    		
    	[DisplayName("Telecomute")]
        public Nullable<bool> isTelecomute { get; set; }
    		
    	[DisplayName("Company Id")]
        public Nullable<System.Guid> jobCompanyId { get; set; }

        [DisplayName("start Date")]
        [Required]
        public System.DateTime startDate { get; set; }

        [DisplayName("end Date")]
        [Required]
        public System.DateTime endDate { get; set; }

        [DisplayName("is Approved")]
        public bool? isApproved { get; set; }
    		
        [DisplayName("Entry Status Type")]
        public Nullable<int> entryStatusTypeId { get; set; }

        public Nullable<System.DateTime> created { get; set; }
    		
    	[DisplayName("Modified")]
        public Nullable<System.DateTime> modified { get; set; }
    		
    	[DisplayName("Created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("Modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("is Active")]
        public bool isActive { get; set; }

        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

       // [ForeignKey("listingDetailId")]
       // public virtual ListingDetailVo listingDetails { get; set; }
        //[ForeignKey("listingDetailId")]
        //public virtual ListingDetailVo listingDetails { get; set; }

        [ForeignKey("jobTypeId")]
        public virtual JobTypeVo jobTypes { get; set; }

        [ForeignKey("jobCompanyId")]
        public virtual JobCompanyVo jobCompany { get; set; }

        [ForeignKey("countryTypeId")]
        public virtual CountryTypeVo countryType { get; set; }

        [ForeignKey("stateTypeId")]
        public virtual StateTypeVo stateType { get; set; }

        [ForeignKey("cityTypeId")]
        public virtual CityTypeVo cityType { get; set; }

        [Association("JobCategories_Job", "jobId", "jobId", IsForeignKey = true)]
        public List<JobCategoriesVo> jobCategories { get; set; }

        [ForeignKey("entryStatusTypeId")]
        public virtual EntryStatusTypeVo entryStatusType { get; set; }

        public JobVo()
        {
    			
    		this.jobId = Guid.NewGuid();
            this.isApproved = false;
    	    this.isActive = true;
    	}

       // public string name { get; set; }

       // public string address { get; set; }
    }
}
