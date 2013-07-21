
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
     
    [Table("JobCompany", Schema = "dbo" )]
    [Serializable]
    public partial class JobCompanyVo
    {
    		
    	[DisplayName("job Company Id")]
    	[Required]
        public System.Guid jobCompanyId { get; set; }
    		
    	[DisplayName("name")]
    	[StringLength(50)]
        public string name { get; set; }
    		
    	[DisplayName("address")]
    	[StringLength(50)]
        public string address { get; set; }
    		
    	[DisplayName("city")]
    	[StringLength(50)]
        public string city { get; set; }
    		
    	[DisplayName("state")]
    	[StringLength(50)]
        public string state { get; set; }
    		
    	[DisplayName("zip")]
        public Nullable<int> zip { get; set; }
    		
    	[DisplayName("website")]
    	[StringLength(50)]
        public string website { get; set; }
    		
    	[DisplayName("phone")]
    	[StringLength(50)]
        public string phone { get; set; }
    		
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    		
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
