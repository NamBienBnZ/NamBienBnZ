using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnWebBanDongHo.Models
{
    public class GIOHANG
    {
        ModelDongHo db = new ModelDongHo();
        public int iMasp { get; set; }
        public string sTensp { get; set; }
        public string sHinh { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Hàm tạo cho giỏ hàng
        public GIOHANG(int Masp)
        {
            iMasp = Masp;
            SANPHAM sp = db.SANPHAM.Single(n => n.MASP == iMasp);
            sTensp = sp.TENSP;
            sHinh = sp.HINH;
            dDonGia = double.Parse(sp.DONGIA.ToString());
            iSoLuong = 1;
        }
    }
}