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
    public class DonHangsController : Controller
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
                return View(db.DONHANG.ToList());
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
                DONHANG donhang = db.DONHANG.Find(id);
                if (donhang == null)
                {
                    return HttpNotFound();
                }
                return View(donhang);

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
                ViewBag.MAKH = new SelectList(db.KHACHHANG, "MAKH", "TENKH");
                return View();
            }

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADH,MAKH,TRANGTHAI,DIACHIGIAO,SDT,NGAYDAT,NGAYGIAO,MOTA,TONGTIEN")] DONHANG donhang)
        {
            if (ModelState.IsValid)
            {
                db.DONHANG.Add(donhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donhang);
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
                DONHANG donhang = db.DONHANG.Find(id);
                if (donhang == null)
                {
                    return HttpNotFound();
                }
                ViewBag.MAKH = new SelectList(db.KHACHHANG, "MAKH", "TENKH", donhang.MAKH);
                return View(donhang);
                }

           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MADH,MAKH,TRANGTHAI,DIACHIGIAO,SDT,NGAYDAT,NGAYGIAO,MOTA,TONGTIEN")] DONHANG donhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donhang);
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
                DONHANG donhang = db.DONHANG.Find(id);
                if (donhang == null)
                {
                    return HttpNotFound();
                }
                return View(donhang);
            }
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONHANG donhang = db.DONHANG.Find(id);
            db.DONHANG.Remove(donhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailsCT(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                List<CHITIETDONHANG> listctdh = db.CHITIETDONHANG.Where(s => s.MADH == id).ToList();
                return View(listctdh);
            }
            
        }
    }
}