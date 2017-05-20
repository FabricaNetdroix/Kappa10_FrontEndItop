using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public enum Entities : byte
    {
        BagHour = 1,
        User = 2,
        Notification = 3
    }

    public enum BagHoursStatus : short
    {
        Implementacion = 1,
        Active = 2,
        Notified = 3,
        Inactive = 4,
        Deleted = 5
    }

    public enum UserStatus : short
    {
        Active = 6,
        Inactive = 7,
        Deleted = 8
    }

    public enum NotificationStatus : short
    {
        Active = 9,
        Inactive = 10,
        Deleted = 11
    }

    public enum UserTypes : byte
    {
        Costumer = 0,
        Vendor = 1,
        Administrator = 2
    }
}
