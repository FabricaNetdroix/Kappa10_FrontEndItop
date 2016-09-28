using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public enum BagHoursStatus : short
    {
        Active = 1,
        Notified = 2,
        Inactive = 3
    }

    public enum UserStatus : short
    {
        Active = 4,
        Inactive = 5
    }

    public enum NotificationStatus : short
    {
        Active = 6,
        Inactive = 7
    }

    public enum UserTypes : byte
    {
        Costumer = 0,
        Vendor = 1,
        Administrator = 2
    }
}
