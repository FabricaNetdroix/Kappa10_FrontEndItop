using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            System.Diagnostics.Debugger.Break();

            string modulo = Logs.GetControllerName(filterContext.Controller.ToString());

            Logs.Error(filterContext.Exception, modulo);
            base.OnException(filterContext);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class Logs
    {
        #region [Logs]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContextController"></param>
        public static string GetControllerName(string filterContextController)
        {
            string result = string.Empty;

            string[] arr = filterContextController.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            result = arr.Where(ee => ee.Contains("Controller")).LastOrDefault().Replace("Controller", string.Empty);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="module"></param>
        public static void Error(Exception ex, string module)
        {
            WriteEntry(ex.ToString(), System.Diagnostics.EventLogEntryType.Error, module);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="module"></param>
        public static void Warning(string message, string module)
        {
            WriteEntry(message, System.Diagnostics.EventLogEntryType.Warning, module);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="module"></param>
        public static void Info(string message, string module)
        {
            WriteEntry(message, System.Diagnostics.EventLogEntryType.Information, module);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="module"></param>
        private static void WriteEntry(string message, System.Diagnostics.EventLogEntryType type, string module)
        {
            System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();
            appLog.Source = Base.ApplicationConfigurationManager.WindowsEventLogApplicationName;
            appLog.WriteEntry(message, type);
        }
        #endregion
    }
}