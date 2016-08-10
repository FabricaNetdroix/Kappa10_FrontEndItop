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
                ).Distinct().ToList();

            ViewBag.organization_id = new SelectList(lstOrgs, "Key", "Value");
            ViewBag.contract_id = new SelectList(new List<KeyValuePair<int, string>>(), "Key", "Value");

            ViewBag.bagHoursList = new Business.BFEi_BagHours().GetAllBagHours();

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

                obj.last_user_update = 1;
                obj.status = (short)Dto.BagHoursStatus.Active;

                bool result = new Business.BFEi_BagHours().CreateBagHours(obj);

                if (result)
                {
                    return Json(new { result = true, message = Messages.Success, notificationType = "success" });
                }
                else
                {
                    return Json(new { result = false, message = Messages.Failure, notificationType = "error" });
                }
            }
            else
            {
                return Json(new { result = false, message = Messages.InvalidForm, notificationType = "notice" });
            }
        }

        public PartialViewResult GetAllBagHours()
        {
            IList<Dto.FEi_BagHours> lstBagHours = new Business.BFEi_BagHours().GetAllBagHours();

            return PartialView("_TableBagHours", lstBagHours);
        }

        [HttpPost]
        public JsonResult DeleteBagHours(int id)
        {
            Dto.FEi_BagHours obj = new Business.BFEi_BagHours().GetBagHoursById(id);

            if (new Business.BFEi_BagHours().DeleteBagHours(obj))
            {
                return Json(new { result = true, message = Messages.Success, notificationType = "success" });
            }
            else
            {
                return Json(new { result = false, message = Messages.Failure, notificationType = "error" });
            }
        }
    }
}