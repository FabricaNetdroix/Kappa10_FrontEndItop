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
            return new Data.DFEi_Notifications().RetrieveFiltered(new Dto.FEi_Notification() { status = (short)Dto.NotificationStatus.Active, is_visible = true });
        }

        public bool UpdateNotification(Dto.FEi_Notification obj)
        {
            return new Data.DFEi_Notifications().Update(obj);
        }

        public bool DeleteNotification(Dto.FEi_Notification obj)
        {
            return new Data.DFEi_Notifications().Delete(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dto.FEi_NotificationSenderResponse SendNotifications()
        {
            try
            {
                int qtyNotifications = 0;
                int qtyBagHours = 0;
                int qtyNotifiedBagHours = 0;
                StringBuilder notifiedBagHours = new StringBuilder();

                if (!isProcessingNotifications)
                {
                    isProcessingNotifications = true;

                    IList<Dto.FEi_Notification> notifications = new Business.BFEi_Notifications().GetActiveNotifications();
                    IList<Dto.FEi_BagHours> baghours = new Business.BFEi_BagHours().GetBagActiveHours();

                    int intYears = 1;
                    IList<Tuple<DateTime, DateTime>> tTerms;

                    qtyNotifications = notifications.Count;
                    qtyBagHours = baghours.Count;
                    qtyNotifiedBagHours = 0;

                    notifiedBagHours.Append("[");

                    foreach (Dto.FEi_Notification notification in notifications)
                    {
                        foreach (Dto.FEi_BagHours bh in baghours)
                        {
                            if (this.ValidateBagHourAnuality(bh, out intYears, out tTerms))
                            {
                                DateTime currentdate = DateTime.Now;
                                Tuple<DateTime, DateTime> currentTerm = tTerms.Where(ee => currentdate > ee.Item1 && currentdate < ee.Item2).FirstOrDefault();

                                Dto.FEi_BagHours newBH = bh;
                                newBH.contract_start = currentTerm != null ? currentTerm.Item1 : bh.contract_start;
                                newBH.contract_end = currentTerm != null ? currentTerm.Item2 : bh.contract_end;
                                newBH.quantity = Convert.ToInt16(newBH.quantity.Value / intYears);

                                this.ProcessBagHourNotification(notification, newBH, qtyNotifiedBagHours, notifiedBagHours);
                            }
                            else
                            {
                                this.ProcessBagHourNotification(notification, bh, qtyNotifiedBagHours, notifiedBagHours);
                            }
                        }
                    }

                    notifiedBagHours.Append("]"); notifiedBagHours = notifiedBagHours.Replace("},", "}");

                    isProcessingNotifications = false;

                    return new Dto.FEi_NotificationSenderResponse()
                    {
                        EvaluatedBagHours = qtyBagHours,
                        EvaluatedNotifications = qtyNotifications,
                        NotifiedBagHours = qtyNotifiedBagHours,
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
                isProcessingNotifications = false;
                return new Dto.FEi_NotificationSenderResponse() { Message = "Se ha producido una excepción", Result = false, Error = ex.ToString() };
            }
        }

        private void ProcessBagHourNotification(Dto.FEi_Notification notification, Dto.FEi_BagHours bh, int QtyNotifiedBagHours, StringBuilder notifiedBagHours)
        {
            IList<Dto.IP_Tickets> contractTickets = new Business.IP_General().GetTicketsByContractId(bh.contract_id.Value, bh.contract_start.Value, bh.contract_end.Value);

            double totalSpendedHours = Math.Round(contractTickets.Sum(ee => ee.elapsedhours));
            double hoursPercentage = Math.Round((totalSpendedHours * 100) / bh.quantity.Value);

            double daysToContractExpiration = (bh.contract_end.Value - DateTime.Now.Date).TotalDays;

            if (daysToContractExpiration.Equals(notification.date_rule) | (hoursPercentage >= notification.hours_rule_lowest && hoursPercentage <= notification.hours_rule_highest))
            {
                Data.DFEi_NotifiedBagHours dataNB = new Data.DFEi_NotifiedBagHours();
                Data.DFEi_BagHours dataBH = new Data.DFEi_BagHours();

                Dto.FEi_NotifiedBagHours nbh = new Dto.FEi_NotifiedBagHours() { baghours_id = bh.id, notifications_id = notification.id };

                if (!dataNB.GetNotificationBagHourFlag(nbh))
                {
                    string messageBody = ReplaceNotificationData(notification, bh);
                    string notificationSubject = System.Configuration.ConfigurationManager.AppSettings["NotificationSubject"].ToString();
                    Tier.Transverse.Utilities.SendMail(notification.recipients, notificationSubject, messageBody);

                    QtyNotifiedBagHours++;
                    notifiedBagHours.Append("{\"Notification\":\"" + notification.id.ToString() + "\",\"BagHour\":\"" + bh.id + "\"},");
                    bh.status = bh.contract_end.Value < DateTime.Now ? (short)Dto.BagHoursStatus.Inactive : (short)Dto.BagHoursStatus.Notified;
                    bh.last_user_update = Dto.FEi_User.DefaultNotificationServiceUserId;

                    dataNB.Insert(nbh);
                    dataBH.Update(bh);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bh"></param>
        /// <param name="intYears"></param>
        /// <param name="tTerms"></param>
        /// <returns></returns>
        private bool ValidateBagHourAnuality(Dto.FEi_BagHours bh, out int intYears, out IList<Tuple<DateTime, DateTime>> tTerms)
        {
            IList<Tuple<DateTime, DateTime>> terms = new List<Tuple<DateTime, DateTime>>();

            DateTime zeroTime = new DateTime(1, 1, 1);
            TimeSpan span = bh.contract_end.Value - bh.contract_start.Value;

            intYears = (zeroTime + span).Year - 1;

            terms.Add(new Tuple<DateTime, DateTime>(bh.contract_start.Value, bh.contract_start.Value.AddYears(1)));

            for (int i = 1; i < intYears; i++)
            {
                terms.Add(new Tuple<DateTime, DateTime>(terms[i - 1].Item1.AddYears(1), terms[i - 1].Item2.AddYears(1)));
            }

            tTerms = terms;

            return intYears > 1;
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
            result = result.Replace("[[IDContrato]]", bh.contract_name.ToString());
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
