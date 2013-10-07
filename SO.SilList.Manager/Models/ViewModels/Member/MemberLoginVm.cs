using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Models
{
    public class MemberLoginVm
    {
        [DisplayName("Email")]
        [Required]
        public string email { get; set; }

        [DisplayName("Password")]
        [Required]
        public string password { get; set; }

        [DisplayName("Remember Me")]
        public bool rememberMe { get; set; }

        public MemberLoginVm()
        {
            this.rememberMe = true;
        }
    }
}
