
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
     
    [Table("BusinessServices", Schema = "data" )]
    [Serializable]
    public partial class BusinessServicesVo
    {
    		
    	[DisplayName("service Type Id")]
    	[Key]
        public int serviceTypeId { get; set; }
    		
    	[DisplayName("business Id")]
        public Nullable<System.Guid> businessId { get; set; }
    		
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

        //[ForeignKey("businessId")]
        // public virtual BusinessVo business { get; set; }

        //[ForeignKey("serviceId")]
        // public virtual ServiceVo service { get; set; }

    	public BusinessServicesVo(){
    			
    	
    	 this.isActive = true;
    	}
    }
}
