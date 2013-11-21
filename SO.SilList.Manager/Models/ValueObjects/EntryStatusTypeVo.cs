
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
     
    [Table("EntryStatusType", Schema = "app" )]
    [Serializable]
    public partial class EntryStatusTypeVo
    {
    	[DisplayName("entry Status Type Id")]
        [Key]
        public int entryStatusTypeId { get; set; }
    		
    	[DisplayName("name")]
    	[Required]
    	[StringLength(50)]
        public string name { get; set; }
    		
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
        public Nullable<bool> isActive { get; set; }

        [Association("EntryStatusType_Job", "entryStatusTypeId", "entryStatusTypeId", IsForeignKey = true)]
        public List<JobVo> jobs { get; set; }

        [Association("EntryStatusType_Business", "entryStatusTypeId", "entryStatusTypeId", IsForeignKey = true)]
        public List<BusinessVo> businesses { get; set; }

        [Association("EntryStatusType_Listing", "entryStatusTypeId", "entryStatusTypeId", IsForeignKey = true)]
        public List<ListingVo> listing { get; set; }

        [Association("EntryStatusType_Car", "entryStatusTypeId", "entryStatusTypeId", IsForeignKey = true)]
        public List<CarVo> car { get; set; }
        
        public EntryStatusTypeVo()
        {
            this.isActive = true;
    	}
    }
}
