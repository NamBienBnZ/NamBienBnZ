using DoAnWebBanDongHo.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebBanDongHo.Areas.Admin.Controllers
{
    public class SanPhamsController : Controller
    {
        ModelDongHo db = new ModelDongHo();
        public ActionResult Index(int? page)
        {
            if(Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = ""});
            }
            else { 
                return View(db.SANPHAM.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                var dt = db.SANPHAM.Find(id);
                return View(dt); 
            }
            
        }

        public ActionResult Create()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                var thuonghieuselected = new SelectList(db.THUONGHIEU, "MATH", "TENTH");
                ViewBag.MATH = thuonghieuselected;
                var loaisanphamselected = new SelectList(db.LOAISANPHAM, "MALOAISP", "TENLOAISP");
                ViewBag.MALOAISP = loaisanphamselected;
                return View();
            }
           
        }

        [HttpPost]
        public ActionResult Create(SANPHAM sanpham)
        {
            try
            {
                db.SANPHAM.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                var dt = db.SANPHAM.Find(id);
                var thuonghieuselected = new SelectList(db.THUONGHIEU, "MATH", "TENTH", dt.MATH);
                ViewBag.MATH = thuonghieuselected;
                var loaisanphamselected = new SelectList(db.LOAISANPHAM, "MALOAISP", "TENLOAISP", dt.MALOAISP);
                ViewBag.MALOAISP = loaisanphamselected;
                return View(dt);
            }
          

        }

        [HttpPost]
        public ActionResult Edit(SANPHAM sanpham)
        {
            try
            {
                var oldItem = db.SANPHAM.Find(sanpham.MASP);
                oldItem.TENSP = sanpham.TENSP;
                oldItem.HINH = sanpham.HINH;
                oldItem.MOTA = sanpham.MOTA;
                oldItem.MATH = sanpham.MATH;
                oldItem.SOLUONG = sanpham.SOLUONG;
                oldItem.MALOAISP = sanpham.MALOAISP;
                oldItem.DONGIA = sanpham.DONGIA;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                var dt = db.SANPHAM.Find(id);
                return View(db.SANPHAM.ToList());
            }
           
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var dt = db.SANPHAM.Find(id);
                db.SANPHAM.Remove(dt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}