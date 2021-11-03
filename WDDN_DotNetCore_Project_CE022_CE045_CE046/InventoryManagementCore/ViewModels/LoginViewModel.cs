using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required!!")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Display(Name = "Remember Me!")]
        public bool RememberMe { get; set; }
    }
}
