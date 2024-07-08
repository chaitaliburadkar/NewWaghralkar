using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWaghralkar.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult AboutIndex()
        {
            return View();
        }
        public ActionResult AboutHospital()
        {
            
            return View();
        }
        public ActionResult Panchkarma()
        {
            return View();
        }
        public ActionResult Ayurveda()
        {
            return View();
        }
    }
}