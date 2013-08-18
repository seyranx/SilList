
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
     
    [Table("JobCategories", Schema = "data" )]
    [Serializable]
    public partial class JobCategoriesVo
    {
    		
    	[DisplayName("Job Category Type Id")]
    	[Key]
        public Guid jobCategoriesId { get; set; }
    		
    	[DisplayName("Job Id")]
        public Nullable<System.Guid> jobId { get; set; }
    		
    	[DisplayName("Created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("Modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("Created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("is Active")]
        public bool isActive { get; set; }

        //[ForeignKey("JobId")]
        //public virtual JobVo jobs { get; set; }

        //[ForeignKey("JobId")]
        //public virtual JobCategoriesVo jobcategories { get; set; }

        public JobCategoriesVo(){
    			
    	
    	 this.isActive = true;
    	}
    }
}
