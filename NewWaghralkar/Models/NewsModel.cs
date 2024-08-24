using NewWaghralkar.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NewWaghralkar.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Enter_News_Title { get; set; }
        public string Type { get; set; }
        public string Enter_News_Details { get; set; }
        public string Date { get; set; }
        public string Choose1File { get; set; }
        public string Choose2File { get; set; }
        

        public string SaveNews(HttpPostedFileBase fb, NewsModel model)
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
            if (model.Id == 0)
            {
                var regdata = new tbl_AddNews()
                {
                    Id = model.Id,
                    Enter_News_Title = model.Enter_News_Title,
                    Type = model.Type,
                    Enter_News_Details = sysFileName,
                    Date = sysFileName,
                    Choose1File = sysFileName,
                    Choose2File = sysFileName,

                };
                Db.tbl_AddNews.Add(regdata);
                Db.SaveChanges();
                Message = "Data Saved Successfully";
            }
            else
            {
                var data = Db.tbl_AddNews.Where(p => p.Id == model.Id).FirstOrDefault();
                if (data != null)
                {
                    data.Id = model.Id;
                    data.Enter_News_Title = model.Enter_News_Title;
                    data.Type = model.Type;
                    data.Enter_News_Details = model.Enter_News_Details;
                    data.Date = model.Date;
                    data.Choose1File = model.Choose1File;
                    data.Choose2File = model.Choose2File;

                }
                Db.SaveChanges();
                Message = "Update Record Successfully";
            }

            return Message;



        }


        public List<NewsModel> GetNewsList()
        {
            WaghralkarEntities Db = new WaghralkarEntities();
            List<NewsModel> lstNews = new List<NewsModel>();
            var AddNewsList = Db.tbl_AddNews.ToList();
            if (AddNewsList != null)
            {
                foreach (var News in AddNewsList)
                {
                    lstNews.Add(new NewsModel()
                    {

                        Id = News.Id,
                        Enter_News_Title = News.Enter_News_Title,
                        Type = News.Type,
                        Enter_News_Details = News.Enter_News_Details,
                        Date = News.Date,
                        Choose1File = News.Choose1File,
                        Choose2File = News.Choose2File,
                    });
                }
            }
            return lstNews;
        }
        public string DeleteNews(int Id)
        {
            var msg = "Delete Successfull";
            WaghralkarEntities Db = new WaghralkarEntities();
            var data = Db.tbl_AddNews.Where(p => p.Id == Id).FirstOrDefault();
            if (data != null)
            {
                Db.tbl_AddNews.Remove(data);
                Db.SaveChanges();

            }
            return msg;

        }
        public NewsModel GetNewsbyId(int Id)
        {
            NewsModel model = new NewsModel();
            WaghralkarEntities Db = new WaghralkarEntities();
            var data = Db.tbl_AddNews.Where(p => p.Id == Id).FirstOrDefault();
            if (data != null)
            {

                model.Id = data.Id;
                model.Enter_News_Title = data.Enter_News_Title;
                model.Type = data.Type;
                model.Enter_News_Details = data.Enter_News_Details;
                model.Date = data.Date;
                model.Choose1File = data.Choose1File;
                model.Choose2File = data.Choose2File;
            }
            return model;

        }
        //public List<NewsModel> GetNewsList2()
        //{
        //    WaghralkarEntities Db = new WaghralkarEntities();
        //    List<NewsModel> lstNews = new List<NewsModel>();
        //    var AddNewsList = Db.tbl_AddNews.ToList();
        //    int Srno = 1;
        //    if (AddNewsList != null)
        //    {
        //        foreach (var News in AddNewsList)
        //        {
        //            lstNews.Add(new NewsModel()
        //            {

        //                Id = News.Id,
        //                Enter_News_Title = News.Enter_News_Title,
        //                Type = News.Type,
        //                Enter_News_Details = News.Enter_News_Details,
        //                Date = News.Date,
        //                Choose1File = News.Choose1File,
        //                Choose2File = News.Choose2File,



        //            });
        //            Srno++;
        //        }
        //    }
        //    return lstNews;
        //}

    }
}
    

