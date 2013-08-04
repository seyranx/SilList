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
        public Guid jobCompanyId { get; set; }

        [DisplayName("name")]
        [StringLength(250)]
        public string name { get; set; }

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
        public int zip { get; set; }

        [DisplayName("website")]
        [StringLength(50)]
        public string website { get; set; }

        [DisplayName("phone")]
        [StringLength(50)]
        public string phone { get; set; }

        [DisplayName("siteId")]
        [StringLength(10)]
        public string siteId { get; set; }

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

        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }
        // [Association("JobCompany_Business", "JobCompanyId", "JobCompanyId", IsForeignKey = true)]
        /// public List<JobCompanyVo> businesses { get; set; }

        //[Association("JobCompany_Member", "JobCompanyId", "JobCompanyId", IsForeignKey = true)]
        //public List<MemberVo> member { get; set; }

        public JobCompanyVo()
        {
            this.jobCompanyId = Guid.NewGuid();
            this.isActive = true;
        }
    }
}
