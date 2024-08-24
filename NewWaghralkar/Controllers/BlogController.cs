using NewWaghralkar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewWaghralkar.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult BlogIndex()
        {
            return View();
        }
        public ActionResult AddBlogIndex()
        {
            return View();
        }
       
        public ActionResult BlogDetailIndex(int ActivityId)
        {
            ViewBag.ActivityId = ActivityId;
            return View();
        }

        public ActionResult SaveBlog(BlogModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }
                return Json(new { Message = (new BlogModel().SaveBlog(fb, model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetBlogList()
        {
            try
            {
                return Json(new { model = new BlogModel().GetBlogList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteBlog(int ActivityId)
        {
            try
            {
                return Json(new { model = new BlogModel().DeleteBlog(ActivityId) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetBlogbyId(int ActivityId)
        {
            try
            {
                return Json(new { model = new BlogModel().GetBlogbyId(ActivityId) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //        public ActionResult GetSearchList(string Name)
        //        {
        //            try
        //            {
        //                return Json(new { model = (new BlogModel().GetSearchList(Name)) },
        //               JsonRequestBehavior.AllowGet);
        //            }
        //            catch (Exception ex)
        //            {
        //                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
        //            }

        //        }
        public ActionResult GetBlogList2()
        {
            try
            {
                return Json(new { model = new BlogModel().GetBlogList2() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
