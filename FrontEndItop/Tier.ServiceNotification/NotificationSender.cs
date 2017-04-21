using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace Tier.ServiceNotification
{
    public partial class NotificationSender : ServiceBase
    {
        private System.Timers.Timer timer;

        public NotificationSender()
        {
            InitializeComponent();
            InitializeEventLog();
            InitializeTimer();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeEventLog()
        {
            eventLog = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("NotificationSender.Source"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "NotificationSender.Source", "NotificationSender.Log");
            }
            eventLog.Source = "NotificationSender.Source";
            eventLog.Log = "NotificationSender.Log";

        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeTimer()
        {
            double notificationIntervalMinutes;
            double.TryParse(System.Configuration.ConfigurationManager.AppSettings["NotificationIntervalMinutes"], out notificationIntervalMinutes);
            notificationIntervalMinutes = (notificationIntervalMinutes > 0 ? notificationIntervalMinutes : WServiceBase.DetaultIntervalMinutes) * WServiceBase.MollisecondsPerMinute;

            this.timer = new System.Timers.Timer(notificationIntervalMinutes);
            this.timer.AutoReset = true;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            eventLog.WriteEntry(string.Format("Se inicia el procesamiento de las notificaciones según programación en: {0}", DateTime.Now), EventLogEntryType.Information, (int)WServiceBase.ApplicationEventIds.Core);
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(IntPtr handle, ref WServiceBase.ServiceStatus serviceStatus);

        protected override void OnStart(string[] args)
        {
            WServiceBase.ServiceStatus serviceStatus = new WServiceBase.ServiceStatus();
            serviceStatus.dwCurrentState = WServiceBase.ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = WServiceBase.DwWaitHint;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            timer.Start();

            eventLog.WriteEntry(string.Format("Servicio de envío de notificaciones ha iniciado su ejecución en: {0}", DateTime.Now), EventLogEntryType.Information, (int)WServiceBase.ApplicationEventIds.Setup);

            serviceStatus.dwCurrentState = WServiceBase.ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnStop()
        {
            WServiceBase.ServiceStatus serviceStatus = new WServiceBase.ServiceStatus();
            serviceStatus.dwCurrentState = WServiceBase.ServiceState.SERVICE_STOP_PENDING;
            serviceStatus.dwWaitHint = WServiceBase.DwWaitHint;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            timer.Stop();
            eventLog.WriteEntry(string.Format("Servicio de envío de notificaciones ha detenido su ejecución en: {0}", DateTime.Now), EventLogEntryType.Warning, (int)WServiceBase.ApplicationEventIds.Setup);

            serviceStatus.dwCurrentState = WServiceBase.ServiceState.SERVICE_STOPPED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnPause()
        {
            WServiceBase.ServiceStatus serviceStatus = new WServiceBase.ServiceStatus();
            serviceStatus.dwCurrentState = WServiceBase.ServiceState.SERVICE_PAUSE_PENDING;
            serviceStatus.dwWaitHint = WServiceBase.DwWaitHint;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            base.OnPause();
            timer.Stop();
            eventLog.WriteEntry(string.Format("Servicio de envío de notificaciones ha suspendido su ejecución en: {0}", DateTime.Now), EventLogEntryType.Warning, (int)WServiceBase.ApplicationEventIds.Setup);

            serviceStatus.dwCurrentState = WServiceBase.ServiceState.SERVICE_PAUSED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnContinue()
        {
            WServiceBase.ServiceStatus serviceStatus = new WServiceBase.ServiceStatus();
            serviceStatus.dwCurrentState = WServiceBase.ServiceState.SERVICE_CONTINUE_PENDING;
            serviceStatus.dwWaitHint = WServiceBase.DwWaitHint;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            base.OnContinue();
            timer.Start();
            eventLog.WriteEntry(string.Format("Servicio de envío de notificaciones ha reanudado su ejecución en: {0}", DateTime.Now), EventLogEntryType.Information, (int)WServiceBase.ApplicationEventIds.Setup);

            serviceStatus.dwCurrentState = WServiceBase.ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }
    }
}
