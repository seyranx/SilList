using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Admin.Web.Models
{
    public class AccountManageVm
    {
        [DisplayName("Admin Id")]
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

        public AccountManageVm()
        {
        }
    }
}
