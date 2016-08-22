using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tier.Gui.Base;

namespace Tier.Gui.Controllers
{
    public partial class BackEndController : BaseController
    {
        public ActionResult BagHours()
        {
            IList<Dto.IP_Contract> lstContracts = new Business.IP_General().GetProductionContracts();

            List<KeyValuePair<int, string>> lstOrgs = lstContracts.Select(
                ee => new KeyValuePair<int, string>(ee.org_id.Value, ee.organization_name)
                ).Distinct().ToList();

            ViewBag.organization_id = new SelectList(lstOrgs, "Key", "Value");
            ViewBag.contract_id = new SelectList(new List<KeyValuePair<int, string>>(), "Key", "Value");

            ViewBag.bagHoursList = new Business.BFEi_BagHours().GetAllBagHours();

            return View(new Dto.FEi_BagHours());
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult GetContractByOrganization(int id)
        {
            IList<Dto.IP_Contract> lstContracts = new Business.IP_General().GetProductionContracts();
            SelectList sl = new SelectList(lstContracts.Where(ee => ee.org_id == id).ToList(), "id", "name");

            return Json(sl, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult GetContractInfoById(int id)
        {
            IList<Dto.IP_Contract> lstContracts = new Business.IP_General().GetProductionContracts();
            Dto.IP_Contract obj = lstContracts.Where(ee => ee.id == id).FirstOrDefault();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveBagHours(Dto.FEi_BagHours obj)
        {
            if (ModelState.IsValid)
            {
                IList<Dto.IP_Contract> lstContracts = new Business.IP_General().GetProductionContracts();
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
                    return Json(new
                    {
                        result = true,
                        notificationMessage = Messages.NotificationTextSuccess,
                        notificationType = Enumerations.NotificationTypes.success.ToString(),
                        notificationTitle = Messages.NotificationTitleSuccess
                    });
                }
                else
                {
                    return Json(new
                    {
                        result = false,
                        notificationMessage = Messages.NotificationTextFailure,
                        notificationType = Enumerations.NotificationTypes.error.ToString(),
                        notificationTitle = Messages.NotificationTitleError
                    });
                }
            }
            else
            {
                return Json(new
                {
                    result = false,
                    notificationMessage = Messages.InvalidForm,
                    notificationType = Enumerations.NotificationTypes.notice.ToString(),
                    notificationTitle = Messages.NotificationTitleWarning
                });
            }
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult GetAllBagHours()
        {
            IList<Dto.FEi_BagHours> lstBagHours = new Business.BFEi_BagHours().GetAllBagHours();

            return PartialView("_TableBagHours", lstBagHours);
        }

        [HttpPost]
        public JsonResult DeleteBagHours(int id)
        {
            Dto.FEi_BagHours obj = new Business.BFEi_BagHours().GetBagHoursById(id);
            
            obj.last_user_update = 1;

            if (new Business.BFEi_BagHours().DeleteBagHours(obj))
            {
                return Json(new
                {
                    result = true,
                    notificationMessage = Messages.NotificationTextSuccess,
                    notificationType = Enumerations.NotificationTypes.success.ToString(),
                    notificationTitle = Messages.NotificationTitleSuccess
                });
            }
            else
            {
                return Json(new
                {
                    result = false,
                    notificationMessage = Messages.NotificationTextFailure,
                    notificationType = Enumerations.NotificationTypes.error.ToString(),
                    notificationTitle = Messages.NotificationTitleError
                });
            }
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult ExistBagHoursToContract(int id)
        {
            Dto.FEi_BagHours obj = new Business.BFEi_BagHours().GetBagHoursByContractId(id);

            if (obj == null)
            {
                return Json(new
                {
                    result = true,
                    notificationMessage = Messages.NotificationTextSuccess,
                    notificationType = Enumerations.NotificationTypes.success.ToString(),
                    notificationTitle = Messages.NotificationTitleSuccess
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    result = false,
                    notificationMessage = Messages.UniqueContractConstraint,
                    notificationType = Enumerations.NotificationTypes.notice.ToString(),
                    notificationTitle = Messages.NotificationTitleWarning
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult GetBagHoursById(int id)
        {
            Dto.FEi_BagHours obj = new Business.BFEi_BagHours().GetBagHoursById(id);

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult EditBagHours(int id)
        {
            Dto.FEi_BagHours obj = new Business.BFEi_BagHours().GetBagHoursById(id);

            IList<Dto.IP_Contract> lstContracts = new Business.IP_General().GetProductionContracts();

            List<KeyValuePair<int, string>> lstOrgs = lstContracts.Select(
                            ee => new KeyValuePair<int, string>(ee.org_id.Value, ee.organization_name)
                            ).Distinct().ToList();

            ViewBag.organization_id = new SelectList(lstOrgs, "Key", "Value", obj.organization_id);
            ViewBag.contract_id = new SelectList(lstContracts.Where(ee => ee.org_id == obj.organization_id).ToList(), "id", "name", obj.contract_id);

            return PartialView("_FormEditBagHours", obj);
        }

        [HttpPost]
        public JsonResult UpdateBagHours(Dto.FEi_BagHours obj)
        {
            Dto.FEi_BagHours objDB = new Business.BFEi_BagHours().GetBagHoursById((int)obj.id);

            objDB.quantity = obj.quantity;
            objDB.notes = obj.notes;
            objDB.is_warranty = obj.is_warranty;
            obj.last_user_update = 1;

            bool result = new Business.BFEi_BagHours().UpdateBagHours(objDB);

            if (result)
            {
                return Json(new
                {
                    result = true,
                    notificationMessage = Messages.NotificationTextSuccess,
                    notificationType = Enumerations.NotificationTypes.success.ToString(),
                    notificationTitle = Messages.NotificationTitleSuccess
                });
            }
            else
            {
                return Json(new
                {
                    result = false,
                    notificationMessage = Messages.NotificationTextFailure,
                    notificationType = Enumerations.NotificationTypes.error.ToString(),
                    notificationTitle = Messages.NotificationTitleError
                });
            }
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult CreateBagHours()
        {
            IList<Dto.IP_Contract> lstContracts = new Business.IP_General().GetProductionContracts();

            List<KeyValuePair<int, string>> lstOrgs = lstContracts.Select(
                ee => new KeyValuePair<int, string>(ee.org_id.Value, ee.organization_name)
                ).Distinct().ToList();

            ViewBag.organization_id = new SelectList(lstOrgs, "Key", "Value");
            ViewBag.contract_id = new SelectList(new List<KeyValuePair<int, string>>(), "Key", "Value");

            return PartialView("_FormCreateBagHours");
        }
    }
}