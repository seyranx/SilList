
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

    [Table("StatusType", Schema = "app")]
    [Serializable]
    public partial class StatusTypeVo
    {

        [DisplayName("rent Type Id")]
        [Key]
        public int statusTypeId { get; set; }

        [DisplayName("Name")]
        [StringLength(50)]
        public string name { get; set; }

        [DisplayName("Description")]
        public string description { get; set; }

        [DisplayName("created")]
        [Required]
        public System.DateTime created { get; set; }

        [DisplayName("modified")]
        [Required]
        public System.DateTime modified { get; set; }

        [DisplayName("created By")]
        public int? createdBy { get; set; }

        [DisplayName("modified By")]
        public int? modifiedBy { get; set; }

        [DisplayName("Is Active")]
        public bool isActive { get; set; }

        [Association("StatusType_Rental", "statusTypeId", "statusTypeId", IsForeignKey = true)]
        public List<PropertyVo> property { get; set; }

        public StatusTypeVo()
        {
            this.isActive = true;
        }
    }
}
