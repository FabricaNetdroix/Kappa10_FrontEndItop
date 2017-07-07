using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class FrontEndController : BaseController
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
            Dto.FEi_BagHours bh = new Business.BFEi_BagHours().GetBagHoursByContractId(id);
            IList<Dto.IP_Tickets> tks = new Business.IP_General().GetTicketsByContractId(id, bh.contract_start.Value, bh.contract_end.Value);
            ViewBag.BagHours = bh;
            ViewBag.Tickets = tks;

            var hContratadas = (bh != null ? bh.quantity : 0);
            var hConsumidas = tks.Sum(ee => ee.elapsedhours);
            var hDisponibles = hContratadas - hConsumidas;

            ViewBag.IndicadorHorasContratadas = hContratadas;
            ViewBag.IndicadorHorasConsumidas = hConsumidas;
            ViewBag.IndicadorHorasDisponibles = hDisponibles;

            return PartialView("_ConsumptionDetail");
        }

        public PartialViewResult GetTicketInfoById(int id)
        {
            Dto.IP_Tickets objTk = new Business.IP_General().GetTicketById(id);
            return PartialView("_ModalTicketDetail", objTk);
        }
    }
}