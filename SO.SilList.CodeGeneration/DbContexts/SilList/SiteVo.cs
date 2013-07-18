
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
     
    [Table("Site", Schema = "dbo" )]
    [Serializable]
    public partial class SiteVo
    {
    		
    	[DisplayName("site Id")]
    	[Required]
        public int siteId { get; set; }
    		
    	[DisplayName("name")]
    	[StringLength(250)]
        public string name { get; set; }
    		
    	[DisplayName("domain")]
    	[StringLength(250)]
        public string domain { get; set; }
    }
}
