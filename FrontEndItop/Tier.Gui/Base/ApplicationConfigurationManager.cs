using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.Base
{
    public class ApplicationConfigurationManager
    {
        public static string WindowsEventLogApplicationName
        {
            get
            {
                return string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["WindowsEventLogApplicationName"].ToString())
                    ? "Front-End-Itop"
                    : System.Configuration.ConfigurationManager.AppSettings["WindowsEventLogApplicationName"].ToString();
            }
        }

        public static string ApplicationName
        {
            get
            {
                return string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ApplicationName"].ToString())
                    ? "FrontEnd-Itop"
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
    }
}