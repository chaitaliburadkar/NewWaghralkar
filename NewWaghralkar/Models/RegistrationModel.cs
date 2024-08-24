using NewWaghralkar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewWaghralkar.Models
{
    public class RegistrationModel
    {
        public long Cust_Id { get; set; }
        public string Cust_Name { get; set; }
        public string Contact_No { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public string SaveForm(RegistrationModel model)
        {
            var Message = "Data Saved Successfully !";
            WaghralkarEntities Db = new WaghralkarEntities();
            {
                var data = new Registration()
                {
                    Cust_Id = model.Cust_Id,
                    Cust_Name = model.Cust_Name,
                    Contact_No = model.Contact_No,
                    Email = model.Email,
                    Password = model.Password,
                    Status = model.Status
                };
                Db.Registrations.Add(data);
                Db.SaveChanges();
                return Message;
            }

        }
    }
}
    
