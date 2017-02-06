using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class IP_Tickets
    {
        [Column(Name = "id")]
        public Nullable<int> id { get; set; }

        [Column(Name = "ref")]
        public string reference { get; set; }

        [Column(Name = "description")]
        public string description { get; set; }

        [Column(Name = "start_date")]
        public Nullable<DateTime> start_date { get; set; }

        [Column(Name = "end_date")]
        public Nullable<DateTime> end_date { get; set; }

        [Column(Name = "close_date")]
        public Nullable<DateTime> close_date { get; set; }

        [Column(Name = "private_log")]
        public string private_log { get; set; }

        public Double elapsedtime
        {
            get
            {
                if (this.close_date.HasValue)
                {
                    return (this.close_date.Value - this.start_date.Value).TotalHours;
                }
                else if (this.end_date.HasValue)
                {
                    return (this.end_date.Value - this.start_date.Value).TotalHours;
                }
                else
                {
                    return (DateTime.Now - this.start_date.Value).TotalHours;
                }
            }
        }
    }
}
