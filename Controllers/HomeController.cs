using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using HoTroSinhVien.Models;

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
                ViewBag.Message = null;
                var ab_dangnhap = DB.DangNhaps.Where(s => s.TaiKhoan.Equals(Taikhoan) && s.MatKhau.Equals(Matkhau)).ToList();
               
                if (ab_dangnhap.Count() > 0)
                {
                    Session["TaiKhoan"] = ab_dangnhap.FirstOrDefault().TaiKhoan;
                    Session["MatKhau"] = ab_dangnhap.FirstOrDefault().MatKhau;
                    return RedirectToAction("Trang1","Trang1");
                }
                else
                {
                    ViewBag.Message = "";
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
                var check = DB.DangNhaps.FirstOrDefault(s => s.TaiKhoan == _user.TaiKhoan);
                if (check == null)
                {
                    DB.DangNhaps.Add(_user);
                    DB.SaveChanges();
                    return RedirectToAction("DangNhap");
                }
                else
                {
                    ViewBag.error = "Tai khoản này đã trùng";
                    return View();
                }
            }
            return View();


        }



    }
}