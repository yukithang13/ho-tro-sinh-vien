using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
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

        
        [HttpGet]
        public ActionResult HoSo()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult HoSo(HoiNhap HN, HttpPostedFileBase CuocThiKiNang, HttpPostedFileBase ChungChiAV)
        {
            HoiNhap hn = new HoiNhap();
            string path = uploadfileCuocThiKyNang(CuocThiKiNang);
            string path1 = uploadfileChungChiAV(ChungChiAV);

            if (path == null || path1 ==null)
            {
                ViewBag.Message = "Sai thông tin kìa >?";
            }
            else
            { 
                hn.ChungChiAV = path1;
                hn.CuocThiKiNang = path;
                DB.HoiNhaps.Add(hn);
                DB.SaveChanges();
            }
            
            return View();
        }

        public string uploadfileCuocThiKyNang(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int ramdom = r.Next();
            if(file !=null && file.ContentLength>0)
            {

                string extension = Path.GetExtension(file.FileName);
                if(extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Image"), ramdom + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/Image" + ramdom + Path.GetFileName(file.FileName);
                    }
                    catch(Exception e)
                    {
                        ViewBag.Message = "Sai thông tin" + e;
                    }
                    
                }
                else
                {
                    ViewBag.Message = "Sai thông tin kìa";
                }
            }    
            return path;
        }
        public string uploadfileChungChiAV(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path1 = "-1";
            int ramdom = r.Next();
            if (file != null && file.ContentLength > 0)
            {

                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg"))
                {
                    try
                    {
                        path1 = Path.Combine(Server.MapPath("~/Content/ImageChungChi"), ramdom + Path.GetFileName(file.FileName));
                        file.SaveAs(path1);
                        path1 = "~/Content/ImageChungChi" + ramdom + Path.GetFileName(file.FileName);
                    }
                    catch (Exception e)
                    {
                        ViewBag.Message = "Sai thông tin" + e;
                    }

                }
                else
                {
                    ViewBag.Message = "Sai thông tin kìa";
                }
            }
            return path1;
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(DangNhap user)
        {
            
            if (ModelState.IsValid)
            {
                ViewBag.Message = "";
                var ab_dangnhap = DB.DangNhaps.Where(s => s.TaiKhoan.Equals(user.TaiKhoan) && s.MatKhau.Equals(user.MatKhau)).ToList();
               
                if (ab_dangnhap.Count() > 0)
                {
                    Session["TaiKhoan"] = ab_dangnhap.FirstOrDefault().TaiKhoan;
                    Session["MatKhau"] = ab_dangnhap.FirstOrDefault().MatKhau;
                    Session["ThanhCong"] = user;
                    return RedirectToAction("HoSo","Home");
                }
                else
                {
                    ViewBag.Message = "Sai";
                }
            }
            else
            {
                ViewBag.Message = "Nhập lại";
                return RedirectToAction("DangNhap");
            }

            return View();
        }


        public ActionResult DangXuat()
        {
            Session.Clear();// Xoa
            return RedirectToAction("DangNhap");
        }


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
                        ViewBag.msg ="Tai khoản này đã trùng";
                        return View();
                    }
                }
            }
            catch
            {
                ViewBag.error = "abc";
            }
            return View();
        }

        

        


    }

       
    
}