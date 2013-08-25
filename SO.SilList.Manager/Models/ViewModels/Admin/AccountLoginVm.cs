using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Admin.Web.Models
{
    public class AccountLoginVm
    {
        [DisplayName("Username")]
        [Required]
        public string username { get; set; }

        [DisplayName("Password")]
        [Required]
        public string password { get; set; }

        [DisplayName("Remember Me")]
        public bool rememberMe { get; set; }

        public AccountLoginVm()
        {
            this.rememberMe = true;
        }
    }
}
