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
    [Table("JobCategoryLookup", Schema = "data" )]
    [Serializable]
    public  class JobCategoryLookupVo
    {
    
          
    	[DisplayName("job Category Lookup Id")]
    	[Required]
    	[Key]
        public Guid jobCategoryLookupId { get; set; }
    
    	[DisplayName("job Id")]
        public Nullable<Guid> jobId { get; set; }
    
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
    
    	[DisplayName("job Category Type Id")]
        public Nullable<int> jobCategoryTypeId { get; set; }
    
    
        [ForeignKey("jobCategoryTypeId")]
        public JobCategoryTypeVo jobCategoryType { get; set; }
       
        [ForeignKey("jobId")]
        public JobVo job { get; set; }
       
      public JobCategoryLookupVo()
            {
    				this.jobCategoryLookupId = Guid.NewGuid();
    				this.isActive = true;
            }
    
    }
    
}
