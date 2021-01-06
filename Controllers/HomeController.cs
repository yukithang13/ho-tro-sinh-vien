using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var f = Request.Files["document"];
            if(f != null && f.ContentLength > 0 )
            {
                var path = Server.MapPath("~/UploadFiles/" + f.FileName);
                f.SaveAs(path);

                ViewBag.FileName = f.FileName;
                ViewBag.FileType = f.ContentType;
                ViewBag.FileSie = f.ContentLength;
            }    
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


        /* public ActionResult DangKi(DangNhap _user)  
         {



                 if (ModelState.IsValid)
                 {
                     var check = DB.DangNhaps.FirstOrDefaultAsync(m => m.TaiKhoan == _user.TaiKhoan);               
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
         }*/


        public ActionResult DangKi(DangNhap user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var check = DB.DangNhaps.FirstOrDefault(m => m.TaiKhoan == user.TaiKhoan);
                    if (check == null)
                    {
                        Session["TaiKhoan"] = DB.DangNhaps.FirstOrDefault().TaiKhoan;
                        Session["MatKhau"] = DB.DangNhaps.FirstOrDefault().MatKhau;
                        DB.DangNhaps.Add(user);
                        DB.SaveChanges();
                        return RedirectToAction("DangNhap");

                    }
                    else
                    {
                        ViewBag.error = "Tai khoản này đã trùng";
                        return View();
                    }
                }
            }
            catch
            {
                ViewBag.error = "Tai khoản này đã trùng";
            }
            return View();
        }

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