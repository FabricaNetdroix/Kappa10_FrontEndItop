using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class FEi_BagHours
    {
        [Column(Name = "id")]
        public Nullable<int> id { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Dato requerido.")]
        [Column(Name = "organization_id")]
        public Nullable<int> organization_id { get; set; }

        [Display(Name = "Cliente")]
        [Column(Name = "organization_name")]
        public string organization_name { get; set; }

        [Display(Name = "Contrato")]
        [Required(ErrorMessage = "Dato requerido.")]
        [Column(Name = "contract_id")]
        public Nullable<int> contract_id { get; set; }

        [Display(Name = "Contrato")]
        [Column(Name = "contract_name")]
        public string contract_name { get; set; }

        [Display(Name = "Fecha inicio")]
        [Column(Name = "contract_start")]
        public Nullable<DateTime> contract_start { get; set; }

        [Display(Name = "Fecha fin")]
        [Column(Name = "contract_end")]
        public Nullable<DateTime> contract_end { get; set; }

        [Display(Name = "Descripción")]
        [Column(Name = "contract_description")]
        public string contract_description { get; set; }

        [Display(Name = "Servicios")]
        [Column(Name = "contract_services")]
        public string contract_services { get; set; }

        [Display(Name = "Horas")]
        [Required(ErrorMessage = "Dato requerido.")]
        [Range(1, short.MaxValue)]
        [Column(Name = "quantity")]
        public Nullable<short> quantity { get; set; }

        [Display(Name = "Garantía?")]
        [Column(Name = "is_warranty")]
        public Nullable<bool> is_warranty { get; set; }

        [Display(Name = "Observaciones")]
        [Column(Name = "notes")]
        public string notes { get; set; }

        [Display(Name = "Estado")]
        [Column(Name = "status")]
        public Nullable<short> status { get; set; }

        [Column(Name = "last_user_update")]
        public Nullable<int> last_user_update { get; set; }
    }
}
