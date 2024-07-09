using NewWaghralkar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWaghralkar.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveAppointment(AppointmentModel model)
        {
            try
            {
                return Json(new { Message = new AppointmentModel().SaveAppointment(model) }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json( new {model = ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}