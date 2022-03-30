using DoAnWebBanDongHo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebBanDongHo.Controllers
{
    public class GioHangController : Controller
    {
        ModelDongHo db = new ModelDongHo();
        public List<GIOHANG> LayGioHang()
        {
            List<GIOHANG> listGioHang = Session["GIOHANG"] as List<GIOHANG>;
            if (listGioHang == null)
            {
                listGioHang = new List<GIOHANG>();
                Session["GIOHANG"] = listGioHang;

            }

            return listGioHang;
        }

        public ActionResult ThemGioHang(int iMasp, string strURL)
        {
            
            SANPHAM sp = db.SANPHAM.SingleOrDefault(n => n.MASP == iMasp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GIOHANG> listGioHang = LayGioHang();

            GIOHANG sanpham = listGioHang.Find(n => n.iMasp == iMasp);
            if (sanpham == null)
            {
               
               
                    sanpham = new GIOHANG(iMasp);
                    listGioHang.Add(sanpham);
                    return Redirect(strURL);
                
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }

        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            SANPHAM sp = db.SANPHAM.SingleOrDefault(n => n.MASP == iMaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GIOHANG> listGioHang = LayGioHang();
            GIOHANG sanpham = listGioHang.SingleOrDefault(n => n.iMasp == iMaSP);
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }

        public ActionResult XoaGioHang(int iMaSP)
        {
            SANPHAM sp = db.SANPHAM.SingleOrDefault(n => n.MASP == iMaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GIOHANG> listGioHang = LayGioHang();
            GIOHANG sanpham = listGioHang.SingleOrDefault(n => n.iMasp == iMaSP);
            if (sanpham != null)
            {
                listGioHang.RemoveAll(n => n.iMasp == iMaSP);

            }
            if (listGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult XoaTatCaGioHang()
        {
            List<GIOHANG> listGioHang = LayGioHang();
            listGioHang.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GioHang()
        {
            if (Session["GIOHANG"] == null)
            {
                return RedirectToAction("Index", "SanPham");
            }
            List<GIOHANG> listGioHang = LayGioHang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(listGioHang);
        }

        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GIOHANG> listGioHang = Session["GIOHANG"] as List<GIOHANG>;
            if (listGioHang != null)
            {
                iTongSoLuong = listGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        private double TongTien()
        {
            double dTongTien = 0;
            List<GIOHANG> listGioHang = Session["GIOHANG"] as List<GIOHANG>;
            if (listGioHang != null)
            {
                dTongTien = listGioHang.Sum(n => n.dThanhTien);
            }
            return dTongTien;
        }
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        public ActionResult SuaGioHang()
        {
            if (Session["GIOHANG"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GIOHANG> listGioHang = LayGioHang();
            return View(listGioHang);

        }

        public ActionResult DatHang()
        {
            //Kiểm tra đăng đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }
            //Kiểm tra giỏ hàng
            if (Session["GIOHANG"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult DatHang(DONHANG dh)
        {
            
            //Thêm đơn hàng
            TAIKHOAN tk = (TAIKHOAN)Session["use"];
            KHACHHANG kh = db.KHACHHANG.Find(tk.MATK);

            List<GIOHANG> gh = LayGioHang();
            
            dh.MAKH = kh.MAKH;
            dh.TRANGTHAI = "Chưa giao";
            dh.NGAYDAT = DateTime.Now;
            foreach (var item in gh)
            {
                dh.TONGTIEN = (float)item.dDonGia;
            }
            db.DONHANG.Add(dh);
            db.SaveChanges();

            foreach (var item in gh)
            {
                CHITIETDONHANG ctdh = new CHITIETDONHANG();
                ctdh.MADH = dh.MADH;
                ctdh.MASP = item.iMasp;
                ctdh.SOLUONG = item.iSoLuong;
                db.CHITIETDONHANG.Add(ctdh);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}