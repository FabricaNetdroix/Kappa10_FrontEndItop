using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class BackEndController : BaseController
    {
        //
        // GET: /BackEnd/
        public ActionResult Index()
        {
            Dto.FEi_RoleDashboard dashboardInfo = new Business.BFEi_RoleDashboard().GetRoleDashboard(base.CurrentUser.role.Value);
            ViewBag.UserRole = base.CurrentUser.role.Value;

            return View(dashboardInfo);
        }
    }
}