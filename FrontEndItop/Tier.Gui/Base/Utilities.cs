using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static IList<KeyValuePair<short, string>> GetUserStatusList()
        {
            return new List<KeyValuePair<short, string>>() { 
                new KeyValuePair<short, string>((short)Dto.UserStatus.Active, Messages.UserStatusDisplayTextActive), 
                new KeyValuePair<short, string>((short)Dto.UserStatus.Inactive, Messages.UserStatusDisplayTextInactive)
            };
        }

        public static IList<KeyValuePair<short, string>> GetBagHoursStatusList()
        {
            return new List<KeyValuePair<short, string>>() { 
                new KeyValuePair<short, string>((short)Dto.BagHoursStatus.Implementacion, Messages.BagHoursStatusDisplayTextImplementation), 
                new KeyValuePair<short, string>((short)Dto.BagHoursStatus.Active, Messages.BagHoursStatusDisplayTextActive), 
                new KeyValuePair<short, string>((short)Dto.BagHoursStatus.Notified, Messages.BagHoursStatusDisplayTextNotified), 
                new KeyValuePair<short, string>((short)Dto.BagHoursStatus.Inactive, Messages.BagHoursStatusDisplayTextInactive)
            };
        }

        public static IList<KeyValuePair<short, string>> GetNotificationStatusList()
        {
            return new List<KeyValuePair<short, string>>() { 
                new KeyValuePair<short, string>((short)Dto.NotificationStatus.Active, Messages.NotificationStatusDisplayTextActive), 
                new KeyValuePair<short, string>((short)Dto.NotificationStatus.Inactive, Messages.NotificationStatusDisplayTextInactive)
            };
        }
    }
}