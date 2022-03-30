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
    public class ThuongHieusController : Controller
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

                return View(db.THUONGHIEU.ToList());
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
                THUONGHIEU thuonghieu = db.THUONGHIEU.Find(id);
                if (thuonghieu == null)
                {
                    return HttpNotFound();
                }
                return View(thuonghieu);
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
        public ActionResult Create([Bind(Include = "MATH,TENTH,HINHTH")] THUONGHIEU thuonghieu)
        {
            if (ModelState.IsValid)
            {
                db.THUONGHIEU.Add(thuonghieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thuonghieu);
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
                THUONGHIEU thuonghieu = db.THUONGHIEU.Find(id);
                if (thuonghieu == null)
                {
                    return HttpNotFound();
                }
                return View(thuonghieu);
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATH,TENTH,HINHTH")] THUONGHIEU thuonghieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuonghieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thuonghieu);
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
                THUONGHIEU thuonghieu = db.THUONGHIEU.Find(id);
                if (thuonghieu == null)
                {
                    return HttpNotFound();
                }
                return View(thuonghieu);
            }
           
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THUONGHIEU thuonghieu = db.THUONGHIEU.Find(id);
            db.THUONGHIEU.Remove(thuonghieu);
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