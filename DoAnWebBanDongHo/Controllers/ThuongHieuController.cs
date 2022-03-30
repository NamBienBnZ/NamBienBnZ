using DoAnWebBanDongHo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebBanDongHo.Controllers
{
    public class ThuongHieuController : Controller
    {
        ModelDongHo db = new ModelDongHo();
        public ActionResult ThuongHieuPartial()
        {
            var thuonghieu = db.THUONGHIEU.ToList();
            return PartialView(thuonghieu);
        }

        public ActionResult Show(int MaTH = 0)
        {
            List<SANPHAM> listth = db.SANPHAM.Where(s => s.MATH == MaTH).ToList();
            return View(listth);
        }
    }
}