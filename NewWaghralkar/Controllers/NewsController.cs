using NewWaghralkar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWaghralkar.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult NewsIndex()
        {
            return View();
        }
        public ActionResult AddNewsIndex()
        {
            return View();
        }

        public ActionResult NewsDetailsIndex(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        public ActionResult SaveNews(NewsModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }
                return Json(new { Message = (new NewsModel().SaveNews(fb, model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetNewsList()
        {
            try
            {
                return Json(new { model = new NewsModel().GetNewsList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteNews(int Id)
        {
            try
            {
                return Json(new { model = new NewsModel().DeleteNews(Id) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetNewsbyId(int Id)
        {
            try
            {
                return Json(new { model = new NewsModel().GetNewsbyId(Id) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult GetNewsList2(NewsModel model)
        //{
        //    try
        //    {
        //        return Json(new { model = new NewsModel().GetNewsList2() }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}
    