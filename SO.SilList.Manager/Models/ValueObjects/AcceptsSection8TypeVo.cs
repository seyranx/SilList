using SO.SilList.Manager.DbContexts;
using SO.SilList.Manager.Interfaces;
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
using EntityFramework.Extensions;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Models.ValueObjects
{
    [Table("AcceptsSection8Type", Schema = "app")]
    [Serializable]
    public partial class AcceptsSection8TypeVo
    {
        [DisplayName("Id Number")]
        [Key]
        public int acceptsSection8TypeId { get; set; }

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



        //[Association("AcceptsSection8Type_Property", "acceptsSection8TypeId", "acceptsSection8TypeId", IsForeignKey = true)]
        //public List<PropertyVo> car { get; set; }

        public AcceptsSection8TypeVo()
        {
            this.isActive = true;
        }
    }
}
