using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public class FrontEndController : BaseController
    {
        //
        // GET: /FrontEnd/
        public ActionResult Index()
        {
            // Recuperamos los contratos a los que está asociado el usuario.
            ViewBag.lstContratos = new Business.IP_General().GetProductionContractsByLogin(base.CurrentUser.alias);

            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult DetalleConsumo(int id)
        {
            ViewBag.BagHours = new Business.BFEi_BagHours().GetBagHoursByContractId(id);
            return PartialView("_ConsumptionDetail");
        }
    }
}