using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class BackEndController : BaseController
    {
        public ActionResult BagHours()
        {
            IList<Dto.IP_Contract> lstContracts = new Business.BItopPlatform().GetProductionContracts();
            List<KeyValuePair<int, string>> lstOrgs = lstContracts.Select(
                ee => new KeyValuePair<int, string>(ee.org_id.Value, ee.organization_name)
                ).ToList();

            ViewBag.organization_id = new SelectList(lstOrgs, "Key", "Value");
            ViewBag.contract_id = new SelectList(new List<KeyValuePair<int, string>>(), "Key", "Value");

            return View(new Dto.FEi_BagHours());
        }

        public JsonResult GetContractByOrganization(int organizationId)
        {
            IList<Dto.IP_Contract> lstContracts = new Business.BItopPlatform().GetProductionContracts();
            SelectList sl = new SelectList(lstContracts.Where(ee => ee.org_id == organizationId).ToList(), "id", "name");

            return Json(sl, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetContractInfoById(int contractId)
        {
            IList<Dto.IP_Contract> lstContracts = new Business.BItopPlatform().GetProductionContracts();
            Dto.IP_Contract obj = lstContracts.Where(ee => ee.id == contractId).FirstOrDefault();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveBagHours(Dto.FEi_BagHours obj)
        {
            if (ModelState.IsValid)
            {
                IList<Dto.IP_Contract> lstContracts = new Business.BItopPlatform().GetProductionContracts();
                Dto.IP_Contract objIPC = lstContracts.Where(ee => ee.id == obj.contract_id).FirstOrDefault();

                obj.contract_name = objIPC.name;
                obj.organization_name = objIPC.organization_name;
                obj.contract_start = objIPC.start_date;
                obj.contract_end = objIPC.end_date;

                return Json(new { result = true, message = Messages.Success, notificationType = "success" });
            }
            else
            {
                return Json(new { result = false, message = Messages.InvalidForm, notificationType = "notice" });
            }
        }
    }
}