using NewWaghralkar.Data;
using NewWaghralkar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NewWaghralkar.Controllers
{
    public class MultiuserController : Controller
    {
        // GET: Multiuser
        public ActionResult MultiuserIndex()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult UserLogin(RegistrationModel objuser)
        {
            if (ModelState.IsValid)
            {
                using (WaghralkarEntities db = new WaghralkarEntities())

                {

                    var obj = db.Registrations.Where(a => a.Email.Equals(objuser.Email) &&
                   a.Password.Equals(objuser.Password)).FirstOrDefault();
                    if (obj != null)
                    {

                        Session["Email"] = obj.Email.ToString();
                        Session["Password"] = obj.Password.ToString();
                        return RedirectToAction("UserDashBoard");

                    }
                }
            }

            return RedirectToAction("LoginIndex", "Multiuser");

        }
        public ActionResult UserDashBoard()
        {
            if (Session["Password"] != null)
            {
                ViewBag.Id = Session["Id"];
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("LoginIndex", " Multiuser");
            }
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("LoginIndex", "Multiuser");
        }
    }
}
    