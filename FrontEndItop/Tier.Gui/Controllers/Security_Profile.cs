using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class SecurityController : BaseController
    {
        public ActionResult SelfManagement()
        {
            return View();
        }
    }
}