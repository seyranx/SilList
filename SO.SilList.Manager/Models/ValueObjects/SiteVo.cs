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

namespace SO.SilList.Manager.Models.ValueObjects
{
     
    [Table("Site", Schema = "app" )]
    [Serializable]
    public partial class SiteVo
    {
    		
    	[DisplayName("site Id")]
    	[Key]
        public int siteId { get; set; }
    		
    	[DisplayName("name")]
    	[StringLength(250)]
        public string name { get; set; }
    		
    	[DisplayName("domain")]
    	[StringLength(250)]
        public string domain { get; set; }

        [Association("Site_Business", "siteId", "siteId", IsForeignKey = true)]
        public List<BusinessVo> businesses { get; set; }
    }
}
