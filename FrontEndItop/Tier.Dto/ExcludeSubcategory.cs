﻿using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class ExcludeSubcategory
    {
        [Column(Name = "id")]
        public Nullable<int> id { get; set; }
    }
}
