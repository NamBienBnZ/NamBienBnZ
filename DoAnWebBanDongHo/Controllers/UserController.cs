using DoAnWebBanDongHo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebBanDongHo.Controllers
{
    public class UserController : Controller
    {
        ModelDongHo db = new ModelDongHo();
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy([Bind(Include = "TENTK,TENHIENTHI,MATKHAU,LOAITK")] TAIKHOAN model)
        {
            
            if (ModelState.IsValid)
            {
                string email = Request.Form["Email"];
                var check = db.TAIKHOAN.SingleOrDefault(m => m.TENTK.Equals(email));
                
                if (check == null)
                {

                    string x = Request.Form["Password"];
                    string y = Request.Form["ConfirmPassword"];

                    if (x == y)
                    {
                        model.TENTK = Request.Form["Email"];
                        model.TENHIENTHI = Request.Form["DisplayName"];
                        model.MATKHAU = Request.Form["Password"];
                        model.LOAITK = 0;
                       

                            if (model.TENTK == null || model.TENTK == "")
                            {
                                ViewBag.Fail = "Đăng ký thất bại";
                                return View("DangKy");
                            }
                            else
                            {
                                try
                                {

                                    db.TAIKHOAN.Add(model);
                                    db.SaveChanges();

                                    if (ModelState.IsValid)
                                    {
                                        return RedirectToAction("DangNhap");
                                    }


                                }
                                catch { }
                            }   
                                 
                        }
                    }
                
                else
                {
                    ViewBag.Fail = "Đăng ký thất bại";
                    return View("DangKy");
                }
            }
            return View(model);
        }

        public ActionResult DangNhap()
        {
          
          
            if(Session["use"] == null)
            {
                return View();
            }
           

            return RedirectToAction("Index","Home");
            
            
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection userlog)
        //FormCollection dùng để lấy dữ liệu từ layout
        {
            string userMail = userlog["userMail"].ToString();
            string password = userlog["password"].ToString();
            var islogin = db.TAIKHOAN.SingleOrDefault(x => x.TENTK.Equals(userMail) && x.MATKHAU.Equals(password));
            if (islogin != null)
            {
                var admin = db.TAIKHOAN.SingleOrDefault(x => x.TENTK.Equals(userMail) && x.MATKHAU.Equals(password) 
                                                            && x.LOAITK == 1);
              
                if (admin != null)
                {
                    Session["admin"] = islogin;
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "Admin/SanPhams");
                }
                else
                {
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Fail = "Đăng nhập thất bại";
                return View("DangNhap");
            }

        }

        public ActionResult DangXuat()
        {
            Session["use"] = null;
            Session["admin"] = null;
            return RedirectToAction("DangNhap");
        }
    }
}