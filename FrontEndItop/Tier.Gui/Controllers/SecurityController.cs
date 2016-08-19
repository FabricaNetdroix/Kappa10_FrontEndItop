﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class SecurityController : BaseController
    {
        //
        // GET: /Security/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SingOut()
        {
            Session.Abandon();
            return RedirectToAction("LogIn", "Security");
        }

        /// <summary>
        /// Carga las lista desplegables del formulario.
        /// </summary>
        private void LoadFormLists()
        {
            ViewBag.UserType = new SelectList(Base.Utilities.GetRolesList(), "Key", "Value");
        }

        public ActionResult LogIn()
        {
            Session.Abandon();

            this.LoadFormLists();
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.LoginModel obj)
        {
            if (ModelState.IsValid)
            {
                //Se recupera y valida la respuesta del servicio de Google reCaptcha.
                obj.RecaptchaToken = Request["g-Recaptcha-Response"].ToString();
                bool IsCaptchaValid = (ReCaptchaClass.Validate(obj.RecaptchaToken) == "True" ? true : false);

                if (IsCaptchaValid)
                {
                    if (obj.UserType == (byte)Dto.UserTypes.Costumer)
                    {
                        // Validar usuario iTop
                        if (true)
                        {
                            return RedirectToAction("Index", "FrontEnd");
                        }
                        else
                        {
                            base.RegistrarNotificación(Messages.UserAutenticationFailure, Base.Enumerations.NotificationTypes.error, Messages.NotificationTitleError);
                            return RedirectToAction("LogIn", "Security");
                        }
                    }
                    else
                    {
                        // Validar usuario App
                        Dto.FEi_User objUser = new Business.BFEi_Users().GetUserByCredentials(obj.UserAlias, obj.UserPassword, (Dto.UserTypes)obj.UserType);

                        if (objUser != null && objUser.status == (short)Dto.UserStatus.Active)
                        {
                            if (obj.UserType == (byte)Dto.UserTypes.Vendor)
                            {
                                return RedirectToAction("BagHours", "BackEnd");
                            }
                            else if (obj.UserType == (byte)Dto.UserTypes.Administrator)
                            {
                                return RedirectToAction("Index", "BackEnd");
                            }
                            else
                            {
                                base.RegistrarNotificación(Messages.UnknownProfile, Base.Enumerations.NotificationTypes.error, Messages.NotificationTitleError);
                                return RedirectToAction("LogIn", "Security");
                            }
                        }
                        else
                        {
                            base.RegistrarNotificación(Messages.UserAutenticationFailure, Base.Enumerations.NotificationTypes.error, Messages.NotificationTitleError);
                            return RedirectToAction("LogIn", "Security");
                        }
                    }
                }
                else
                {
                    // Validación Captcha no superada
                    base.RegistrarNotificación(Messages.CaptchaValidationFailure, Base.Enumerations.NotificationTypes.error, Messages.NotificationTitleError);
                    this.LoadFormLists();
                    return View(obj);
                }
            }
            else
            {
                // Datos no diligenciados correctamente.
                base.RegistrarNotificación(Messages.InvalidForm, Base.Enumerations.NotificationTypes.notice, Messages.NotificationTitleWarning);
                this.LoadFormLists();
                return View(obj);
            }
        }
    }

    /// <summary>
    /// Clase para la validación del captcha del servicio de Google reCaptcha.
    /// </summary>
    public class ReCaptchaClass
    {
        /// <summary>
        /// Solicita la respuesta de la validación del captcha.
        /// </summary>
        /// <param name="EncodedResponse">Token "Recaptcha-Response" recibido en el Request</param>
        /// <returns>Cadena de texto True o False recibida del servicio de Google</returns>
        public static string Validate(string EncodedResponse)
        {
            var client = new System.Net.WebClient();

            string PrivateKey = Base.ApplicationConfigurationManager.reCAPTCHA_SecretKey;

            var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", PrivateKey, EncodedResponse));

            var captchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptchaClass>(GoogleReply);

            return captchaResponse.Success;
        }

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private string m_Success;
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }

        private List<string> m_ErrorCodes;
    }
}