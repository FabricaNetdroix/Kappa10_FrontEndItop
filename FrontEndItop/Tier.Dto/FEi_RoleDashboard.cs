using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class FEi_RoleDashboard
    {
        [Column(Name = "TotalBagHoursSold")]
        [Display(Name = "Total H. Vendidas")]
        public Nullable<int> TotalBagHoursSold { get; set; }

        [Column(Name = "ActiveBagHours")]
        [Display(Name = "BH. Activas")]
        public Nullable<int> ActiveBagHours { get; set; }

        [Column(Name = "ImplementingBagHours")]
        [Display(Name = "BH. Implementación")]
        public Nullable<int> ImplementingBagHours { get; set; }

        [Column(Name = "InactiveBagHours")]
        [Display(Name = "BH. Inactivas")]
        public Nullable<int> InactiveBagHours { get; set; }
    }
}
