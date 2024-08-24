using NewWaghralkar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace NewWaghralkar.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public string Savereg(ContactModel model)
        {
            var msg = " Data Saved Successfully!";
            WaghralkarEntities Db = new WaghralkarEntities(); 

            {
                var regData = new tblcontact()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message,
                    
                };

                Db.tblcontacts.Add(regData);
                Db.SaveChanges();
                return msg;
            }
        }
    }
}