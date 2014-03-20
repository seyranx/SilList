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
    public  class JobVo
    {
    
          
    	[DisplayName("job Id")]
    	[Required]
    	[Key]
        public Guid jobId { get; set; }
    
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    
    	[DisplayName("title")]
    	[StringLength(50)]
        public string title { get; set; }
    
    	[DisplayName("description")]
        public string description { get; set; }
    
    	[DisplayName("job Type Id")]
        public Nullable<int> jobTypeId { get; set; }
    
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
    
    	[DisplayName("website")]
    	[StringLength(50)]
        public string website { get; set; }
    
    	[DisplayName("contact Name")]
    	[StringLength(50)]
        public string contactName { get; set; }
    
    	[DisplayName("company Name")]
    	[StringLength(50)]
        public string companyName { get; set; }
    
    	[DisplayName("email")]
    	[StringLength(50)]
        public string email { get; set; }
    
    	[DisplayName("entry Status Type Id")]
        public Nullable<int> entryStatusTypeId { get; set; }
    
    	[DisplayName("start Date")]
    	[Required]
        public DateTime startDate { get; set; }
    
    	[DisplayName("end Date")]
    	[Required]
        public DateTime endDate { get; set; }
    
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    
    	[DisplayName("is Travel Required")]
    	[Required]
        public bool isTravelRequired { get; set; }
    
    	[DisplayName("is Telecomute")]
    	[Required]
        public bool isTelecomute { get; set; }
    
    
        [ForeignKey("cityTypeId")]
        public CityTypeVo cityType { get; set; }
       
        [ForeignKey("countryTypeId")]
        public CountryTypeVo countryType { get; set; }
       
        [ForeignKey("jobTypeId")]
        public JobTypeVo jobType { get; set; }
       
        [ForeignKey("listingStatusTypeId")]
        public ListingStatusTypeVo listingStatusType { get; set; }
       
        [ForeignKey("stateTypeId")]
        public StateTypeVo stateType { get; set; }
       
        [Association("Job_JobCategoryLookup", "jobId", "jobId")]
        public List<JobCategoryLookupVo> jobCategoryLookupses { get; set; }
       
      public JobVo()
            {
    				this.jobId = Guid.NewGuid();
    				this.isActive = true;
            }
    
    }
    
}
