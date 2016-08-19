using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Tier.Dto
{
    public class IP_Contract
    {
        [Column(Name = "id")]
        public Nullable<int> id { get; set; }

        [Column(Name = "name")]
        public string name { get; set; }

        [Column(Name = "org_id")]
        public Nullable<int> org_id { get; set; }

        [Column(Name = "organization_name")]
        public string organization_name { get; set; }

        [Column(Name = "description")]
        public string description { get; set; }

        [Column(Name = "start_date")]
        public Nullable<DateTime> start_date { get; set; }

        [Column(Name = "end_date")]
        public Nullable<DateTime> end_date { get; set; }

        [Column(Name = "provider_id")]
        public Nullable<int> provider_id { get; set; }

        [Column(Name = "provider_name")]
        public string provider_name { get; set; }
    }
}
