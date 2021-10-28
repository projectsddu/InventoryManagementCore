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
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Remember Me!")]
        public bool RememberMe { get; set; }
    }
}
