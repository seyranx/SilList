
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
     
    [Table("Member", Schema = "data" )]
    [Serializable]
    public partial class MemberVo
    {

    	[DisplayName("member Id")]
    	[Required]
        [Key]
        public int memberId { get; set; }
    		
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    		
    	[DisplayName("first Name")]
    	[StringLength(50)]
        public string firstName { get; set; }
    		
    	[DisplayName("last Name")]
    	[StringLength(50)]
        public string lastName { get; set; }
    		
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
    	[StringLength(50)]
        public string zip { get; set; }
    		
    	[DisplayName("email")]
    	[StringLength(50)]
        public string email { get; set; }
    		
    	[DisplayName("username")]
    	[StringLength(50)]
        public string username { get; set; }
    		
    	[DisplayName("password")]
    	[StringLength(50)]
        public string password { get; set; }
    		
    	[DisplayName("phone")]
    	[StringLength(50)]
        public string phone { get; set; }
    		
    	[DisplayName("is Email Confirmed")]
        public Nullable<bool> isEmailConfirmed { get; set; }
    		
    	[DisplayName("ip Address")]
    	[StringLength(50)]
        public string ipAddress { get; set; }
    		
    	[DisplayName("last Login")]
    	[Required]
        public System.DateTime lastLogin { get; set; }
    		
    	[DisplayName("is Email Subscribed")]
        public Nullable<bool> isEmailSubscribed { get; set; }
    		
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

        //[ForeignKey("siteId")]
        //public virtual SiteVo site { get; set; }

    	public MemberVo(){
           this.memberId = 1; // todo: need to generate next unique non-existent value
           this.isActive = true;
    	}
    }
}
