﻿using System;
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
    }
}