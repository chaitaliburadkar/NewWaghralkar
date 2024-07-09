using NewWaghralkar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewWaghralkar.Models
{
    public class AppointmentModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public string Date { get; set; }
        public string Gender { get; set; }
        public string Message { get; set; }

        public string SaveAppointment(AppointmentModel model)
        {
            var message = "Appointment booked successfully!";
            WaghralkarEntities db = new WaghralkarEntities();

            var data = new mytable()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                City = model.City,
                Mobile = model.Mobile,
                Date = model.Date,
                Gender = model.Gender,
                Message = model.Message,
            };
            db.mytables.Add(data);
            db.SaveChanges();
            return message;
        }
    }
}