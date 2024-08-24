using NewWaghralkar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewWaghralkar.Models
{
    public class BookNowModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Appointment_date { get; set; }

        public string Savereg(BookNowModel model)
        {
            var msg = " Data Saved Successfully!";
            WaghralkarEntities Db = new WaghralkarEntities();

            {
                var regData = new BookNow()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    City = model.City,
                    Gender = model.Gender,
                    Appointment_date = model.Appointment_date,

                };

                Db.BookNows.Add(regData);
                Db.SaveChanges();
                return msg;
            }
        }
    }
}