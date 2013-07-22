
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
    		
    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("is Active")]
        public Nullable<bool> isActive { get; set; }
      
    	public BusinessCategoryVo(){
    			
    		this.businessId = Guid.NewGuid();
    	
    	 //this.isActive = true;
    	}
    }
}
