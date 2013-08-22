
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
    		
    	[DisplayName("City")]
    	[StringLength(10)]
        public string city { get; set; }
    		
    	[DisplayName("State")]
    	[StringLength(10)]
        public string state { get; set; }
    		
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
        public bool isApproved { get; set; }
    		
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

        [Association("JobCategories_Job", "jobId", "jobId", IsForeignKey = true)]
        public List<JobCategoriesVo> jobCategories { get; set; }
      
    	public JobVo(){
    			
    		this.jobId = Guid.NewGuid();
            this.isApproved = false;
    	    this.isActive = true;
    	}

       // public string name { get; set; }

       // public string address { get; set; }
    }
}
