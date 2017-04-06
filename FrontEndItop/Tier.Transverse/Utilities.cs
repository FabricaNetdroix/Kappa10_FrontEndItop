using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Transverse
{
    public class Utilities
    {
        public static string GetStringFromBase64(string base64String)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64String));
        }
    }
}
