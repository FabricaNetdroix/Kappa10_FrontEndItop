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
        public ActionResult Users()
        {
            ViewBag.usersList = new Business.BFEi_Users().GetAllUsers();
            IList<KeyValuePair<byte, string>> lstRoles = Base.Utilities.GetRolesList().Where(ee => ee.Value != "Cliente").ToList();
            ViewBag.role = new SelectList(lstRoles, "Key", "Value");

            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult ValidateUserAlias(string alias, string initialalias, bool editando)
        {
            if (editando && alias.Equals(initialalias))
                return Json(true, JsonRequestBehavior.AllowGet);

            Dto.FEi_User objUserAlias = new Business.BFEi_Users().GetFiltered(new Dto.FEi_User() { alias = alias }).FirstOrDefault();
            if (objUserAlias == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult ValidatePasswords(string password, string passwordConfirm)
        {
            if (password.Equals(passwordConfirm))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveUser(Dto.FEi_User obj)
        {
            if (ModelState.IsValid)
            {
                obj.last_user_update = 1;
                obj.status = (short)Dto.UserStatus.Active;
                obj.password = Tier.Transverse.Crypto.GetMd5Hash(obj.password);

                bool result = new Business.BFEi_Users().CreateUser(obj);

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
        public PartialViewResult GetAllUsers()
        {
            IList<Dto.FEi_User> lstUsers = new Business.BFEi_Users().GetAllUsers();
            return PartialView("_TableUsers", lstUsers);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult EditUser(int id)
        {
            Dto.FEi_User obj = new Business.BFEi_Users().GetUserById(id);
            ViewBag.status = new SelectList(Utilities.GetUserStatusList(), "Key", "Value", obj.status);

            IList<KeyValuePair<byte, string>> lstRoles = Base.Utilities.GetRolesList().Where(ee => ee.Key != 0).ToList();
            ViewBag.role = new SelectList(lstRoles, "Key", "Value", obj.role);

            return PartialView("_FormEditUser", obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateUser(Dto.FEi_User obj)
        {
            Dto.FEi_User objDB = new Business.BFEi_Users().GetUserById((int)obj.id);
            objDB.alias = obj.alias;
            objDB.department = obj.department;
            objDB.email = obj.email;
            objDB.first_name = obj.first_name;
            objDB.last_name = obj.last_name;
            objDB.notes = obj.notes;
            objDB.role = obj.role;
            objDB.status = obj.status;
            objDB.password = Tier.Transverse.Crypto.GetMd5Hash(obj.password);
            obj.last_user_update = 1;

            bool result = new Business.BFEi_Users().UpdateUser(objDB);

            return GenerateJsonResult(result);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public PartialViewResult CreateUsers()
        {
            IList<KeyValuePair<byte, string>> lstRoles = Base.Utilities.GetRolesList().Where(ee => ee.Value != "Cliente").ToList();
            ViewBag.role = new SelectList(lstRoles, "Key", "Value");
            return PartialView("_FormCreateUsers");
        }

        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            Dto.FEi_User obj = new Business.BFEi_Users().GetUserById(id);

            obj.last_user_update = 1;

            bool result = new Business.BFEi_Users().DeleteUser(obj);

            return GenerateJsonResult(result);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult GetUserById(int id)
        {
            Dto.FEi_User obj = new Business.BFEi_Users().GetUserById(id);

            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}