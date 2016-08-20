using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.Base
{
    public class Enumerations
    {
        /// <summary>
        /// 
        /// </summary>
        public enum NotificationTypes
        {
            success,
            error,
            info,
            notice,
            warning,
        }

        public enum ApplicationModules : byte
        {
            FrontEndSummary = 1,
            BackEndSummary = 2,
            BagHoursManagement = 3,
            NotificationManagement = 4,
            UserManagement = 5,
            Notifications = 6,
            SelfManagement = 7
        }
    }
}