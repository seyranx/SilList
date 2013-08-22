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

    [Table("JobType", Schema = "app")]
    [Serializable]
    public partial class JobTypeVo
    {
        [DisplayName("jobType Id")]
        [Key]
        public int jobTypeId { get; set; }

        [DisplayName("name")]
        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [DisplayName("description")]
        [Required]
        public string description { get; set; }

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
        public bool isActive { get; set; }

        [Association("JobType_Job", "jobTypeId", "jobTypeId", IsForeignKey = true)]
        public List<JobVo> job { get; set; }

        public JobTypeVo()
        {
            //this.created= getDate();
            //this.modified = getDate();
            this.jobTypeId = 1;
            this.isActive = true;
        }
    }
}