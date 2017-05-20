using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Tier.Dto
{
    public class FEi_User
    {
        [Column(Name = "id")]
        public Nullable<int> id { get; set; }

        [Column(Name = "alias")]
        [Display(Name = "Alias")]
        [StringLength(16, ErrorMessage = "Dato demasiado largo")]
        [Remote("ValidateUserAlias", "BackEnd", AdditionalFields = "editando, initialalias", ErrorMessage = "Alias no disponible")]
        [Required(ErrorMessage = "Dato requerido")]
        public string alias { get; set; }

        [Column(Name = "password")]
        [Display(Name = "Clave")]
        [Required(ErrorMessage = "Dato requerido")]
        public string password { get; set; }

        [Column(Name = "password")]
        [Display(Name = "Clave confirmación")]
        [Remote("ValidatePasswords", "BackEnd", ErrorMessage = "Las claves no son iguales", AdditionalFields = "password")]
        [Required(ErrorMessage = "Dato requerido")]
        public string passwordConfirm { get; set; }

        [Column(Name = "role")]
        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "Dato requerido")]
        public Nullable<byte> role { get; set; }

        [Column(Name = "first_name")]
        [Display(Name = "Nombres")]
        [StringLength(64, ErrorMessage = "Dato demasiado largo")]
        [Required(ErrorMessage = "Dato requerido")]
        public string first_name { get; set; }

        [Column(Name = "last_name")]
        [Display(Name = "Apellidos")]
        [StringLength(64, ErrorMessage = "Dato demasiado largo")]
        [Required(ErrorMessage = "Dato requerido")]
        public string last_name { get; set; }

        [Column(Name = "email")]
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        [Required(ErrorMessage = "Dato requerido")]
        public string email { get; set; }

        [Column(Name = "department")]
        [Display(Name = "Proceso")]
        [StringLength(256, ErrorMessage = "Dato demasiado largo")]
        public string department { get; set; }

        [Column(Name = "status")]
        [Display(Name = "Estado")]
        public Nullable<short> status { get; set; }

        [Column(Name = "notes")]
        [Display(Name = "Observaciones")]
        public string notes { get; set; }

        [Column(Name = "last_user_update")]
        public Nullable<int> last_user_update { get; set; }

        [Column(Name = "is_visible")]
        public Nullable<bool> is_visible { get; set; }

        public static Nullable<int> DefaultNotificationServiceUserId
        {
            get
            {
                return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DefaultNotificaciontSenderUserId"].ToString());
            }
        }
    }
}
