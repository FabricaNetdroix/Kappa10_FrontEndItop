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

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string txtUserAlias, string txtUserPassword, byte ddlUserType)
        {
            if (ddlUserType == 0)
            {
                return RedirectToAction("Index", "FrontEnd");
            }
            else
            {
                return RedirectToAction("Index", "BackEnd");
            }
        }
    }
}