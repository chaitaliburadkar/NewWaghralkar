using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWaghralkar.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult Books()
        {
            return View();
        }
    }
}