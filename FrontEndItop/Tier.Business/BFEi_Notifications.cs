using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BFEi_Notifications
    {
        public bool CreateNotification(Dto.FEi_Notification obj)
        {
            return new Data.DFEi_Notifications().Insert(obj);
        }

        public IList<Dto.FEi_Notification> GetAllNotification()
        {
            return new Data.DFEi_Notifications().RetrieveFiltered(new Dto.FEi_Notification());
        }

        public Dto.FEi_Notification GetNotificationById(int idNotification)
        {
            return new Data.DFEi_Notifications().RetrieveFiltered(new Dto.FEi_Notification() { id = idNotification }).FirstOrDefault();
        }

        public bool UpdateNotification(Dto.FEi_Notification obj)
        {
            return new Data.DFEi_Notifications().Update(obj);
        }

        public bool DeleteNotification(Dto.FEi_Notification obj)
        {
            return new Data.DFEi_Notifications().Delete(obj);
        }
    }
}
