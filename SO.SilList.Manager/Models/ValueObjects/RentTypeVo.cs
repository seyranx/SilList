
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

    [Table("RentType", Schema = "app")]
    [Serializable]
    public partial class RentTypeVo
    {

        [DisplayName("rent Type Id")]
        [Key]
        public int rentTypeId { get; set; }

        [DisplayName("name")]
        [StringLength(50)]
        public string name { get; set; }

        [DisplayName("description")]
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

        [Association("RentType_Rental", "rentTypeId", "rentTypeId", IsForeignKey = true)]
        public List<RentalVo> rental { get; set; }

        public RentTypeVo()
        {


            this.isActive = true;
        }
    }
}
