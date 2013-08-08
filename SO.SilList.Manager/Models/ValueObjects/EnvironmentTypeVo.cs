
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

    [Table("EnvironmentType", Schema = "app")]
    [Serializable]
    public partial class EnvironmentTypeVo
    {

        [DisplayName("Environment Type Id")]
        [Key]
        public int environmentTypeId { get; set; }

        [DisplayName("name")]
        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [DisplayName("url")]
        [StringLength(50)]
        public string url { get; set; }

        [DisplayName("description")]
        [StringLength(50)]
        public string description { get; set; }

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
        [Required]
        public bool isActive { get; set; }

        public EnvironmentTypeVo()
        {


            this.isActive = true;
        }
    }
}
