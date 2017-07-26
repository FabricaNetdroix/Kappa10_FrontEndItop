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
    public class FEi_Notification
    {
        [Column(Name = "id")]
        public Nullable<int> id { get; set; }

        [Display(Name = "Destinatarios de correo")]
        [Required(ErrorMessage = "Dato requerido.")]
        [Column(Name = "recipients")]
        public string recipients { get; set; }

        [Display(Name = "Regla F. días previos")]
        [Range(1, 255, ErrorMessage = "El valor debe estar entre 1 y 32767.")]
        [Column(Name = "date_rule")]
        public Nullable<short> date_rule { get; set; }

        [Display(Name = "Regla % Horas consumidas (Inf)")]
        [Range(1, 100, ErrorMessage = "El valor debe estar entre 1 y 100.")]
        [Column(Name = "hours_rule_lowest")]
        public Nullable<byte> hours_rule_lowest { get; set; }

        [Display(Name = "Regla % Horas consumidas (Sup)")]
        [Range(1, 100, ErrorMessage = "El valor debe estar entre 1 y 100.")]
        [Column(Name = "hours_rule_highest")]
        public Nullable<byte> hours_rule_highest { get; set; }

        [Display(Name = "Plantilla HTML")]
        [Column(Name = "html_template")]
        [Required(ErrorMessage = "Dato requerido.")]
        public string html_template { get; set; }

        [Display(Name = "Observaciones")]
        [Column(Name = "notes")]
        public string notes { get; set; }

        [Display(Name = "Estado")]
        [Column(Name = "status")]
        public Nullable<short> status { get; set; }

        [Column(Name = "last_user_update")]
        public Nullable<int> last_user_update { get; set; }

        [Column(Name = "is_visible")]
        public Nullable<bool> is_visible { get; set; }
    }
}
