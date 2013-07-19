
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
     
    [Table("BusinessCategory", Schema = "dbo" )]
    [Serializable]
    public partial class BusinessCategoryVo
    {
    		
    	[DisplayName("business Id")]
    	[Required]
        public System.Guid businessId { get; set; }
    		
    	[DisplayName("business Category Type Id")]
    	[Required]
        public int businessCategoryTypeId { get; set; }
    }
}
