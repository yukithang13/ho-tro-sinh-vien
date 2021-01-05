using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Xml.Linq;
using HoTroSinhVien.Models;
using MailMessage = System.Net.Mail.MailMessage;

namespace HoTroSinhVien.Controllers // MENU
{
    public class HomeController : Controller
    {
        DBContext DB = new DBContext();

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

        /*public ActionResult DangNhap()
        {
            if (Session["user_taikhoan"] != null)
            {
                return RedirectToAction("Home", "Hoso");
            }
            else
            {
                return RedirectToAction("DangNhap");
            }

        }*/
       
        public ActionResult DangNhap(string Taikhoan, string Matkhau)
        {
            
            if (ModelState.IsValid)
            {
                ViewBag.Message = "";
                var ab_dangnhap = DB.DangNhaps.Where(s => s.TaiKhoan.Equals(Taikhoan) && s.MatKhau.Equals(Matkhau)).ToList();
               
                if (ab_dangnhap.Count() > 0)
                {
                    Session["TaiKhoan"] = ab_dangnhap.FirstOrDefault().TaiKhoan;
                    Session["MatKhau"] = ab_dangnhap.FirstOrDefault().MatKhau;
                    return RedirectToAction("Trang1","Trang1");
                }
                else
                {
                    ViewBag.Message = "Sai";
                }
            }
            else
            {
                ViewBag.Message = "Nhập lại";
                return RedirectToAction("Login");
            }

            return View();
        }


        public ActionResult DangXuat()
        {
            Session.Clear();// Xoa
            return RedirectToAction("Login");
        }


        public ActionResult DangKi(DangNhap _user)  
        {
            
                
            
                if (ModelState.IsValid)
                {
                    var check = DB.DangNhaps.FirstOrDefault(m => m.TaiKhoan == _user.TaiKhoan);               
                    if (check == null)
                    {
                        DB.DangNhaps.Add(_user);
                        DB.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "Tai khoản này đã trùng";
                        return View();
                    }
                }
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

       
    
}