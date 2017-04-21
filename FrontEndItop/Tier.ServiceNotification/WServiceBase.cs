using System.Runtime.InteropServices;

namespace Tier.ServiceNotification
{
    /// <summary>
    /// 
    /// </summary>
    internal class WServiceBase
    {
        public const double DetaultIntervalMinutes = 60;
        public const double MollisecondsPerMinute = 60000;
        public const long DwWaitHint = 360000;

        /// <summary>
        /// 
        /// </summary>
        public enum ApplicationEventIds
        {
            Setup = 100,
            Core = 200
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public long dwServiceType;
            public ServiceState dwCurrentState;
            public long dwControlsAccepted;
            public long dwWin32ExitCode;
            public long dwServiceSpecificExitCode;
            public long dwCheckPoint;
            public long dwWaitHint;
        };
    }
}
