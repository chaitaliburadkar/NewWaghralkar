using NewWaghralkar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWaghralkar.Controllers
{
    public class GallaryController : Controller
    {
        // GET: Gallary
        public ActionResult PhotoGallary()
        {
            return View();
        }
        public ActionResult VideoGallary()
        {
            return View();
        }
        public ActionResult Event()
        {
            return View();
        }
        public ActionResult PaperCutting()
        {
            return View();
        }
        public ActionResult GetGallaryList()
        {
            try
            {
                return Json(new { model = (new GallaryModel().GetGallaryList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
