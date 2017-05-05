using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Dto
{
    public class FEi_NotificationSenderResponse
    {
        public int EvaluatedNotifications { get; set; }

        public int EvaluatedBagHours { get; set; }

        public int NotifiedBagHours { get; set; }

        public string NotifiedBagHoursDetails { get; set; }

        public string Message { get; set; }

        public bool Result { get; set; }

        public string Error { get; set; }
    }
}
