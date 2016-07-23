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
                    ? System.Configuration.ConfigurationManager.AppSettings["WindowsEventLogApplicationName"].ToString()
                    : "Front-End-Itop";
            }
        }
    }
}