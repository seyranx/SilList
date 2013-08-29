
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

        [DisplayName("Name")]
        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [DisplayName("URL")]
        [StringLength(50)]
        public string url { get; set; }

<<<<<<< master
=======

>>>>>>> local
        [DisplayName("Description")]
        [StringLength(50)]
        public string description { get; set; }

        [DisplayName("Created By")]
        public Nullable<int> createdBy { get; set; }

        [DisplayName("Modified By")]
        public Nullable<int> modifiedBy { get; set; }

        [DisplayName("Modified")]
        [Required]
        public System.DateTime modified { get; set; }

        [DisplayName("Created")]
        [Required]
        public System.DateTime created { get; set; }

        [DisplayName("Is Active")]
        [Required]
        public bool isActive { get; set; }

        public EnvironmentTypeVo()
        {


            this.isActive = true;
        }
    }
}
