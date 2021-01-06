using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using HoTroSinhVien.Models;

namespace HoTroSinhVien.Controllers
{
    public class Trang1Controller : Controller
    {
        // GET: Trang1
        public ActionResult Trang1()
        {
            return View();
        }

        public ActionResult Index1() // Trang chu
        {
            return View();
        }

        public ActionResult About1() // Huong dan
        {
            return View();
        }

        public ActionResult Contact() // lien he
        {
            return View();
        }
        public ActionResult HoSo() // Ho so
        {
            var f = Request.Files["document"];
            if (f != null && f.ContentLength > 0)
            {
                var path = Server.MapPath("~/UploadFiles/" + f.FileName);
                f.SaveAs(path);

                ViewBag.FileName = f.FileName;
                ViewBag.FileType = f.ContentType;
                ViewBag.FileSie = f.ContentLength;
            }
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