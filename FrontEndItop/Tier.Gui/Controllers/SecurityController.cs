using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class SecurityController : BaseController
    {
        [AllowAnonymous]
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

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            Session.Abandon();

            this.LoadFormLists();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(Models.LoginModel obj)
        {
            if (ModelState.IsValid)
            {
                //Se recupera y valida la respuesta del servicio de Google reCaptcha.
                obj.RecaptchaToken = Request["g-Recaptcha-Response"].ToString();
                bool IsCaptchaValid = (ReCaptchaClass.Validate(obj.RecaptchaToken).ToLower() == "true" ? true : false);

                if (IsCaptchaValid)
                {
                    obj.UserAlias = Tier.Transverse.Utilities.GetStringFromBase64(obj.UserAlias);
                    obj.UserPassword = Tier.Transverse.Utilities.GetStringFromBase64(obj.UserPassword);

                    if (obj.UserType == (byte)Dto.UserTypes.Costumer)
                    {
                        // Validar usuario iTop
                        if (ItopAuth.Validate(obj.UserAlias, obj.UserPassword))
                        {
                            base.CurrentUser = new Dto.FEi_User() { alias = obj.UserAlias, password = obj.UserPassword, role = obj.UserType };
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
                            //Cargar datos usuario
                            base.CurrentUser = objUser;
                            return RedirectToAction("Index", "BackEnd");
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
                    return RedirectToAction("LogIn", "Security");
                }
            }
            else
            {
                // Datos no diligenciados correctamente.
                base.RegistrarNotificación(Messages.InvalidForm, Base.Enumerations.NotificationTypes.notice, Messages.NotificationTitleWarning);
                return RedirectToAction("LogIn", "Security");
            }
        }
    }
}