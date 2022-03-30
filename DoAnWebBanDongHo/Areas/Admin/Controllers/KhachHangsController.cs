using DoAnWebBanDongHo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace DoAnWebBanDongHo.Areas.Admin.Controllers
{
    public class KhachHangsController : Controller
    {
        ModelDongHo db = new ModelDongHo();
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                 var khachhangs = db.KHACHHANG.Include(n => n.TAIKHOAN);
                 return View(khachhangs.ToList());

            }
           
        }

        public ActionResult Details(int? id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                KHACHHANG khachhang = db.KHACHHANG.Find(id);
                if (khachhang == null)
                {
                    return HttpNotFound();
                }
                return View(khachhang);

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

                ViewBag.MATK = new SelectList(db.TAIKHOAN, "MATK", "TENTK");
                return View();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAKH,MATK,TENKH,EMAIL,SDT,GIOITINH")] KHACHHANG khachhang)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANG.Add(khachhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachhang);
        }

        public ActionResult Edit(int? id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {

                 if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                KHACHHANG khachhang = db.KHACHHANG.Find(id);
                if (khachhang == null)
                {
                    return HttpNotFound();
                }
                ViewBag.MATK = new SelectList(db.TAIKHOAN, "MATK", "TENTK", khachhang.MATK);
                return View(khachhang);
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAKH,MATK,TENKH,EMAIL,SDT,GIOITINH,DIACHI")] KHACHHANG khachhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachhang);
        }

        public ActionResult Delete(int? id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                 if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    KHACHHANG khachhang = db.KHACHHANG.Find(id);
                    if (khachhang == null)
                    {
                        return HttpNotFound();
                    }
                    return View(khachhang);
            }
           
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHACHHANG khachhang = db.KHACHHANG.Find(id);
            db.KHACHHANG.Remove(khachhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}