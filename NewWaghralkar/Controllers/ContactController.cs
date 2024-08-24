using NewWaghralkar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWaghralkar.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult ContactIndex()
        {
            return View();
        }
        public ActionResult Savereg(ContactModel model)
        {
            try

            {
                return Json(new { Message = new ContactModel().Savereg(model) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}