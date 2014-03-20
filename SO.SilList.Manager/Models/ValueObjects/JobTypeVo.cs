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
    [Table("JobType", Schema = "app" )]
    [Serializable]
    public  class JobTypeVo
    {
    
          
    	[DisplayName("job Type Id")]
    	[Required]
    	[Key]
        public int jobTypeId { get; set; }
    
    	[DisplayName("name")]
    	[StringLength(50)]
        public string name { get; set; }
    
    	[DisplayName("description")]
        public string description { get; set; }
    
    	[DisplayName("created")]
        public Nullable<DateTime> created { get; set; }
    
    	[DisplayName("modified")]
        public Nullable<DateTime> modified { get; set; }
    
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    
    
        [Association("JobType_Job", "jobTypeId", "jobTypeId")]
        public List<JobVo> jobses { get; set; }
       
      public JobTypeVo()
            {
    				this.isActive = true;
            }
    
    }
    
}
