using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace HoTroSinhVien.Controllers
{
    public class Trang1Controller : Controller
    {
        // GET: Trang1
        public ActionResult Trang1()
        {
            return View();
        }

        public ActionResult Index() // Trang chu
        {
            return View();
        }

        public ActionResult About() // Huong dan
        {
            return View();
        }

        public ActionResult Contact() // lien he
        {
            return View();
        }
        public ActionResult HoSo() // Ho so
        {
            return View();
        }

        public ActionResult SendMail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("yukthang0@gmail.com", "Thang"); // nguoi gui
                    var receiverEmail = new MailAddress(receiver, "Receiver"); // nguoi nhan
                    var password = "thang123t";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();


        }
}