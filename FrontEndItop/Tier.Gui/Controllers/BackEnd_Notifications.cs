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
        public ActionResult Notifications()
        {
            ViewBag.notificationsList = new Business.BFEi_Notifications().GetAllNotification();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public JsonResult SaveNotification(Dto.FEi_Notification obj)
        {
            if (ModelState.IsValid)
            {
                obj.last_user_update = base.CurrentUser.id;
                obj.status = (short)Dto.NotificationStatus.Active;

                bool result = new Business.BFEi_Notifications().CreateNotification(obj);

                return GenerateJsonResult(result);
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
        public PartialViewResult GetAllNotifications()
        {
            IList<Dto.FEi_Notification> lstNotifications = new Business.BFEi_Notifications().GetAllNotification();

            return PartialView("_TableNotifications", lstNotifications);
        }

        [HttpPost]
        public JsonResult DeleteNotification(int id)
        {
            Dto.FEi_Notification obj = new Business.BFEi_Notifications().GetNotificationById(id);

            obj.last_user_update = base.CurrentUser.id;

            bool result = new Business.BFEi_Notifications().DeleteNotification(obj);

            return GenerateJsonResult(result);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult GetNotificationById(int id)
        {
            Dto.FEi_Notification obj = new Business.BFEi_Notifications().GetNotificationById(id);

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult EditNotification(int id)
        {
            Dto.FEi_Notification obj = new Business.BFEi_Notifications().GetNotificationById(id);

            return PartialView("_FormEditNotification", obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public JsonResult UpdateNotification(Dto.FEi_Notification obj)
        {
            Dto.FEi_Notification objDB = new Business.BFEi_Notifications().GetNotificationById((int)obj.id);

            objDB.date_rule = obj.date_rule;
            objDB.hours_rule_lowest = obj.hours_rule_lowest;
            objDB.hours_rule_highest = obj.hours_rule_highest;
            objDB.html_template = obj.html_template;
            objDB.notes = obj.notes;
            objDB.recipients = obj.recipients;

            obj.last_user_update = base.CurrentUser.id;

            bool result = new Business.BFEi_Notifications().UpdateNotification(objDB);

            return GenerateJsonResult(result);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult CreateNotification()
        {
            return PartialView("_FormCreateNotification");
        }

        public JsonResult SendNotifications()
        {
            Dto.FEi_NotificationSenderResponse response = new Business.BFEi_Notifications().SendNotifications();

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}