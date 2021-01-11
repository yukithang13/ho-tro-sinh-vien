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

        
        public ActionResult HoSo1() // Ho so
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

        


    }
}