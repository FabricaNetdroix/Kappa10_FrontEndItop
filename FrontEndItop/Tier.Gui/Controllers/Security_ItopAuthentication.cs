using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class FrontEndController : BaseController
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class ItopAuth
    {
        #region [Fields]
        private short code;
        private string message;
        private bool authorized;
        #endregion

        #region [Properties]
        [JsonProperty("code")]
        public short Code
        {
            get { return code; }
            set { code = value; }
        }

        [JsonProperty("message")]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        [JsonProperty("authorized")]
        public bool Authorized
        {
            get { return authorized; }
            set { authorized = value; }
        }
        #endregion

        public static bool Validate(string userLogin, string userPassword)
        {
            string apiUrl = System.Configuration.ConfigurationManager.AppSettings.Get("iTopAPIAuth_Url");
            string apiUser = System.Configuration.ConfigurationManager.AppSettings.Get("iTopAPIAuth_User");
            string apiPass = System.Configuration.ConfigurationManager.AppSettings.Get("iTopAPIAuth_Pass");
            string jsonData = string.Format(System.Configuration.ConfigurationManager.AppSettings.Get("iTopAPIAuth_JsonData"), userLogin, userPassword);

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                NameValueCollection myNameValueCollection = new NameValueCollection();
                myNameValueCollection.Add("auth_user", apiUser);
                myNameValueCollection.Add("auth_pwd", apiPass);
                myNameValueCollection.Add("json_data", jsonData);

                byte[] responseArray = client.UploadValues(apiUrl, myNameValueCollection);
                var iTopAPIReply = System.Text.Encoding.ASCII.GetString(responseArray);
                var iTopAPIResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ItopAuth>(iTopAPIReply);
                return iTopAPIResponse.authorized;
            }
        }
    }
}