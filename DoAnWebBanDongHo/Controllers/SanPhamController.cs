using DoAnWebBanDongHo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebBanDongHo.Controllers
{
    public class SanPhamController : Controller
    {
        ModelDongHo db = new ModelDongHo();
        public ActionResult THTissot()
        {
            var th1 = db.SANPHAM.Where(n => n.MATH == 1).Take(4).ToList();
            return PartialView(th1);
        }
        public ActionResult THFrederiqueConstant()
        {
            var th2 = db.SANPHAM.Where(n => n.MATH == 2).Take(4).ToList();
            return PartialView(th2);
        }
        public ActionResult THCalvinKlein()
        {
            var th3 = db.SANPHAM.Where(n => n.MATH == 3).Take(4).ToList();
            return PartialView(th3);
        }

        public ActionResult XemChiTiet(int MaSP = 0)
        {
            var chitiet = db.SANPHAM.SingleOrDefault(n => n.MASP == MaSP);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }

        public ActionResult Index()
        {
            List<SANPHAM> sanpham = db.SANPHAM.ToList();
            return View(sanpham);
        }
    }
}