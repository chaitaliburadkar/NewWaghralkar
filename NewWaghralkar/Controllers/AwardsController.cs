using NewWaghralkar.Models;
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
        public ActionResult AddAwardsIndex()
        {
            return View();
        }
        public ActionResult AwardsDetailsIndex(int ActivityId)
        {
            ViewBag.ActivityId = ActivityId;
            return View();
        }

        public ActionResult SaveReg(AwardsModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }
                return Json(new { Message = (new AwardsModel().SaveReg(fb, model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetAwardsList(AwardsModel model)
        {
            try
            {
                return Json(new { model = (new AwardsModel().GetAwardsList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteAwards(int ActivityId)
        {
            try
            {
                return Json(new { model = new AwardsModel().DeleteAwards(ActivityId) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetAwardsDetailById(int ActivityId)
        {
            try
            {
                return Json(new { model = new AwardsModel().GetAwardsDetailById(ActivityId) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetSearchList(string Name)
        {
            try
            {
                return Json(new { model = (new AwardsModel().GetSearchList(Name)) },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        //public ActionResult GetAwardList2(AwardsModel model)
        //{
        //    try
        //    {
        //        return Json(new { model = new AwardsModel().GetAwardList2() }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}
    