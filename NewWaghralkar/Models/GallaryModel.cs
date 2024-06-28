using NewWaghralkar.Data;
using System;
using System.Collections.Generic;
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

        public List<GallaryModel> GetGallaryList()
        {
            WaghralkarEntities Db = new WaghralkarEntities();
            List<GallaryModel> lstGallary = new List<GallaryModel>();
            var AddGallaryList = Db.Photogallaries.ToList();
            int Srno = 1;
            if (AddGallaryList != null)
            {
                foreach (var Gallary in AddGallaryList)
                {
                    lstGallary.Add(new GallaryModel()
                    {
                        Srno = Srno,
                        PhotoId = Gallary.PhotoId,
                        Title = Gallary.Title,
                        Photo1 = Gallary.Photo1,
                        Photo2 = Gallary.Photo2,
                        Type = Gallary.Type,
                    });
                    Srno++;
                }
            }
            return lstGallary;
        }


    }
}