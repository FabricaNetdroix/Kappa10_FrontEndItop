﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Tier.Gui.Base;

namespace Tier.Gui.Controllers
{
    public class BaseController : Controller
    {
        internal Dto.FEi_User CurrentUser
        {
            get
            {
                return (Dto.FEi_User)Session["CurrentUser"];
            }

            set { Session["CurrentUser"] = value; }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool blnSaltarAutorizacion = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);

            if (this.CurrentUser != null || blnSaltarAutorizacion)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "Security" },
                    { "action", "LogIn" },
                    { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                });
            }
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            string modulo = Logs.GetControllerName(filterContext.Controller.ToString());

            Logs.Error(filterContext.Exception, modulo);
            base.OnException(filterContext);
        }

        /// <summary>
        /// Registra en la variable temporal "MostrarNotificacion" tempdata los datos de una notificación a mostar del lado del cliente.
        /// </summary>
        /// <param name="Mensaje">Texto a mostar en la notificación</param>
        /// <param name="Tipo">Tipo de la notificación (Exitosa, Error, Advertencia ...)</param>
        /// <param name="Titulo">Titulo a mostar en la notificación</param>
        protected void RegistrarNotificación(string Mensaje, Base.Enumerations.NotificationTypes Tipo, string Titulo)
        {
            TempData["MostrarNotificacion"] = new HtmlString("{" + string.Format("\"notificationMessage\":\"{0}\",\"notificationType\":\"{1}\",\"notificationTitle\":\"{2}\"", Mensaje, Tipo, Titulo) + "}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected JsonResult GenerateJsonResult(bool result)
        {
            if (result)
            {
                return Json(new
                {
                    result = true,
                    notificationMessage = Messages.NotificationTextSuccess,
                    notificationType = Enumerations.NotificationTypes.success.ToString(),
                    notificationTitle = Messages.NotificationTitleSuccess
                });
            }
            else
            {
                return Json(new
                {
                    result = false,
                    notificationMessage = Messages.NotificationTextFailure,
                    notificationType = Enumerations.NotificationTypes.error.ToString(),
                    notificationTitle = Messages.NotificationTitleError
                });
            }
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
            string entryText = string.Format("{0}|{1}|{2}|{3}",
                 DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), type, module, message);

            System.Diagnostics.Trace.WriteLine(entryText);
        }
        #endregion
    }
}