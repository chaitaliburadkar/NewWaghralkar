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
        public ActionResult AddPhotoGallaryIndex()
        {
            return View();
        }
        
        public ActionResult DetailsIndex(int PhotoId)
        {
            ViewBag.PhotoId = PhotoId;
            return View();
        }
        //public ActionResult GetGallaryList()
        //{
        //    try
        //    {
        //        return Json(new { model = (new GallaryModel().GetGallaryList()) }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        public ActionResult SaveGallary(GallaryModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }
                return Json(new { Message = (new GallaryModel().SaveGallary(fb, model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetPhotoGallaryList()
        {
            try
            {
                return Json(new { model = new GallaryModel().GetPhotoGallaryList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult deletePhotoGallary(int PhotoId)
        {
            try
            {
                return Json(new { model = new GallaryModel().deletePhotoGallary(PhotoId) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetPhotoGallarybyId(int PhotoId)
        {
            try
            {
                return Json(new { model = new GallaryModel().GetPhotoGallarybyId(PhotoId) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetSearchList(string Name)
        {
            try
            {
                return Json(new { model = (new GallaryModel().GetSearchList(Name)) },
               JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}

