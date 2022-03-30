using DoAnWebBanDongHo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebBanDongHo.Areas.Admin.Controllers
{
    public class LoaiSanPhamsController : Controller
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

                return View(db.LOAISANPHAM.ToList());
            }
            
        }

        public ActionResult Details(string id)
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
                LOAISANPHAM loaisanpham = db.LOAISANPHAM.Find(id);
                if (loaisanpham == null)
                {
                    return HttpNotFound();
                }
                return View(loaisanpham);
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
                return View();
                
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALOAISP,TENLOAISP")] LOAISANPHAM loaisanpham)
        {
            if (ModelState.IsValid)
            {
                db.LOAISANPHAM.Add(loaisanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaisanpham);
        }

        public ActionResult Edit(string id)
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
                LOAISANPHAM loaisanpham = db.LOAISANPHAM.Find(id);
                if (loaisanpham == null)
                {
                    return HttpNotFound();
                }
                return View(loaisanpham);
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALOAISP,TENLOAISP")] LOAISANPHAM loaisanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaisanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaisanpham);
        }

        public ActionResult Delete(string id)
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
                LOAISANPHAM loaisanpham = db.LOAISANPHAM.Find(id);
                if (loaisanpham == null)
                {
                    return HttpNotFound();
                }
                return View(loaisanpham);
            }
           
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAISANPHAM loaisanpham = db.LOAISANPHAM.Find(id);
            db.LOAISANPHAM.Remove(loaisanpham);
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