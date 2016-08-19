using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.Base
{
    public static class Utilities
    {
        public static IList<KeyValuePair<byte, string>> GetRolesList()
        {
            return new List<KeyValuePair<byte, string>>() { 
                new KeyValuePair<byte, string>(0, Messages.RoleDisplayTextCostumer), 
                new KeyValuePair<byte, string>(1, Messages.RoleDisplayTextVendor), 
                new KeyValuePair<byte, string>(2, Messages.RoleDisplayTextAdministrator)
            };
        }
    }
}