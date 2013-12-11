using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Models.ValueObjects
{
    [Table("IsPetAllowedType", Schema = "app")]
    [Serializable]
    public partial class IsPetAllowedTypeVo
    {
        [DisplayName("Id Number")]
        [Key]
        public int isPetAllowedTypeId { get; set; }

        [DisplayName("Name")]
        [Required]
        [StringLength(15)]
        public string name { get; set; }

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

        [DisplayName("Is Active")]
        [Required]
        public bool isActive { get; set; }



        //[Association("IsPetAllowedType_Property", "isPetAllowedTypeId", "isPetAllowedTypeId", IsForeignKey = true)]
        //public List<PropertyVo> car { get; set; }

        public IsPetAllowedTypeVo()
        {
            this.isActive = true;
        }
    }
}

