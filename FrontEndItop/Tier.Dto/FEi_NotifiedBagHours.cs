using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class FEi_NotifiedBagHours
    {
        [Column(Name = "notifications_id")]
        public Nullable<int> notifications_id { get; set; }

        [Column(Name = "baghours_id")]
        public Nullable<int> baghours_id { get; set; }

        [Column(Name = "date")]
        public Nullable<DateTime> date { get; set; }
    }
}
