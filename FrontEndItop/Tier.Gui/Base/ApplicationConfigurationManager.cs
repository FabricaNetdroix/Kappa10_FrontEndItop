using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Tier.Gui.Base
{
    public static class ApplicationConfigurationManager
    {
        #region [Properties]
        public static string WindowsEventLogApplicationName
        {
            get
            {
                return string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["WindowsEventLogApplicationName"].ToString())
                    ? "Portal Clientes KAPPA10"
                    : System.Configuration.ConfigurationManager.AppSettings["WindowsEventLogApplicationName"].ToString();
            }
        }

        public static string ApplicationName
        {
            get
            {
                return string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ApplicationName"].ToString())
                    ? "Portal Clientes KAPPA10"
                    : System.Configuration.ConfigurationManager.AppSettings["ApplicationName"].ToString();
            }
        }

        public static string reCAPTCHA_SiteKey
        {
            get
            {
                return string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["reCAPTCHA_SiteKey"].ToString())
                    ? "undefined"
                    : System.Configuration.ConfigurationManager.AppSettings["reCAPTCHA_SiteKey"].ToString();
            }
        }

        public static string reCAPTCHA_SecretKey
        {
            get
            {
                return string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["reCAPTCHA_SecretKey"].ToString())
                    ? "undefined"
                    : System.Configuration.ConfigurationManager.AppSettings["reCAPTCHA_SecretKey"].ToString();
            }
        }

        public static string reCAPTCHA_Url
        {
            get
            {
                return string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["reCAPTCHA_Url"].ToString())
                    ? "undefined"
                    : System.Configuration.ConfigurationManager.AppSettings["reCAPTCHA_Url"].ToString();
            }
        }
        #endregion

        #region [Public Methods]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="appFunctionality"></param>
        /// <returns></returns>
        public static bool ValidateRolePermission(Dto.UserTypes userType, Base.Enumerations.ApplicationModules appFunctionality)
        {
            string rolePermissionString = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Assets/json/RolePermission.json"));
            Newtonsoft.Json.Linq.JArray jsonArray = Newtonsoft.Json.Linq.JArray.Parse(rolePermissionString);

            if (jsonArray.Count <= 0)
                return false;

            var rolePermissionList = jsonArray.Select(ee => new
            {
                role = ((dynamic)ee).role,
                func = ((dynamic)ee).func
            }).ToList();

            return rolePermissionList.Where(ee => ee.role == (byte)userType && ee.func == (byte)appFunctionality).Count() > 0;
        }
        #endregion
    }
}