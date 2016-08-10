using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class FEi_BagHours
    {
        //# last_user_update
        public Nullable<int> id { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Dato requerido.")]
        public Nullable<int> organization_id { get; set; }

        [Display(Name = "Cliente")]
        public string organization_name { get; set; }

        [Display(Name = "Contrato")]
        [Required(ErrorMessage = "Dato requerido.")]
        public Nullable<int> contract_id { get; set; }

        [Display(Name = "Contrato")]
        public string contract_name { get; set; }

        [Display(Name = "Fecha inicio")]
        public Nullable<DateTime> contract_start { get; set; }

        [Display(Name = "Fecha fin")]
        public Nullable<DateTime> contract_end { get; set; }

        [Display(Name = "Horas")]
        [Required(ErrorMessage = "Dato requerido.")]
        [Range(1, short.MaxValue)]
        public Nullable<short> quantity { get; set; }

        [Display(Name = "Garantía?")]
        public Nullable<bool> is_warranty { get; set; }

        [Display(Name = "Observaciones")]
        public string notes { get; set; }

        [Display(Name = "Estado")]
        public Nullable<short> status { get; set; }

        public Nullable<int> last_user_update { get; set; }
    }
}
