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
    [Table("Member", Schema = "data")]
    [Serializable]
    public class MemberVo
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
        public string address { get; set; }

        [DisplayName("city Type Id")]
        public Nullable<int> cityTypeId { get; set; }

        [DisplayName("state Type Id")]
        public Nullable<int> stateTypeId { get; set; }

        [DisplayName("Country Type Id")]
        public Nullable<int> countryTypeId { get; set; }

        [DisplayName("zip")]
        public Nullable<int> zip { get; set; }

        [DisplayName("fax")]
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
        public DateTime lastLogin { get; set; }

        [DisplayName("is Email Subscribed")]
        public Nullable<bool> isEmailSubscribed { get; set; }

        [DisplayName("created")]
        [Required]
        public DateTime created { get; set; }

        [DisplayName("modified")]
        [Required]
        public DateTime modified { get; set; }

        [DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }

        [DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }

        [DisplayName("is Active")]
        public Nullable<bool> isActive { get; set; }


        [ForeignKey("cityTypeId")]
        public CityTypeVo cityType { get; set; }

        [ForeignKey("countryTypeId")]
        public CountryTypeVo countryType { get; set; }

        [ForeignKey("stateTypeId")]
        public StateTypeVo stateType { get; set; }

        [Association("Member_MemberRoleLookup", "memberId", "memberId")]
        public List<MemberRoleLookupVo> memberRoleLookupses { get; set; }

        [Association("Member_Rating", "memberId", "memberId")]
        public List<RatingVo> ratingses { get; set; }

        [NotMapped]
        public List<int> memberRoleTypes { get; set; }
        
        public MemberVo()
        {
            this.isActive = true;
            this.created = DateTime.Now;
            this.modified = this.created;
        }
    }
}
