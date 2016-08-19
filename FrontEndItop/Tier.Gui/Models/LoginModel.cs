using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tier.Gui.Models
{
    public class LoginModel
    {
        [Display(Name = "Alias")]
        [Required(ErrorMessage = "Dato requerido")]
        public string UserAlias { get; set; }
        [Display(Name = "Clave")]
        [Required(ErrorMessage = "Dato requerido")]
        public string UserPassword { get; set; }
        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "Dato requerido")]
        public byte UserType { get; set; }

        public string RecaptchaToken { get; set; }
    }
}