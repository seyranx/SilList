
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
     
    [Table("Business", Schema = "dbo" )]
    [Serializable]
    public partial class BusinessVo
    {
    		
    	[DisplayName("business Id")]
    	[Required]
        public System.Guid businessId { get; set; }
    		
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    		
    	[DisplayName("name")]
    	[StringLength(250)]
        public string name { get; set; }
    		
    	[DisplayName("address")]
    	[StringLength(250)]
        public string address { get; set; }
    		
    	[DisplayName("city")]
    	[StringLength(250)]
        public string city { get; set; }
    		
    	[DisplayName("state")]
    	[StringLength(50)]
        public string state { get; set; }
    		
    	[DisplayName("zip")]
        public Nullable<int> zip { get; set; }
    		
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }

    


    }
}
