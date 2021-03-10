using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Users.Areas.Usuario.Pages.Account
{    
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return Page();
        }
        
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name="Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage = "El numero maximo de caracteres de {0} debe ser al menos {2}", MinimumLength = 6)]
            [Display(Name="Contraseña")]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage ="Las contraseñas no eson iguales")]
            public string ConfirmPassword { get; set; }
        }
    }
}
