using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BFEi_Notifications
    {

        /// <summary>
        /// Indicates whether a notification sending process is running or not.
        /// </summary>
        private static bool isProcessingNotifications;

        /// <summary>
        /// Indicates whether a notification sending process is running or not.
        /// </summary>
        public static bool IsProcessingNotifications
        {
            get { return BFEi_Notifications.isProcessingNotifications; }
        }

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

        public IList<Dto.FEi_Notification> GetActiveNotifications()
        {
            return new Data.DFEi_Notifications().RetrieveFiltered(new Dto.FEi_Notification() { status = (short)Dto.NotificationStatus.Active });
        }

        public bool UpdateNotification(Dto.FEi_Notification obj)
        {
            return new Data.DFEi_Notifications().Update(obj);
        }

        public bool DeleteNotification(Dto.FEi_Notification obj)
        {
            return new Data.DFEi_Notifications().Delete(obj);
        }


        public Dto.FEi_NotificationSenderResponse SendNotifications()
        {
            try
            {
                int QtyNotifications = 0;
                int QtyBagHours = 0;
                int QtyNotifiedBagHours = 0;
                StringBuilder notifiedBagHours = new StringBuilder();

                if (!isProcessingNotifications)
                {
                    isProcessingNotifications = true;

                    IList<Dto.FEi_Notification> notifications = new Business.BFEi_Notifications().GetActiveNotifications();
                    IList<Dto.FEi_BagHours> baghours = new Business.BFEi_BagHours().GetBagActiveHours();

                    QtyNotifications = notifications.Count;
                    QtyBagHours = baghours.Count;
                    QtyNotifiedBagHours = 0;

                    notifiedBagHours.Append("[");

                    foreach (Dto.FEi_Notification notification in notifications)
                    {
                        foreach (Dto.FEi_BagHours bh in baghours)
                        {
                            IList<Dto.IP_Tickets> contractTickets = new Business.IP_General().GetTicketsByContractId((int)bh.contract_id);

                            double totalSpendedHours = Math.Round(contractTickets.Sum(ee => ee.elapsedhours));
                            double hoursPercentage = Math.Round((totalSpendedHours * 100) / bh.quantity.Value);

                            double daysToContractExpiration = (bh.contract_end.Value.Date - DateTime.Now.Date).TotalDays;

                            if (daysToContractExpiration.Equals(notification.date_rule) | (hoursPercentage >= notification.hours_rule_lowest && hoursPercentage <= notification.hours_rule_highest))
                            {
                                Data.DFEi_NotifiedBagHours dataNB = new Data.DFEi_NotifiedBagHours();
                                Dto.FEi_NotifiedBagHours nb = new Dto.FEi_NotifiedBagHours() { baghours_id = bh.id, notifications_id = notification.id };

                                if (!dataNB.GetNotificationBagHourFlag(nb))
                                {
                                    string messageBody = ReplaceNotificationData(notification, bh);
                                    Tier.Transverse.Utilities.SendMail(notification.recipients, "Notificación bolsa de horas.", messageBody);
                                    
                                    QtyNotifiedBagHours++;
                                    notifiedBagHours.Append("{\"Notification\":\"" + notification.id.ToString() + "\",\"BagHour\":\"" + bh.id + "\"},");

                                    dataNB.Insert(nb);
                                }
                            }
                        }
                    }

                    notifiedBagHours.Append("]"); notifiedBagHours = notifiedBagHours.Replace("},", "}");

                    isProcessingNotifications = false;

                    return new Dto.FEi_NotificationSenderResponse()
                    {
                        EvaluatedBagHours = QtyBagHours,
                        EvaluatedNotifications = QtyNotifications,
                        NotifiedBagHours = QtyNotifiedBagHours,
                        NotifiedBagHoursDetails = notifiedBagHours.ToString(),
                        Message = "Se han procesado las notificaciones correctamente.",
                        Result = true,

                    };
                }
                else
                {
                    return new Dto.FEi_NotificationSenderResponse() { Message = "Una solicitu de envío de notificaciones está siendo ejecutada. Intente mas tarde.", Result = false };
                }
            }
            catch (Exception ex)
            {
                return new Dto.FEi_NotificationSenderResponse() { Message = "Se ha producido una excepción", Result = false, Error = ex.ToString() };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="bh"></param>
        /// <returns></returns>
        private static string ReplaceNotificationData(Dto.FEi_Notification notification, Dto.FEi_BagHours bh)
        {
            string result = notification.html_template;

            result = result.Replace("[[DiasNotificacion]]", (notification.date_rule.HasValue ? notification.date_rule.ToString() : "N/A"));

            string lt, gt;
            lt = (notification.hours_rule_lowest.HasValue ? notification.hours_rule_lowest.Value.ToString() : "N/A");
            gt = (notification.hours_rule_highest.HasValue ? notification.hours_rule_highest.Value.ToString() : "N/A");
            result = result.Replace("[[ProcentajeHorasNotificacion]]", string.Format("{0}% - {1}%", lt, gt));

            result = result.Replace("[[IDBoldaHoras]]", bh.id.ToString());
            result = result.Replace("[[NombreOrganizacion]]", bh.organization_name);
            result = result.Replace("[[IDContrato]]", bh.contract_id.ToString());
            result = result.Replace("[[ContratoFInicial]]", bh.contract_start.Value.ToShortDateString());
            result = result.Replace("[[ContratoFFinal]]", bh.contract_end.Value.ToShortDateString());
            result = result.Replace("[[HorasContratadas]]", bh.quantity.ToString());
            result = result.Replace("[[BolsaHorasXGarantia]]", (bh.is_warranty.Value ? "Si" : "No"));
            result = result.Replace("[[ObservacionesBolsaHoras]]", (bh.notes != null ? bh.notes : "N/A"));

            string status = string.Empty;
            Tier.Dto.BagHoursStatus eStatus;
            Enum.TryParse(bh.status.Value.ToString(), out eStatus);

            switch (eStatus)
            {
                case Tier.Dto.BagHoursStatus.Active:
                    status = "Activa";
                    break;
                case Tier.Dto.BagHoursStatus.Notified:
                    status = "Notificada";
                    break;
                case Tier.Dto.BagHoursStatus.Inactive:
                    status = "Inactiva";
                    break;
                case Tier.Dto.BagHoursStatus.Implementacion:
                    status = "En Implementación";
                    break;
                default:
                    status = "N/A";
                    break;
            }

            result = result.Replace("[[EstadoBolsaHoras]]", status);

            return result;
        }
    }
}
