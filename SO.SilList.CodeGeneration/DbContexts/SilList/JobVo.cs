
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SO.SilList.CodeGeneration.DbContexts.SilList
{
     
    [Table("Job", Schema = "dbo" )]
    [Serializable]
    public partial class JobVo
    {
    		
    	[DisplayName("Id")]
    	[Required]
        public int Id { get; set; }
    		
    	[DisplayName("job Id")]
        public Nullable<System.Guid> jobId { get; set; }
    		
    	[DisplayName("listing Detail Id")]
        public Nullable<System.Guid> listingDetailId { get; set; }
    		
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    		
    	[DisplayName("title")]
    	[StringLength(50)]
        public string title { get; set; }
    		
    	[DisplayName("description")]
    	[StringLength(50)]
        public string description { get; set; }
    		
    	[DisplayName("job Type Id")]
        public Nullable<int> jobTypeId { get; set; }
    		
    	[DisplayName("city")]
    	[StringLength(10)]
        public string city { get; set; }
    		
    	[DisplayName("state")]
    	[StringLength(10)]
        public string state { get; set; }
    		
    	[DisplayName("is Travel Required")]
        public Nullable<bool> isTravelRequired { get; set; }
    		
    	[DisplayName("is Telecomute")]
        public Nullable<bool> isTelecomute { get; set; }
    		
    	[DisplayName("job Company Id")]
        public Nullable<System.Guid> jobCompanyId { get; set; }
    		
    	[DisplayName("created")]
        public Nullable<System.DateTime> created { get; set; }
    		
    	[DisplayName("modified")]
        public Nullable<System.DateTime> modified { get; set; }
    		
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("is Active")]
        public Nullable<bool> isActive { get; set; }
    }
}
