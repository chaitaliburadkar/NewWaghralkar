using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWaghralkar.Controllers
{
    public class AwardsController : Controller
    {
        // GET: Awards
        public ActionResult AwardsIndex()
        {
            return View();
        }
    }
}