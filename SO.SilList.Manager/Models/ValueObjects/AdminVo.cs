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

        [DisplayName("Email")]
        [StringLength(50)]
        public string email { get; set; }

        [DisplayName("Username")]
        [StringLength(50)]
        public string username { get; set; }

        [DisplayName("Password")]
        [StringLength(50)]
        public string password { get; set; }

        [DisplayName("Phone")]
        [StringLength(50)]
        public string phone { get; set; }

        [DisplayName("Email Confirmed")]
        public Nullable<bool> isEmailConfirmed { get; set; }

        [DisplayName("Super Admin")]
        public bool isSuperAdmin { get; set; }

        [DisplayName("IP Address")]
        [StringLength(50)]
        public string ipAddress { get; set; }

        [DisplayName("Last Login")]
        public System.DateTime? lastLogin { get; set; }

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

        public AdminVo()
        {
    		this.adminId  = 0;
            this.isSuperAdmin = false;
            this.lastLogin = null;
    	    this.isActive = true;
    	 }
    }
}
