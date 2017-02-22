using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.Controllers
{
    /// <summary>
    /// Clase para la validación del captcha del servicio de Google reCaptcha.
    /// </summary>
    public class ReCaptchaClass
    {
        #region [Fields]
        private string m_Success;
        private List<string> m_ErrorCodes;
        #endregion

        #region [Properties]
        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }
        #endregion

        /// <summary>
        /// Solicita la respuesta de la validación del captcha.
        /// </summary>
        /// <param name="EncodedResponse">Token "Recaptcha-Response" recibido en el Request</param>
        /// <returns>Cadena de texto True o False recibida del servicio de Google</returns>
        public static string Validate(string EncodedResponse)
        {
            string PrivateKey = Base.ApplicationConfigurationManager.reCAPTCHA_SecretKey;

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                var GoogleReply = client.DownloadString(string.Format(Base.ApplicationConfigurationManager.reCAPTCHA_Url, PrivateKey, EncodedResponse));
                var captchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptchaClass>(GoogleReply);
                return captchaResponse.Success;
            }
        }
    }
}