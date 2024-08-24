using NewWaghralkar.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NewWaghralkar.Models
{
    public class BlogModel
    {
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public int Srno { get; set; }

        public string SaveBlog(HttpPostedFileBase fb, BlogModel model)
        {
            string Message = "Success";
            WaghralkarEntities Db = new WaghralkarEntities();
            string filepath = "";
            string fileName = "";
            string sysFileName = "";
            if (fb != null && fb.ContentLength > 0)
            {
                filepath = HttpContext.Current.Server.MapPath("../Content/images/");
                DirectoryInfo di = new DirectoryInfo(filepath);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filepath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("~/Content/images") + "/" + sysFileName;
                }
            }
            if (model.ActivityId == 0)
            {
                var regdata = new Blog()
                {
                    ActivityId = model.ActivityId,
                    Title = model.Title,
                    Details = model.Details,
                    Image1 = sysFileName,
                    Image2 = sysFileName,
                    Type = model.Type,
                    Date = model.Date,

                };
                Db.Blogs.Add(regdata);
                Db.SaveChanges();
                Message = "Data Saved Successfully";
            }
            else
            {
                var data = Db.Blogs.Where(p => p.ActivityId == model.ActivityId).FirstOrDefault();
                if (data != null)
                {
                    data.ActivityId = model.ActivityId;
                    data.Title = model.Title;
                    data.Details = model.Details;
                    data.Image1 = model.Image1;
                    data.Image2 = model.Image2;
                    data.Type = model.Type;
                    data.Date = model.Date;

                }
                Db.SaveChanges();
                Message = "Update Record Successfully";
            }

            return Message;


            
        }

        public List<BlogModel> GetBlogList()
        {
            WaghralkarEntities Db = new WaghralkarEntities();
            List<BlogModel> lstBlog = new List<BlogModel>();
            var AddBlogList = Db.Blogs.ToList();
            int Srno = 1;
            if (AddBlogList != null)
            {
                foreach (var BLOG in AddBlogList)
                {
                    lstBlog.Add(new BlogModel()
                    {

                        ActivityId = BLOG.ActivityId,
                        Title = BLOG.Title,
                        Details = BLOG.Details,
                        Image1 = BLOG.Image1,
                        Image2 = BLOG.Image2,
                        Type = BLOG.Type,
                        Date = BLOG.Date,

                    });
                    Srno++;
                }
            }
            return lstBlog;
        }
        public string DeleteBlog(int ActivityId)
        {
            var msg = "Delete Successfull";
            WaghralkarEntities Db = new WaghralkarEntities();
            var data = Db.Blogs.Where(p => p.ActivityId == ActivityId).FirstOrDefault();
            if (data != null)
            {
                Db.Blogs.Remove(data);
                Db.SaveChanges();

            }
            return msg;

        }
        public BlogModel GetBlogbyId(int ActivityId)
        {
            BlogModel model = new BlogModel();
            WaghralkarEntities Db = new WaghralkarEntities();
            var data = Db.Blogs.Where(p => p.ActivityId == ActivityId).FirstOrDefault();
            if (data != null)
            {

                model.ActivityId = data.ActivityId;
                model.Title = data.Title;
                model.Details = data.Details;
                model.Image1 = data.Image1;
                model.Image2 = data.Image2;
                model.Type = data.Type;
                model.Date = data.Date;
            }
            return model;

        }
        //public List<BlogModel> GetSearchList(string Name)
        //{
        //    WaghralkarEntities db = new WaghralkarEntities();
        //    List<BlogModel> str = new List<BlogModel>();
        //    var AddBlogList = db.Blogs.Where(p => p.Title == Name).ToList();
        //    if (AddBlogList != null)
        //    {
        //        foreach (var reg in AddBlogList)
        //        {
        //            str.Add(new BlogModel()
        //            {
        //                ActivityId = reg.ActivityId,
        //                Title = reg.Title,
        //                Details = reg.Details,
        //                Image1 = reg.Image1,
        //                Image2 = reg.Image2,
        //                Type = reg.Type,
        //                Date = reg.Date
        //            });
        //        }
        //    }
        //    return str;
        //}
        public List<BlogModel> GetBlogList2()
        {
            WaghralkarEntities Db = new WaghralkarEntities();
            List<BlogModel> lstBlog = new List<BlogModel>();
            var AddBlogList = Db.Blogs.ToList();
            if (AddBlogList != null)
            {
                foreach (var Blog in AddBlogList)
                {
                    lstBlog.Add(new BlogModel()
                    {
                        
                        ActivityId = Blog.ActivityId,
                        Title = Blog.Title,
                        Details = Blog.Details,
                        Image1 = Blog.Image1,
                        Image2 = Blog.Image2,
                        Type = Blog.Type,
                        Date = Blog.Date,



                    });
                    Srno++;
                }
            }
            return lstBlog;
        }

    }
}
