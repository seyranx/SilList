
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
    		
    	[DisplayName("Job")]
    	[Key]
        public System.Guid jobId { get; set; }
    		
    		
    	[DisplayName("Site")]
        public Nullable<int> siteId { get; set; }
    		
    	[DisplayName("Title")]
    	[StringLength(50)]
        [Required]
        public string title { get; set; }
    		
    	[DisplayName("Description")]
        public string description { get; set; }
    		
    	[DisplayName("Type")]
        public int? jobTypeId { get; set; }

        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("City")]
        [Required]
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

        [DisplayName("E-mail")]
        [StringLength(50)]
        public string email { get; set; }

        [DisplayName("Website")]
        [StringLength(50)]
        public string website { get; set; }

        [DisplayName("Company")]
        [StringLength(50)]
        [Required]
        public string companyName { get; set; }

        [DisplayName("Contact Person")]
        [StringLength(50)]
        public string contactName { get; set; }

    	[DisplayName("Travel Required")]
        public bool isTravelRequired { get; set; }
    		
    	[DisplayName("Telecomute")]
        public bool isTelecomute { get; set; }
    		

        [DisplayName("Start Date")]
        [Required]
        public System.DateTime startDate { get; set; }

        [DisplayName("End Date")]
        [Required]
        public System.DateTime endDate { get; set; }

        [DisplayName("Approved")]
        public bool isApproved { get; set; }
    		
        [DisplayName("Entry Status Type")]
        public Nullable<int> entryStatusTypeId { get; set; }

        public Nullable<System.DateTime> created { get; set; }
    		
    	[DisplayName("Modified")]
        public Nullable<System.DateTime> modified { get; set; }
    		
    	[DisplayName("Created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("Modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("Active")]
        public bool isActive { get; set; }

        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

        [ForeignKey("jobTypeId")]
        public virtual JobTypeVo jobType { get; set; }

        [ForeignKey("countryTypeId")]
        public virtual CountryTypeVo countryType { get; set; }

        [ForeignKey("stateTypeId")]
        public virtual StateTypeVo stateType { get; set; }

        [ForeignKey("cityTypeId")]
        public virtual CityTypeVo cityType { get; set; }

        [DisplayName("Job Categories")]
        [Association("JobCategories_Job", "jobId", "jobId", IsForeignKey = true)]
        public List<JobCategoriesVo> jobCategories { get; set; }

        [ForeignKey("entryStatusTypeId")]
        public virtual EntryStatusTypeVo entryStatusType { get; set; }

        [NotMapped]
        [DisplayName("Categories")]
        public List<int> jobCategoryType { get; set; }
        
        public JobVo()
        {
    			
    		this.jobId = Guid.NewGuid();
            this.isApproved = false;
    	    this.isActive = true;
    	}
    }
}
