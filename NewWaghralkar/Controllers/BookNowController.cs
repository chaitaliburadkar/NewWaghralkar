using NewWaghralkar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWaghralkar.Controllers
{
    public class BookNowController : Controller
    {
        // GET: BookNow
        public ActionResult BookNowIndex()
        {
            return View();
        }
        public ActionResult Savereg(BookNowModel model)
        {
            try

            {
                return Json(new { Message = new BookNowModel().Savereg(model) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)

            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}