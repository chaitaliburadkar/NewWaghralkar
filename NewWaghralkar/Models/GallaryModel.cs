using NewWaghralkar.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace NewWaghralkar.Models
{
    public class GallaryModel
    {
        public int PhotoId { get; set; }
        public string Title { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Type { get; set; }
        public int Srno { get; set; }

        //public List<GallaryModel> GetGallaryList()
        //{
        //    WaghralkarEntities Db = new WaghralkarEntities();
        //    List<GallaryModel> lstGallary = new List<GallaryModel>();
        //    var AddGallaryList = Db.Photogallaries.ToList();
        //    int Srno = 1;
        //    if (AddGallaryList != null)
        //    {
        //        foreach (var Gallary in AddGallaryList)
        //        {
        //            lstGallary.Add(new GallaryModel()
        //            {
        //                Srno = Srno,
        //                PhotoId = Gallary.PhotoId,
        //                Title = Gallary.Title,
        //                Photo1 = Gallary.Photo1,
        //                Photo2 = Gallary.Photo2,
        //                Type = Gallary.Type,
        //            });
        //            Srno++;
        //        }
        //    }
        //    return lstGallary;
        //}

        public string SaveGallary(HttpPostedFileBase fb, GallaryModel model)
        {
            var Message = "Success";
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
            //if (model.PhotoId == 0)
            {
                var regdata = new Photogallary()
                {
                    PhotoId = model.PhotoId,
                    Title = model.Title,
                    Photo1 = sysFileName,
                    Photo2 = sysFileName,
                    Type = model.Type,
                };
                Db.Photogallaries.Add(regdata);
                Db.SaveChanges();
                return Message;
                //}
                //else
                //{
                //    var data = Db.Photogallaries.Where(p => p.PhotoId == model.PhotoId).FirstOrDefault();
                //    if (data != null)
                //    {
                //        data.PhotoId = model.PhotoId;
                //        data.Title = model.Title;
                //        data.Photo1 = model.Photo1;
                //        data.Photo2 = model.Photo2;
                //        data.Type = model.Type;
                //    }

                //    Db.SaveChanges();
                //    Message = "Update Record Successfully";

            }

            //return Message;


        }
        public List<GallaryModel> GetPhotoGallaryList()
        {
            WaghralkarEntities Db = new WaghralkarEntities();
            List<GallaryModel> lstPhotoGallary = new List<GallaryModel>();
            var AddPhotoGallaryList = Db.Photogallaries.ToList();
            if (AddPhotoGallaryList != null)
            {
                foreach (var PhotoGallary in AddPhotoGallaryList)
                {
                    lstPhotoGallary.Add(new GallaryModel()
                    {

                        PhotoId = PhotoGallary.PhotoId,
                        Title = PhotoGallary.Title,
                        Photo1 = PhotoGallary.Photo1,
                        Photo2 = PhotoGallary.Photo2,
                        Type = PhotoGallary.Type,

                    });
                }
            }
            return lstPhotoGallary;
        }
        public string deletePhotoGallary(int PhotoId)
        {
            var msg = "Delete Successfull";
            WaghralkarEntities Db = new WaghralkarEntities();
            var data = Db.Photogallaries.Where(p => p.PhotoId == PhotoId).FirstOrDefault();
            if (data != null)
            {
                Db.Photogallaries.Remove(data);
                Db.SaveChanges();

            }
            return msg;
        }
        public GallaryModel GetPhotoGallarybyId(int PhotoId)
        {
            GallaryModel model = new GallaryModel();
            WaghralkarEntities Db = new WaghralkarEntities();
            var data = Db.Photogallaries.Where(p => p.PhotoId == PhotoId).FirstOrDefault();
            if (data != null)
            {

                model.PhotoId = data.PhotoId;
                model.Title = data.Title;
                model.Photo1 = data.Photo1;
                model.Photo2 = data.Photo2;
                model.Type = data.Type;
            }
            return model;

        }
        public List<GallaryModel> GetSearchList(string Name)
        {
            WaghralkarEntities db = new WaghralkarEntities();
            List<GallaryModel> str = new List<GallaryModel>();
            var AddPhotoGallaryList = db.Photogallaries.Where(p => p.Title == Name).ToList();
            if (AddPhotoGallaryList != null)
            {
                foreach (var reg in AddPhotoGallaryList)
                {
                    str.Add(new GallaryModel()
                    {
                        PhotoId = reg.PhotoId,
                        Title = reg.Title,
                        Photo1 = reg.Photo1,
                        Photo2 = reg.Photo2,
                        Type = reg.Type

                    });
                }
            }
            return str;
        }
    }
}
