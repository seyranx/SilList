
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

    [Table("SettingType", Schema = "app")]
    [Serializable]
    public partial class SettingTypeVo
    {

        [DisplayName("setting Type Id")]
        [Key]
        public int settingTypeId { get; set; }

        [DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }

        [DisplayName("name")]
        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [DisplayName("groupName")]
        [Required]
        [StringLength(50)]
        public string groupName { get; set; }


        [DisplayName("value")]
        [StringLength(50)]
        public string value { get; set; }

        [DisplayName("description")]
        public string description { get; set; }

        [DisplayName("environment Type Id")]
        public Nullable<int> environmentTypeId { get; set; }

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

        //[ForeignKey("siteId")]
        //public virtual SiteVo site { get; set; }

        //[ForeignKey("environmentTypeId")]
        //public virtual EnvironmentTypeVo site { get; set; }

        
        public SettingTypeVo()
        {
           this.isActive = true;
        }
    }
}
