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

        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("City")]
        public Nullable<int> cityTypeId { get; set; }

        [DisplayName("State")]
        public Nullable<int> stateTypeId { get; set; }

        [DisplayName("Country")]
        public Nullable<int> countryTypeId { get; set; }

        [DisplayName("Zip")]
        public Nullable<int> zip { get; set; }

        [DisplayName("Phone")]
        [StringLength(50)]
        public string phone { get; set; }

        [DisplayName("Fax")]
        [StringLength(50)]
        public string fax { get; set; }
    		
    	[DisplayName("email")]
    	[StringLength(50)]
        public string email { get; set; }
    		
    	[DisplayName("username")]
    	[StringLength(50)]
        public string username { get; set; }
    		
    	[DisplayName("password")]
    	[StringLength(50)]
        public string password { get; set; }
    		
    	[DisplayName("is Email Confirmed")]
        public Nullable<bool> isEmailConfirmed { get; set; }
    		
    	[DisplayName("ip Address")]
    	[StringLength(50)]
        public string ipAddress { get; set; }
    		
    	[DisplayName("last Login")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
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
        [Required]
        public bool isActive { get; set; }

        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

        [ForeignKey("countryTypeId")]
        public virtual CountryTypeVo countryType { get; set; }

        [ForeignKey("stateTypeId")]
        public virtual StateTypeVo stateType { get; set; }

        [ForeignKey("cityTypeId")]
        public virtual CityTypeVo cityType { get; set; }

        [Association("Member_Rental", "memberId", "memberId", IsForeignKey = true)]
        public List<RentalVo> rentalImage { get; set; }


    	public MemberVo(){
            this.lastLogin = DateTime.MinValue;
            this.isActive = true;
    	}
    }
}
