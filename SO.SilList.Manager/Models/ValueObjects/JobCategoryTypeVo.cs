
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
     
    [Table("JobCategoryType", Schema = "app" )]
    [Serializable]
    public partial class JobCategoryTypeVo
    {
    		
    	[DisplayName("Job Category Type")]
    	[Key]
        public int jobCategoryTypeId { get; set; }
    		
    	[DisplayName("Name")]
    	[StringLength(50)]
        public string name { get; set; }
    		
    	[DisplayName("Description")]
        public string description { get; set; }
    		
    	[DisplayName("Created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("Modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("Created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("Modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("Active")]
        public bool isActive { get; set; }

        [Association("JobCategoryType_JobCategories", "jobCategoryTypeId", "jobCategoryTypeId", IsForeignKey = true)]
        public List<JobCategoriesVo> jobCategories { get; set; }
      
    	public JobCategoryTypeVo(){

    	 this.isActive = true;
    	}
    }
}
