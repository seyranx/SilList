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
    [Table("JobCompany", Schema = "data")]
    [Serializable]
    public partial class JobCompanyVo
    {

        [DisplayName("jobCompany Id")]
        [Key]
        public int jobCompanyId { get; set; }

        [DisplayName("name")]
        [StringLength(250)]
        public string name { get; set; }

        [DisplayName("domain")]
        [StringLength(250)]
        public string domain { get; set; }

        [DisplayName("description")]
        public string description { get; set; }

        [DisplayName("logo")]
        [StringLength(250)]
        public string logo { get; set; }

        [DisplayName("logo Url")]
        public string logoUrl { get; set; }

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

        // [Association("JobCompany_Business", "JobCompanyId", "JobCompanyId", IsForeignKey = true)]
        /// public List<JobCompanyVo> businesses { get; set; }

      //  [Association("JobCompany_Member", "JobCompanyId", "JobCompanyId", IsForeignKey = true)]
        //public List<MemberVo> member { get; set; }
    }
}
