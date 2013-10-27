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

        [DisplayName("JobCompany")]
        [Key]
        public Guid jobCompanyId { get; set; }

        [DisplayName("Name")]
        [StringLength(250)]
        public string name { get; set; }

        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("City")]
        public int cityTypeId { get; set; }

        [DisplayName("State")]
        public int stateTypeId { get; set; }
     
        [DisplayName("Country")]
        public int countryTypeId { get; set; }

        [DisplayName("Zip")]
        public int zip { get; set; }

        [DisplayName("Website")]
        [StringLength(50)]
        public string website { get; set; }

        [DisplayName("Phone")]
        [StringLength(50)]
        public string phone { get; set; }

        [DisplayName("Fax")]
        [StringLength(50)]
        public string fax { get; set; }

        [DisplayName("Site")]
        public int siteId { get; set; }

        [DisplayName("Created")]
        [Required]
        public System.DateTime created { get; set; }

        [DisplayName("Modified")]
        [Required]
        public System.DateTime modified { get; set; }

        [DisplayName("Created By")]
        public Nullable<int> createdBy { get; set; }

        [DisplayName("Modified By")]
        public Nullable<int> modifiedBy { get; set; }

        [DisplayName("Active")]
        public bool isActive { get; set; }

        [ForeignKey("countryTypeId")]
        public virtual CountryTypeVo countryType { get; set; }

        [ForeignKey("stateTypeId")]
        public virtual StateTypeVo stateType { get; set; }

        [ForeignKey("cityTypeId")]
        public virtual CityTypeVo cityType { get; set; }

        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

        [Association("JobCompany_Job", "JobCompanyId", "JobCompanyId", IsForeignKey = true)]
        public List<JobVo> job { get; set; }

        // [Association("JobCompany_Business", "JobCompanyId", "JobCompanyId", IsForeignKey = true)]
        // public List<JobCompanyVo> businesses { get; set; }

        //[Association("JobCompany_Member", "JobCompanyId", "JobCompanyId", IsForeignKey = true)]
        //public List<MemberVo> member { get; set; }

        public JobCompanyVo()
        {
            this.jobCompanyId = Guid.NewGuid();
            this.isActive = true;
        }
    }
}
