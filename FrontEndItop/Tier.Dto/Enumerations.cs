using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public enum BagHoursStatus : short
    {
        Implementacion = 1,
        Active = 2,
        Notified = 3,
        Inactive = 4
    }

    public enum UserStatus : short
    {
        Active = 5,
        Inactive = 6
    }

    public enum NotificationStatus : short
    {
        Active = 7,
        Inactive = 8
    }

    public enum UserTypes : byte
    {
        Costumer = 0,
        Vendor = 1,
        Administrator = 2
    }
}
