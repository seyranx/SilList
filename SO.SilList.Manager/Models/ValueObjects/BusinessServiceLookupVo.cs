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
    [Table("BusinessServiceLookup", Schema = "data" )]
    [Serializable]
    public  class BusinessServiceLookupVo
    {
    
          
    	[DisplayName("business Service Lookup Id")]
    	[Required]
    	[Key]
        public Guid businessServiceLookupId { get; set; }
    
    	[DisplayName("service Type Id")]
        public Nullable<int> serviceTypeId { get; set; }
    
    	[DisplayName("business Id")]
        public Nullable<Guid> businessId { get; set; }
    
    	[DisplayName("created")]
        public Nullable<DateTime> created { get; set; }
    
    	[DisplayName("modified")]
        public Nullable<DateTime> modified { get; set; }
    
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    
    
        [ForeignKey("businessServiceTypeId")]
        public BusinessServiceTypeVo businessServiceType { get; set; }
       
        [ForeignKey("businessId")]
        public BusinessVo business { get; set; }
       
      public BusinessServiceLookupVo()
            {
    				this.businessServiceLookupId = Guid.NewGuid();
    				this.isActive = true;
            }
    
    }
    
}
