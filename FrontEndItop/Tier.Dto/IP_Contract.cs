using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class IP_Contract
    {
        public Nullable<int> id { get; set; }

        public string name { get; set; }

        public Nullable<int> org_id { get; set; }

        public string organization_name { get; set; }

        public string description { get; set; }

        public Nullable<DateTime> start_date { get; set; }

        public Nullable<DateTime> end_date { get; set; }

        public Nullable<int> provider_id { get; set; }

        public string provider_name { get; set; }
    }
}
