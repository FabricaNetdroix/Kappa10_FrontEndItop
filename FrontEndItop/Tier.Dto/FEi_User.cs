using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class FEi_User
    {
        [Column(Name = "id")]
        public Nullable<int> id { get; set; }

        [Column(Name = "alias")]
        public string alias { get; set; }

        [Column(Name = "password")]
        public string password { get; set; }

        [Column(Name = "role")]
        public Nullable<byte> role { get; set; }

        [Column(Name = "first_name")]
        public string first_name { get; set; }

        [Column(Name = "last_name")]
        public string last_name { get; set; }

        [Column(Name = "email")]
        public string email { get; set; }

        [Column(Name = "department")]
        public string department { get; set; }

        [Column(Name = "status")]
        public Nullable<short> status { get; set; }

        [Column(Name = "notes")]
        public string notes { get; set; }

        [Column(Name = "last_user_update")]
        public Nullable<int> last_user_update { get; set; }
    }
}
