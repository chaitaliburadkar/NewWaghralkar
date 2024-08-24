using NewWaghralkar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWaghralkar.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult RegistrationIndex()
        {
            return View();
        }
        public ActionResult SaveForm(RegistrationModel model)
        {
            try
            {
                return Json(new { Message = new RegistrationModel().SaveForm(model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}