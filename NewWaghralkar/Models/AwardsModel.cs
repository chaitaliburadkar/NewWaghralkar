using NewWaghralkar.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace NewWaghralkar.Models
{
    public class AwardsModel
    {
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public int Srno { get; set; }

        public string SaveReg(HttpPostedFileBase fb, AwardsModel model)
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
            //if (model.ActivityId == 0)
            {
                var regdata = new Award()
                {
                    ActivityId = model.ActivityId,
                    Title = model.Title,
                    Details = model.Details,
                    Image1 = sysFileName,
                    Image2 = sysFileName,
                    Type = model.Type,
                    Date = model.Date,

                };
                Db.Awards.Add(regdata);
                Db.SaveChanges();
                //Message = "Data Saved Successfully";
                //}
                //else
                //{
                //    var data = db.tblImages.Where(p => p.Id == model.Id).FirstOrDefault();
                //    if (data != null)
                //    {
                //        data.Id = model.Id;
                //        data.Name = model.Name;
                //        data.Image = sysFileName;

                //    }
                //    Db.SaveChanges();
                //    Message = "Update Record Successfully";
                //}

                return Message;


            }
        }


        public List<AwardsModel> GetAwardsList()
        {
            WaghralkarEntities Db = new WaghralkarEntities();
            List<AwardsModel> lstAwards = new List<AwardsModel>();
            var AddAwardsList = Db.Awards.ToList();
            if (AddAwardsList != null)
            {
                foreach (var Awards in AddAwardsList)
                {
                    lstAwards.Add(new AwardsModel()
                    {

                        ActivityId = Awards.ActivityId,
                        Title = Awards.Title,
                        Details = Awards.Details,
                        Image1 = Awards.Image1,
                        Image2 = Awards.Image2,
                        Type = Awards.Type,
                        Date = Awards.Date,

                    });

                }
            }
            return lstAwards;
        }

        public string DeleteAwards(int ActivityId)
        {
            var msg = "Delete Successfull";
            WaghralkarEntities Db = new WaghralkarEntities();
            var data = Db.Awards.Where(p => p.ActivityId == ActivityId).FirstOrDefault();
            if (data != null)
            {
                Db.Awards.Remove(data);
                Db.SaveChanges();

            }
            return msg;

        }
        public AwardsModel GetAwardsDetailById(int ActivityId)
        {
            AwardsModel model = new AwardsModel();
            WaghralkarEntities Db = new WaghralkarEntities();
            var data = Db.Awards.Where(p => p.ActivityId == ActivityId).FirstOrDefault();
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
        public List<AwardsModel> GetSearchList(string Name)
        {
            WaghralkarEntities db = new WaghralkarEntities();
            List<AwardsModel> str = new List<AwardsModel>();
            var AddAwardList = db.Awards.Where(p => p.Title == Name).ToList();
            if (AddAwardList != null)
            {
                foreach (var reg in AddAwardList)
                {
                    str.Add(new AwardsModel()
                    {
                        ActivityId = reg.ActivityId,
                        Title = reg.Title,
                        Details = reg.Details,
                        Image1 = reg.Image1,
                        Image2 = reg.Image2,
                        Type = reg.Type,
                        Date = reg.Date
                    });
                }
            }
            return str;
        }
        //public List<AwardsModel> GetAwardList2()
        //{
        //    WaghralkarEntities Db = new WaghralkarEntities();
        //    List<AwardsModel> lstAward = new List<AwardsModel>();
        //    var AddAwardList = Db.Awards.ToList();
        //    int Srno = 1;
        //    if (AddAwardList != null)
        //    {
        //        foreach (var Award in AddAwardList)
        //        {
        //            lstAward.Add(new AwardsModel()
        //            {
        //                Srno = Srno,
        //                ActivityId = Award.ActivityId,
        //                Title = Award.Title,
        //                Details = Award.Details,
        //                Image1 = Award.Image1,
        //                Image2 = Award.Image2,
        //                Type = Award.Type,
        //                Date = Award.Date,



        //            });
        //            Srno++;
        //        }
        //    }
        //    return lstAward;
        //}

    }
}
