using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class LoginVm
    {
        [DisplayName("Email")]
        [Required]
        public string email { get; set; }

        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DisplayName("Remember Me")]
        public bool rememberMe { get; set; }

        public LoginVm()
        {
            this.rememberMe = true;
        }
    }
}
