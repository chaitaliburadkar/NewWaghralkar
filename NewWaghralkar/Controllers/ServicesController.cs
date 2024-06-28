using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWaghralkar.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult Treatments()
        {
            return View();
        }
        public ActionResult HospitalServices()
        {
            return View();
        }
        public ActionResult Training()
        {
            return View();
        }
        public ActionResult MusicAromaTherapy()
        {
            return View();
        }
        public ActionResult QuantumHealing()
        {
            return View();
        }
    }
}