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
    [Table("Admin", Schema = "app")]
    [Serializable]
    public partial class AdminVo
    {
        [DisplayName("Admin Id")]
        [Key]
        public int adminId { get; set; }

        [DisplayName("First Name")]
        [StringLength(50)]
        public string firstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(50)]
        public string lastName { get; set; }

        [DisplayName("email")]
        [StringLength(50)]
        public string email { get; set; }

        [DisplayName("username")]
        [StringLength(50)]
        public string username { get; set; }

        [DisplayName("password")]
        [StringLength(50)]
        public string password { get; set; }

        [DisplayName("phone")]
        [StringLength(50)]
        public string phone { get; set; }

        [DisplayName("is Email Confirmed")]
        public Nullable<bool> isEmailConfirmed { get; set; }

        [DisplayName("ip Address")]
        [StringLength(50)]
        public string ipAddress { get; set; }

        [DisplayName("last Login")]
        public System.DateTime? lastLogin { get; set; }

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

        public AdminVo()
        {
    		this.adminId  = 0;
            this.lastLogin = null;
    	    this.isActive = true;
    	 }
    }
}
