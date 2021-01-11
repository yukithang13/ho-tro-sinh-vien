using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoTroSinhVien.Models;
using System.Net;
using System.Net.Mail;

namespace HoTroSinhVien.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Email()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Email(HoTroSinhVien.Models.gmail model)
        {
            
            MailMessage mm = new MailMessage("yukithang0@gmail.com", model.To);           
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("yukithang0@gmail.com", "thang123t");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

            ViewBag.Message = "Successfully";
            return View();
        }

    }
}